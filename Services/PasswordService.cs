using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeatStreakBackEnd.Models;
using Microsoft.EntityFrameworkCore; 

namespace NeatStreakBackEnd.Services
{
    public class PasswordService : DbContext
    {
        
    }
}

//under appsettings.json:

// top line of appsettings.json: "ConnectionStrings": {
//     "MyBlogString" : "Server=tcp:codestackblog23lg.database.windows.net,1433;Initial Catalog=CodestackBlog23LG;Persist Security Info=False;User ID=AcademyBlogAdmin;Password=AcademyBlogPassword!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

// },