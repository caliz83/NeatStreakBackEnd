using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeatStreakBackEnd.Models;
using Microsoft.EntityFrameworkCore; //TODO: figure out how to fix the dotnet-ef; it's already installed so not sure what the problem is. also, install whatever does the .vscode folder; i just copy/pasted from another project

namespace NeatStreakBackEnd.Services
{
    public class PasswordService : DbContext
    {
        
    }
}

//under appsettings.json:

//"AllowedHosts": "*",
//"_comment" : "Server Admin login: AcademyBlogAdmin  Password: "AcademyBlogPassword!"

// top line of appsettings.json: "ConnectionStrings": {
//     "MyBlogString" : "Server=tcp:codestackblog23lg.database.windows.net,1433;Initial Catalog=CodestackBlog23LG;Persist Security Info=False;User ID=AcademyBlogAdmin;Password=AcademyBlogPassword!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

// },