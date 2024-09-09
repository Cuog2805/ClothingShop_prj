using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ClothingShop_prj.Models
{
    public class ClothingShopDbContext : DbContext
    {
        public ClothingShopDbContext() : base("ClothingShopDbContext") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserObject> UserObjects { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminProduct> AdminProducts { get; set; }
        public DbSet<AdminCustomer> AdminCustomers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //tạo khóa chính
            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);
            modelBuilder.Entity<ProductImage>().HasKey(pi => pi.ProductImageID);
            modelBuilder.Entity<Color>().HasKey(c => c.ColorID);
            modelBuilder.Entity<Size>().HasKey(s => s.SizeID);
            modelBuilder.Entity<CategoryItem>().HasKey(ci => ci.CategoryItemID);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
            modelBuilder.Entity<UserObject>().HasKey(u => u.UserOjectID);
            modelBuilder.Entity<Type>().HasKey(t => t.TypeID);

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<Address>().HasKey(a => a.AddressID);
            modelBuilder.Entity<Discount>().HasKey(d => d.DiscountID);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
            modelBuilder.Entity<History>().HasKey(h => h.HistoryID);
            modelBuilder.Entity<Cart>().HasKey(c => c.CartID);
            modelBuilder.Entity<CartItem>().HasKey(ci => ci.CartItemID);
            modelBuilder.Entity<Wishlist>().HasKey(w => w.WishlistID);

            modelBuilder.Entity<Admin>().HasKey(a => a.AdminID);

            //product
            //product-productImage, 1-n
            modelBuilder.Entity<ProductImage>()
                .HasRequired(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .Map(m => m.MapKey("ProductID"));
            //product-color, n-n
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Colors)
                .WithMany(c => c.Products)
                .Map(m =>
                {
                    m.ToTable("ProductColor");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("ColorID");
                });
            //product-size, n-n
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sizes)
                .WithMany(s => s.Products)
                .Map(m =>
                {
                    m.ToTable("ProductSize");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("SizeID");
                });
            //product-categoryItem, n-n
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CategoryItems)
                .WithMany(ci => ci.Products)
                .Map(m =>
                {
                    m.ToTable("ProductCategoryItem");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("CategoryItemID");
                });
            //category-categoryItem, 1-n
            modelBuilder.Entity<CategoryItem>()
                .HasRequired(ci => ci.Category)
                .WithMany(c => c.CategorieItems)
                .Map(m => m.MapKey("CategoryID"));

            //userobject-category, 1-n
            modelBuilder.Entity<Category>()
                .HasRequired(c => c.UserObject)
                .WithMany(u => u.Categories)
                .Map(m => m.MapKey("UserOjectID"));

            //userobject-type, 1-n
            modelBuilder.Entity<Type>()
                .HasRequired(t => t.UserObject)
                .WithMany(u => u.Types)
                .Map(m => m.MapKey("UserObjectID"));

            //product-type, n-n
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Types)
                .WithMany(t => t.Products)
                .Map(m =>
                {
                    m.ToTable("Producttype");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("TypeID");
                });

            //admin
            //product-adminProduct-admin, n-n
            modelBuilder.Entity<AdminProduct>()
                .HasKey(a => new { a.AdminID, a.ProductID });
            modelBuilder.Entity<Product>()
                .HasMany(p => p.AdminProducts)
                .WithRequired(ap => ap.Products).HasForeignKey(ap => ap.ProductID);
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.AdminProducts)
                .WithRequired(ap => ap.Admins).HasForeignKey(ap => ap.AdminID);
            //customer-adminCustomer-admin, n-n
            modelBuilder.Entity<AdminCustomer>()
                .HasKey(a => new { a.AdminID, a.CustomerID });
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.AdminCustomers)
                .WithRequired(ac => ac.Customers).HasForeignKey(ac => ac.CustomerID); 
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.AdminCustomers)
                .WithRequired(ac => ac.Admins).HasForeignKey(ac => ac.AdminID);

            //customer
            //discount-customer, n-n
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Discounts)
                .WithMany(d => d.Customer)
                .Map(m =>
                {
                    m.ToTable("CustomerDiscount");
                    m.MapLeftKey("CustomerID");
                    m.MapRightKey("DiscountID");
                });
            ////address-customer, n-1
            //modelBuilder.Entity<Address>()
            //    .HasRequired(a => a.Customer)
            //    .WithMany(c => c.AddressList)
            //    .Map(m => m.MapKey("CustomerID"));
            //cart-customer, 1-1
            modelBuilder.Entity<Cart>()
                .HasRequired(c => c.Customer)
                .WithRequiredPrincipal(c => c.Cart);
            //cart-cartItem, 1-n
            modelBuilder.Entity<CartItem>()
                .HasRequired(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .Map(m => m.MapKey("CartID"));
            //history-customer, 1-1
            modelBuilder.Entity<History>()
                .HasRequired(h => h.Customer)
                .WithRequiredPrincipal(c => c.History);
            //history-cartItem, 1-n
            modelBuilder.Entity<CartItem>()
                .HasRequired(ci => ci.History)
                .WithMany(h => h.CartItems)
                .Map(m => m.MapKey("HistoryID"));
            //order-customer, 1-n
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .Map(m => m.MapKey("CustomerID"));
            //order-cartItem, 1-n
            modelBuilder.Entity<CartItem>()
                .HasOptional(ci => ci.Order)
                .WithMany(o => o.CartItems)
                .Map(m => m.MapKey("OrderID"));
            //product-cartItem, 1-n
            modelBuilder.Entity<CartItem>()
                .HasOptional(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .Map(m => m.MapKey("ProductID"));

            //product-intermidiate-customer
            //wishlist-customer, 1-1
            modelBuilder.Entity<Wishlist>()
                .HasRequired(w => w.Customer)
                .WithRequiredPrincipal(c => c.Wishlist);
                
            //wishlist - product, 1 - n
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Wishlists)
                .WithMany(w => w.Products)
                .Map(m =>
                {
                    m.ToTable("ProductWishlist");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("WishlistID");
                });
            //product-review-customer
            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.CustomerID, r.ProductID });
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reviews)
                .WithRequired(r => r.Customers).HasForeignKey(r => r.CustomerID);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithRequired(r => r.Products).HasForeignKey(r => r.ProductID);



            base.OnModelCreating(modelBuilder);
        }
    }
}