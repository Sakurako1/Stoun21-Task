using HrSearchApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HrSearchApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HrApp.db");
        }

        public DbSet<Hr> Hrs { get; set; } = null!;
        public DbSet<Vacancy> Vacancies { get; set; } = null!;


    }

}

