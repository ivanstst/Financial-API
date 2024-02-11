using Financial.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Financial.Data
{
    public class FinancialDbContext : DbContext
    {
        //public string connectionString = "Data Source=<YourServer>;Initial Catalog=Financial;User Id=<YourUserID>;Password=<YourPassword>;TrustServerCertificate=True";
        public string connectionString = "Data Source=DESKTOP-F8N9QDD\\LOCALINSTANCE;Initial Catalog=Financial;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<View> Views { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Symbol> Symbols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}