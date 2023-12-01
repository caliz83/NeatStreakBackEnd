using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NeatStreakBackEnd.Models;
using NeatStreakBackEnd.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;
using NeatStreakBackEnd.Models.DTO;

namespace NeatStreakBackEnd.Services
{
    public class UserService : ControllerBase
    {
        //variable
        private readonly DataContext _context;

        //constructor
        public UserService(DataContext context){
            _context = context;
        }

        public bool DoesUserExist(string? username) {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        public bool AddUser(CreateAccountDTO UserToAdd){
            bool result = false;

            if(!DoesUserExist(UserToAdd.Username)){
                //instance of UserModel
                UserModel newUser = new UserModel();

                var newHashedPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = newHashedPassword.Salt;
                newUser.Hash = newHashedPassword.Hash;

                //add user to db
                _context.Add(newUser);

                //save changes
                result = _context.SaveChanges() != 0;
            }
            //if user does exist, throw a false
            return result;
        }

        public PasswordDTO HashPassword(string password) {
            PasswordDTO newHashedPassword = new PasswordDTO();

            byte[] SaltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            //exclude all zeroes
            provider.GetNonZeroBytes(SaltBytes);
            //encrypt the 64string
            var Salt = Convert.ToBase64String(SaltBytes);
            //used to create the hash (pw, bytes, iterations)
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            //create the hash
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            //return the new hash
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;
            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt) {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }

        public IActionResult Login(LoginDTO user){
            IActionResult Result = Unauthorized();
            if(DoesUserExist(user.Username)){
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tbd")); //TODO: figure out if @345 is important
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "tbd - put ip address here", //TODO: put in ip address here
                    audience: "tbd - put ip address here", //TODO: put in ip address here
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                Result = Ok(new { Token = tokenString });
            }
            return Result;
        }

        public UserModel GetUserByUsername(string? username) {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public bool DeleteUser(string Username) {
            UserModel foundUser = GetUserByUsername(Username);
            bool result = false;
            
            if(foundUser != null){
                foundUser.Username = Username;
                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }
    }
}