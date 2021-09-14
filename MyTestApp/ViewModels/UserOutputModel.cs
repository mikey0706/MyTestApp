using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.ViewModels
{
    public class UserOutputModel
    {
        public string Name { get; }
        public string Login { get; }

        public UserOutputModel(string name, string login) 
        {
            Name = name;
            Login = login;
        }
    }
}
