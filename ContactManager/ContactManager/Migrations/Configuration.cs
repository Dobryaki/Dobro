namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactManager.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(ContactManager.Models.ApplicationDbContext context)
        {
            /*
            context - это соединение с базой данных
            ir - используется длоя получения результата операции
            объект rm - ссылается на строготипизированный менеджер ролей

            */

            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            ir = rm.Create(new IdentityRole("canEdit")); //добавляем роль

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context)); //

            var user = new ApplicationUser() //user - это целый объект с единственным свойством
            {
                UserName = "dimaserd84@gmail.com",
            };

            ir = um.Create(user, "password"); //добавляем пользователя
            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }
            ir = um.AddToRole(user.Id, "canEdit"); //добавляем созданного юзера к ролям
            return ir.Succeeded;
        }

        protected override void Seed(ContactManager.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   Name = "Debra Garcia",
                   Address = "1234 Main St",
                   City = "Redmond",
                   State = "WA",
                   Zip = "10999",
                   Email = "debra@example.com",
               },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                }
                );
        }
    }
}
