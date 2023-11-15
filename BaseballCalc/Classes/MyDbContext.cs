using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class MyDbContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Speler> Speler { get; set; }
        public DbSet<Season> Season { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gebruiker\Downloads\BaseballProject\BaseballCalc\BaseballProject.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
