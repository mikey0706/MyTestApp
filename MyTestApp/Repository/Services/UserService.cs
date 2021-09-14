using MyTestApp.Context;
using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestApp.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context) 
        {

            _context = context;
        }
        public bool CheckUser(string name, string password)
        {
            StringBuilder sb = new StringBuilder(name);
            var data = _context.Users.Where(
                   u => u.UserName.Equals(sb.Append("@mail").ToString()) && u.Password.Equals(password)
                   ).FirstOrDefault();

            if (data != null)
            {
                return true;
            }
            return false;

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users; 
        }
    }
}
