using ECommerceDomainLair;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ECommerceInfraStructureLair
{





    public class ECommerceDbContext : DbContext
    {







        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }




        public DbSet<CustomerDomain> Customers { get; set; }



        public DbSet<OrderDomain> Orders { get; set; }



        public DbSet<ProductDomain> Products { get; set; }



        public DbSet<ShippingDomain> Shippings { get; set; }



        public DbSet<CategoryDomain> Categories { get; set; }



        public DbSet<AddressDomain> Addresses { get; set; }



        public DbSet<CartDomain> Carts { get; set; }



        public DbSet<CartItemsDomain> CartItems { get; set; }



        public DbSet<DiscountDomain> Discounts { get; set; }



        public DbSet<NotificationDomain> Notifications { get; set; }



        public DbSet<OrderItemsDomain> OrderItems { get; set; }



        public DbSet<PaymentDomain> Payments { get; set; }



        public DbSet<ProductDiscountDomain> ProductDiscounts { get; set; }



        public DbSet<UserDomain> Users { get; set; }



        public DbSet<WishListDomain> WishLists { get; set; }



        public DbSet<WishlistItemsDomain> WishlistItems { get; set; }



        public DbSet<InventoryDomain> Inventories { get; set; }



        public DbSet<InventoryItemDomain> InventoryItems { get; set; }



        public DbSet<NotificationTypeDomain> NotificationTypes { get; set; }



        public DbSet<OrderDiscountDomain> OrderDiscounts { get; set; }



        public DbSet<ShipmentTrackingDomain> ShipmentTrackingDomains  { get; set; }



        public DbSet<RoleDomain> Roles { get; set; }
        


        public DbSet<PermissionDomain> Permissions { get; set; }



        public DbSet<UserRoleDomain> UserRoles { get; set; }
        


        public DbSet<RolePermissionDomain> RolePermissions { get; set; }
        
        public DbSet<UserPermissionDomain> userPermission {get ;set;}






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<AddressDomain>(entity =>
            {
                entity.HasKey(a => a.AddressId);

                entity.HasOne(a => a.Customer)
                      .WithMany(c => c.Addresses)
                      .HasForeignKey(a => a.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.Orders)
                      .WithOne(o => o.Address)
                      .HasForeignKey(o => o.AddressId)
                      .OnDelete(DeleteBehavior.Restrict);


            });













            modelBuilder.Entity<CartDomain>(entity =>
            {
                entity.HasKey(cart => cart.Cartid);

                entity.HasOne(cart => cart.Customer)
                      .WithOne(customer => customer.Cart)
                      .HasForeignKey<CartDomain>(cart => cart.CustomerID)
                      .OnDelete(DeleteBehavior.Restrict);


            });














            modelBuilder.Entity<CartItemsDomain>(entity =>
            {
                entity.HasKey(cartitem => cartitem.CartItemsID);


                entity.Property(ci => ci.UnitPrice).HasColumnType("decimal(10,2)");




                entity.HasOne(cartitem => cartitem.Cart)
                      .WithMany(cart => cart.CartItems)
                      .HasForeignKey(cartitem => cartitem.CartId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cartitem => cartitem.Product)
                      .WithMany(product => product.CartItems)
                      .HasForeignKey(cartitem => cartitem.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
            });














            modelBuilder.Entity<CategoryDomain>(entity =>
            {
                entity.HasKey(category => category.CategoryID);

                entity.Property(c => c.CategoryDescription)
                      .HasMaxLength(5000);

                entity.HasOne(category => category.ParentCategory)
                      .WithMany(parent => parent.SubCategories)
                      .HasForeignKey(category => category.ParentCategoryID)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

            });















            modelBuilder.Entity<CustomerDomain>(entity =>
            {
                entity.HasKey(Customer => Customer.CustomerID);


                entity.HasOne(c => c.User)
                      .WithOne(u => u.Customer)
                      .HasForeignKey<CustomerDomain>(c => c.UserID)
                      .OnDelete(DeleteBehavior.Restrict);

            

             
            });













            modelBuilder.Entity<DiscountDomain>(entity =>
            {
                entity.HasKey(Discount => Discount.DiscountID);


                entity.Property(d => d.MainOrderAmount).HasColumnType("decimal(10,2)");
                entity.Property(d => d.MaxUses).HasColumnType("decimal(10,2)");     // reminder: this should really be int, not decimal — flagged earlier
                entity.Property(d => d.UsesCount).HasColumnType("decimal(10,2)");   // same

            });












            modelBuilder.Entity<OrderDiscountDomain>(entity =>
            {
                entity.HasKey(OrderDiscount => OrderDiscount.OrderDiscountId);


                entity.HasOne(OrderDiscount => OrderDiscount.Order)
                      .WithMany(Order => Order.OrderDiscount)
                      .HasForeignKey(OrderDiscount => OrderDiscount.OrderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(OrderDiscount => OrderDiscount.Discount)
                      .WithMany(Discount => Discount.OrderDiscount)
                      .HasForeignKey(OrderDiscount => OrderDiscount.DiscountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });











            modelBuilder.Entity<CategoryDiscountDomain>(entity =>
            {
                entity.HasKey(CategoryDiscount => CategoryDiscount.CategoryDiscountId);


                entity.HasOne(CategoryDiscount => CategoryDiscount.Category)
                      .WithMany(Category => Category.CategoryDiscount)
                      .HasForeignKey(CategoryDiscount => CategoryDiscount.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(CategoryDiscount => CategoryDiscount.Discount)
                      .WithMany(Discount => Discount.CategoryDiscount)
                      .HasForeignKey(CategoryDiscount => CategoryDiscount.DiscountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });










            modelBuilder.Entity<ProductDiscountDomain>(entity =>
            {
                entity.HasKey(ProductDiscount => ProductDiscount.ProductDiscountId);


                entity.HasOne(ProductDiscount => ProductDiscount.Product)
                      .WithMany(Product => Product.ProductDiscount)
                      .HasForeignKey(ProductDiscount => ProductDiscount.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ProductDiscount => ProductDiscount.Discount)
                      .WithMany(Discount => Discount.ProductDiscount)
                      .HasForeignKey(ProductDiscount => ProductDiscount.DiscountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });









            modelBuilder.Entity<InventoryDomain>(entity =>
            {
                entity.HasKey(Inventory => Inventory.InventoryId);

            });











            modelBuilder.Entity<InventoryItemDomain>(entity =>
            {
                entity.HasKey(InventoryItem => InventoryItem.InventoryItemsId);

                entity.HasOne(InventoryItems => InventoryItems.Inventory)
                .WithMany(Inventory => Inventory.InventoryItems)
                .HasForeignKey(InventoryItem => InventoryItem.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);



                entity.HasOne(InventoryItems => InventoryItems.Product)
                .WithMany(Product => Product.InventoryItems)
                .HasForeignKey(InventoryItem => InventoryItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            });









            modelBuilder.Entity<NotificationTypeDomain>(entity =>
            {
                entity.HasKey(nt => nt.NotificationTypeId);
            });









            modelBuilder.Entity<NotificationDomain>(entity =>
            {
                entity.HasKey(n => n.NotificationId);

                entity.HasOne(n => n.Customer)
                      .WithMany(c => c.Notifications)         
                      .HasForeignKey(n => n.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.NotificationType)
                      .WithMany(nt => nt.Notifications)
                      .HasForeignKey(n => n.NotificationTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });











            modelBuilder.Entity<OrderDomain>(entity =>
            {
                entity.HasKey(o => o.OrderID);



                entity.Property(o => o.Subtotal).HasColumnType("decimal(10,2)");
                entity.Property(o => o.DiscountAmount).HasColumnType("decimal(10,2)");
                entity.Property(o => o.Tax).HasColumnType("decimal(10,2)");
                entity.Property(o => o.Total).HasColumnType("decimal(10,2)");




                entity.HasOne(o => o.Customer)
                      .WithMany(c => c.Orders)          // requires Customer.Orders collection — see note below
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);


            });








            modelBuilder.Entity<OrderItemsDomain>(entity =>
            {
                entity.HasKey(oi => oi.OrderItemID);

               

                entity.HasOne(oi => oi.Order)
                      .WithMany(o => o.Items)
                      .HasForeignKey(oi => oi.OrderID)
                      .OnDelete(DeleteBehavior.Cascade);   // see reasoning below

                entity.HasOne(oi => oi.Product)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(oi => oi.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);
            });








            modelBuilder.Entity<PaymentDomain>(entity =>
            {
                entity.HasKey(p => p.PaymentId);

                entity.Property(p => p.Amount).HasColumnType("decimal(10,2)");

                entity.HasOne(p => p.Order)
                      .WithMany(o => o.Payments)      // requires Order.Payments collection — see note below
                      .HasForeignKey(p => p.OrderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });










            modelBuilder.Entity<ProductDomain>(entity =>
            {
                entity.HasKey(p => p.ProductID);

                entity.Property(p => p.Price).HasColumnType("decimal(10,2)");

                entity.HasIndex(p => p.ProductName);   // optional — speeds up search/lookup by name

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)       // requires Category.Products collection — see note below
                      .HasForeignKey(p => p.CategoryID)
                      .OnDelete(DeleteBehavior.Restrict);
            });






   



            modelBuilder.Entity<ShippingDomain>(entity =>
            {
                entity.HasKey(s => s.ShippingId);

                entity.Property(s => s.ShippingCost).HasColumnType("decimal(10,2)");

                entity.HasIndex(s => s.TrackingNumber).IsUnique();


                entity.HasOne(s => s.Order)
                      .WithOne()
                      .HasForeignKey<ShippingDomain>(s => s.OrderId)
                      .OnDelete(DeleteBehavior.Restrict);


            });








            modelBuilder.Entity<ShipmentTrackingDomain>(entity =>
            {
                entity.HasKey(st => st.ShipmentTrackingId);

                entity.HasOne(st => st.Shipping)
                      .WithMany(s => s.TrackingHistory)
                      .HasForeignKey(st => st.ShipmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });








            modelBuilder.Entity<UserDomain>(entity =>
            {
                entity.HasKey(u => u.UserID);

                entity.HasIndex(u => u.Email).IsUnique();   // enforce no duplicate accounts

      
            });








            modelBuilder.Entity<WishListDomain>(entity =>
            {
                entity.HasKey(w => w.WishListId);

                entity.HasOne(w => w.Customer)
                      .WithMany()                      // add .WithMany(c => c.WishLists) if Customer needs a back-collection
                      .HasForeignKey(w => w.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);   // see reasoning below
            });








            modelBuilder.Entity<WishlistItemsDomain>(entity =>
            {
                entity.HasKey(wi => wi.WishListItemsId);

                entity.HasIndex(wi => new { wi.WishlistId, wi.ProductId }).IsUnique();  // prevent duplicate product in same wishlist

                entity.HasOne(wi => wi.Wishlist)
                      .WithMany(w => w.Items)          // requires WishListDomain.Items collection — see note below
                      .HasForeignKey(wi => wi.WishlistId)
                      .OnDelete(DeleteBehavior.Cascade);   // items are meaningless without their parent wishlist

                entity.HasOne(wi => wi.Product)
                      .WithMany()
                      .HasForeignKey(wi => wi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);  // don't let deleting a product silently wipe wishlist history
            });








            // 2) Add this block inside OnModelCreating(), alongside your CategoryDomain config:
            
            modelBuilder.Entity<RoleDomain>(entity =>
            {
                entity.HasKey(role => role.RoleID);
            
                entity.HasIndex(role => role.RoleName)
                      .IsUnique();
            });
            










            modelBuilder.Entity<PermissionDomain>(entity =>
            {
                entity.HasKey(permission => permission.PermissionID);
            
                entity.HasIndex(permission => permission.PermissionName)
                      .IsUnique();
            });
            







            modelBuilder.Entity<UserRoleDomain>(entity =>
            {
                entity.HasKey(userRole => userRole.UserRoleID);
            
                // Prevent the same user being assigned the same role twice at the DB level
                entity.HasIndex(userRole => new { userRole.UserID, userRole.RoleID })
                      .IsUnique();
            
                entity.HasOne(userRole => userRole.User)
                      .WithMany(user => user.UserRoles)
                      .HasForeignKey(userRole => userRole.UserID)
                      .OnDelete(DeleteBehavior.Cascade); // delete assignment if user is deleted
            
                entity.HasOne(userRole => userRole.Role)
                      .WithMany(role => role.UserRoles)
                      .HasForeignKey(userRole => userRole.RoleID)
                      .OnDelete(DeleteBehavior.Restrict); // don't let a role deletion cascade-wipe users
            });
            







            modelBuilder.Entity<RolePermissionDomain>(entity =>
            {
                entity.HasKey(rolePermission => rolePermission.RolePermissionID);
            
                entity.HasIndex(rolePermission => new { rolePermission.RoleID, rolePermission.PermissionID })
                      .IsUnique();
            
                entity.HasOne(rolePermission => rolePermission.Role)
                      .WithMany(role => role.RolePermissions)
                      .HasForeignKey(rolePermission => rolePermission.RoleID)
                      .OnDelete(DeleteBehavior.Cascade);
            
                entity.HasOne(rolePermission => rolePermission.Permission)
                      .WithMany(permission => permission.RolePermissions)
                      .HasForeignKey(rolePermission => rolePermission.PermissionID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
                        
                        
                        
            
            
            modelBuilder.Entity<UserPermissionDomain>(entity =>
            {
                entity.HasKey(userPermission => userPermission.UserPermissionID);
            
                entity.HasIndex(userPermission => new { userPermission.UserID, userPermission.PermissionID })
                      .IsUnique();
            
                entity.HasOne(userPermission => userPermission.User)
                      .WithMany(user => user.UserPermissions)
                      .HasForeignKey(userPermission => userPermission.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            
                entity.HasOne(userPermission => userPermission.Permission)
                      .WithMany(permission => permission.UserPermissions)
                      .HasForeignKey(userPermission => userPermission.PermissionID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            
            
      }
            
            
      }
            
            
}

