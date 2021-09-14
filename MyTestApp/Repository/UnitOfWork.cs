using MyTestApp.Context;
using MyTestApp.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.Repository
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork() 
        {
            _context = new AppDbContext();
        }

        public IUserService UserData() {
            return new UserService(_context);
        }
    }
}
