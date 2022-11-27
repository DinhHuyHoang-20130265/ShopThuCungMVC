using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace ShopThuCungMVC.Models
{
    public class ShopThuCungDBContext : DbContext
    {
        public DbSet<AdminUser> admin_user { get; set; }
        public DbSet<CustomerUser> customer_user { get; set; }
        public DbSet<Contact> contact { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=shopthucungdb;user=root;password=;Charset=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().ToTable("admin_user");
            modelBuilder.Entity<CustomerUser>(entity =>
            {
                entity.HasKey(o => new { o.id_user, o.user_name });
                entity.ToTable("customer_user");
            });
            modelBuilder.Entity<Contact>().ToTable("contact");
        }
    }
}