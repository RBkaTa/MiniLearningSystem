using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniLearningSystem.Models.EntityModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MiniLearningSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Student");
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Trainer");
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "BlogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("BlogAuthor");
                manager.Create(role);
            }

            context.Courses.AddOrUpdate(c => c.Name, new Course[]
            {
                new Course{
                     Name = "C# MVC Frameworks - ASP.NET - март 2017",
                     Description = "Курсът \"ASP.NET Core\" ще ви научи как се изграждат съвременни уеб приложения с архитектурата Model-View-Controller, използвайки HTML5, бази данни, Entity Framework Core и други технологии.",
                     StartDate = new DateTime(2018,08,22),
                     EndDate = new DateTime(2018,08,25)
                },
                new Course{
                     Name = "PHP MVC Frameworks - Symfony - ноември 2018",
                     Description = "В курса по основи на уеб програмирането, ще ви запознаем с основни принципи на уеб разработката като HTTP протокол, сесии и начините на запазване на състоянието, кеширане на данните, различните протоколи за пренос на данни, сигурност.",
                     StartDate = new DateTime(2018,08,22),
                     EndDate = new DateTime(2018,08,25)
                },
                new Course{
                     Name = "Java MVC Frameworks - Spring - март 2017",
                     Description = "Курсът \"Spring MVC\" ще ви научи как се изграждат съвременни Java уеб приложения с архитектурата Model-View-Controller, използвайки HTML5, бази данни, Hibernate / Spring Data и други Java технологии. ",
                     StartDate = new DateTime(2018,08,22),
                     EndDate = new DateTime(2018,08,25)
                },
                new Course{
                     Name = "Computer Networking Fundamentals - септември 2018",
                     Description = "Курсът е подходящ за напълно начинаещи, както и за всички, които имат някакви базови познания и умения, но искат да ги надградят и да придобият една стабилна основа по компютърни мрежи.",
                     StartDate = new DateTime(2018,08,22),
                     EndDate = new DateTime(2018,08,25)
                }
            });
        }
    }
}
