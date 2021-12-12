using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataBaseWork;

namespace DataBaseContext
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Group> Groups { get; set; } = null!;

        public DbSet<Curator> Curators { get; set; } = null!;

        public UniversityContext() : base(GetOptions("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=University"))
        {

        }

        public UniversityContext(string connectionString) 
            : base(GetOptions(connectionString))
        { 
            
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return optionsBuilder.Options;
        }
    }
}