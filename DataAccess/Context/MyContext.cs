namespace DataAccess.Database
{
    using DataAccess.Entities;
    using DataAccess.EntityConfiguration;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class MyContext : DbContext, IEntityContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetail> Payments { get; set; }

        public object GetContext => this;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BookStoreManagementV1;Trusted_Connection=False;User Id=sa;Password=123;");
                //optionsBuilder.UseSqlServer("Server=SE140927;Database=BookStoreManagement;Trusted_Connection=False;uid=sa;pwd=123;");
                //optionsBuilder.UseSqlServer("Server=tcp:truongtran0407.database.windows.net,1433;Initial Catalog=BookStoreDB;Persist Security Info=False;User ID=truongtq;Password=EstKool5148;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new AccountConfiguration())
                .ApplyConfiguration(new BookConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new OrderConfiguration())
                .ApplyConfiguration(new OrderDetailConfiguration())
                .ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
