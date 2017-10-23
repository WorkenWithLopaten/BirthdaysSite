namespace MVCTemplate.Data.Migrations
{
    using BirthdaySite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCTemplate.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BirthdaySite.Models.ApplicationDbContext>
    {
        private const string AdministratorUserName = "admin-user@telerikacademy.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = "eventsadmin@telerikacademy.com",
                    Email = "eventsadmin@telerikacademy.com",
                    EmailConfirmed = true,                   
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Admin");
            }
           
            context.Groups.AddOrUpdate(
              g => g.Name,
              new Group("Birthdays")
              {
                  CreatedOn = DateTime.Now,
                  Messages = new List<Message>()
                  {
                      new Message()
                      {
                          Author = "RandomUser",
                          Content = "Testing my forum page..."
                      },
                      new Message()
                      {
                          Author = "RandomUser1",
                          Content = "Testing my forum pageia...Using !important in your CSS usually means you're narcissistic & selfish or lazy. Respect the devs to come..."
                      }
                  }
              },
              new Group("Presents")
              {
                  CreatedOn = DateTime.Now,
                  Messages = new List<Message>()
                  {
                      new Message()
                      {
                          Author = "RandomUser",
                          Content = "Testing my forum page..."
                      },
                      new Message()
                      {
                          Author = "RandomUser1",
                          Content = "Testing my forum pageia...Using !important in your CSS usually means you're narcissistic & selfish or lazy. Respect the devs to come..."
                      }
                  }
              }
            );

            context.FriendsList.AddOrUpdate(
              f => f.Name,
              new FriendsList("testEmail")
              {
                  CreatedOn = DateTime.Now,
                  Friends = new List<Friend>()
                  {
                     new Friend("User1", false)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1995,10,4)
                      },
                     new Friend("User2", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1990,11,12)
                      },
                     new Friend("User3", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1978,11,12)
                      },
                     new Friend("User4", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1988,11,12)
                      },
                      new Friend("User5", false)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1910,10,4)
                      },
                     new Friend("User6", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1990,12,12)
                      },
                     new Friend("User7", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1978,10,12)
                      },
                     new Friend("User8", true)
                      {
                          CreatedOn = DateTime.Now,
                          Birthday = new DateTime(1988,1,12)
                      }
                  }
              }
            );
        }
    }
}
