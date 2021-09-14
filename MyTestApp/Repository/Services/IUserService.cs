using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.Repository.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        public bool CheckUser(string name, string password);
    }
}
