namespace Data.Migrations
{
    using Domaine;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ExamenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.ExamenContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Role roleAdmin = new Role { RoleName = "Admin", Description = "administrateur du site", Users = new List<User>() };
            Role roleUser = new Role { RoleName = "User", Description = "utilisateur du site", Users = new List<User>() };
            Role roleEntreprise = new Role { RoleName = "Entreprise", Description = "utilisateur de type entreprise du site", Users = new List<User>() };
            User admin = new User() { Username = "admin", CreateDate = DateTime.Now, Email = "admin@admin.com", IsActive = true, Password = "123456", FirstName = "admin", LastName = "admin", Roles = new List<Role>() };
            User user = new User() { Username = "user", CreateDate = DateTime.Now, Email = "user@user.com", IsActive = true, Password = "123456", FirstName = "user", LastName = "user", Roles = new List<Role>() };
            User entreprise= new User() { Username = "entreprise", CreateDate = DateTime.Now, Email = "entreprise@entreprise.com", IsActive = true, Password = "123456", FirstName = "user", LastName = "user", Roles = new List<Role>() };

            roleAdmin.Users.Add(admin);
            roleUser.Users.Add(user);
            roleEntreprise.Users.Add(entreprise);
            admin.Roles.Add(roleAdmin);
            user.Roles.Add(roleUser);
            entreprise.Roles.Add(roleEntreprise);

            context.Roles.AddOrUpdate(
                r => r.RoleName,
               roleAdmin,
               roleUser,
               roleEntreprise
                );
            context.Users.AddOrUpdate(
                u => u.Username,
               admin,
               user,
               entreprise
                );
        }
    }
}
