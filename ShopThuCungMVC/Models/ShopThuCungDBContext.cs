using Microsoft.EntityFrameworkCore;

namespace ShopThuCungMVC.Models
{
    public class ShopThuCungDBContext : DbContext
    {
        public DbSet<UserAccount> user_account { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<InforUser> infor_user { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=shopthucungdb;user=root;password=;Charset=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().ToTable("user_account");
            modelBuilder.Entity<InforUser>().ToTable("infor_user");
            modelBuilder.Entity<Contact>().ToTable("contact");
        }
    }
}