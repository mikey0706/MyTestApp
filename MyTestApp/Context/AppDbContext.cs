using Microsoft.EntityFrameworkCore;
using MyTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-G1LJKGG;Database=MyTask;Trusted_Connection=true;MultipleActiveResultSets=true");
        }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(k => k.Id);


            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Vasya",
                    UserName = "Vasya@mail",
                    Password = "1234"
                },

                 new User
                 {
                     Id = 2,
                     Name = "Vitya",
                     UserName = "Vitya@mail",
                     Password = "4321"
                 },
                  new User
                  {
                      Id = 3,
                      Name = "Vova",
                      UserName = "Vova@mail",
                      Password = "654321"
                  }
                );

        }
    }
}
