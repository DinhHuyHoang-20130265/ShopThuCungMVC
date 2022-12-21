using Microsoft.EntityFrameworkCore;

namespace ShopThuCungMVC.Models
{
    public class ShopThuCungDBContext : DbContext
    {
        public DbSet<UserAccount> user_account { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<InforUser> infor_user { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCategory> product_category { get; set; }
        public DbSet<ProductFromCate> product_from_cate { get; set; }
        public DbSet<Blog> blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=shopthucungdb;user=root;password=;Charset=utf8;Convert Zero Datetime=True;allow zero datetime=no");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().ToTable("user_account");
            modelBuilder.Entity<InforUser>().ToTable("infor_user");
            modelBuilder.Entity<Contact>().ToTable("contact");
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<ProductCategory>().ToTable("product_category");
            modelBuilder.Entity<ProductFromCate>().ToTable("product_from_cate");
            modelBuilder.Entity<Blog>().ToTable("blogs");
        }
    }
}