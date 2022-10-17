using Domain;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccess
{
    public partial class ECommerce_WebsiteContext : DbContext
    {
        public ECommerce_WebsiteContext()
        {
        }

        public ECommerce_WebsiteContext(DbContextOptions<ECommerce_WebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchasedProduct> PurchasedProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=E-Commerce_Website;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartId)
                    .HasMaxLength(50)
                    .HasColumnName("CartID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartItem_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .HasColumnName("Postal_Code");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CartItem)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartItemId)
                    .HasConstraintName("FK_Order_CartItem");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<PurchasedProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatePurchased).HasColumnType("datetime");

                entity.HasOne(d => d.CartItem)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.CartItemId)
                    .HasConstraintName("FK_PurchasedProduct_CartItem");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
