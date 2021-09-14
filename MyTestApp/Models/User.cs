using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.Models
{
    public class User : IUser
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }
        [StringLength(255)]
        public string Password {get;set;}
    }
}
