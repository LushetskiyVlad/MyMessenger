namespace MessengerServiceHost.Migrations
{
    using MessengerServiceHost.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<MessengerServiceHost.Model.MessengerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MessengerServiceHost.Model.MessengerContext context)
        {
            var md5 = new MD5CryptoServiceProvider();

            User user1 = new User
            {
                Login = "Vlad",
                Password = md5.ComputeHash(Encoding.Default.GetBytes("12345678")),
                Phone ="+380951234567",
                Email ="vlad.Luzhetskiy@gmail.com",
                FirstName ="Владислав",
                LastName ="Лужецкий",
            };

            User user2 = new User
            {
                Login = "Vasya",
                Password = md5.ComputeHash(Encoding.Default.GetBytes("12345678")),
                Phone = "+380665544333",
                Email = "vasya@gmail.com",
                FirstName = "Василий",
                LastName = "Иванов",
            };

            context.Users.Add(user1);
            context.Users.Add(user2);

            Group group = new Group { Name = "", Users = new List<User>() };
            group.Users.Add(user1);
            group.Users.Add(user2);

            context.Groups.Add(group);

            context.SaveChanges();
        }
    }
}