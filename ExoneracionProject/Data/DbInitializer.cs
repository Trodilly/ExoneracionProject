using ExoneracionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Data
{
    public class DbInitializer
    {
        public static void Initialize(RecruitContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Admins.Any())
            {
                return;   // DB has been seeded
            }

            var admin = new Admin[]
            {
                new Admin{Id=Guid.NewGuid(),Name="Alexander Perez",JobTittle="Manager"},
                new Admin{Id=Guid.NewGuid(),Name="Manuel Miguel",JobTittle="HR Employee"},

            };

            context.Admins.AddRange(admin);
            context.SaveChanges();


        }
    }
}
