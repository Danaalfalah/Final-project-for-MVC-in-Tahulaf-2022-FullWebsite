using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card1> Card1s { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Categoryproduct1> Categoryproduct1s { get; set; }
        public virtual DbSet<Categorystore1> Categorystore1s { get; set; }
        public virtual DbSet<Contactu> Contactus { get; set; }
        public virtual DbSet<Contactusform> Contactusforms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customer1> Customer1s { get; set; }
        public virtual DbSet<Deliveryinfo> Deliveryinfos { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order1> Order1s { get; set; }
        public virtual DbSet<Orderitem1> Orderitem1s { get; set; }
        public virtual DbSet<Ourstory> Ourstories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product1> Product1s { get; set; }
        public virtual DbSet<ProductCustomer> ProductCustomers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role1> Role1s { get; set; }
        public virtual DbSet<Slidehome> Slidehomes { get; set; }
        public virtual DbSet<Socialmedia1> Socialmedia1s { get; set; }
        public virtual DbSet<Socialmedium> Socialmedia { get; set; }
        public virtual DbSet<Store1> Store1s { get; set; }
        public virtual DbSet<Userlogin> Userlogins { get; set; }
        public virtual DbSet<Userlogin1> Userlogin1s { get; set; }
        public virtual DbSet<Worktime> Worktimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH14_USER136;PASSWORD=d321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH14_USER136")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Card1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CARD1");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Customername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CUSTOMERNAME");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVV");

                entity.Property(e => e.Typeofcard)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TYPEOFCARD");

                entity.Property(e => e.Validdate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALIDDATE");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CARD_FK");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Categoryproduct1>(entity =>
            {
                entity.HasKey(e => e.Categoryproductid)
                    .HasName("SYS_C00220986");

                entity.ToTable("CATEGORYPRODUCT1");

                entity.Property(e => e.Categoryproductid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYPRODUCTID");

                entity.Property(e => e.Categoryproductname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORYPRODUCTNAME");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Storeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STOREID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Categoryproduct1s)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CATEGORYPRODUCT1_FK");
            });

            modelBuilder.Entity<Categorystore1>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("SYS_C00213371");

                entity.ToTable("CATEGORYSTORE1");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Discription)
                    .HasMaxLength(255)
                    .HasColumnName("DISCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .HasColumnName("IMAGEPATH");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<Contactusform>(entity =>
            {
                entity.ToTable("CONTACTUSFORM");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("SYS_C00220973");

                entity.ToTable("CUSTOMER1");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<Deliveryinfo>(entity =>
            {
                entity.ToTable("DELIVERYINFO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Deliverycharge)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DELIVERYCHARGE");

                entity.Property(e => e.Deliveryfreeabove)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DELIVERYFREEABOVE");

                entity.Property(e => e.Numberofdaydelivery)
                    .HasMaxLength(7)
                    .HasColumnName("NUMBEROFDAYDELIVERY");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Locationanurl)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATIONANURL");

                entity.Property(e => e.Locationname)
                    .HasMaxLength(50)
                    .HasColumnName("LOCATIONNAME");
            });

            modelBuilder.Entity<Order1>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("SYS_C00221027");

                entity.ToTable("ORDER1");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Orderitemid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERITEMID");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TOTALPRICE");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order1s)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDER_FK_FORCUSTOMER");

                entity.HasOne(d => d.Orderitem)
                    .WithMany(p => p.Order1s)
                    .HasForeignKey(d => d.Orderitemid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDERPRODUCT_ORDERID_FK");
            });

            modelBuilder.Entity<Orderitem1>(entity =>
            {
                entity.HasKey(e => e.Orderitemid)
                    .HasName("SYS_C00221024");

                entity.ToTable("ORDERITEM1");

                entity.Property(e => e.Orderitemid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERITEMID");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantityitem)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITYITEM");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitem1s)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDERPRODUCT_PRODUCTID_FK");
            });

            modelBuilder.Entity<Ourstory>(entity =>
            {
                entity.ToTable("OURSTORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Story)
                    .HasMaxLength(100)
                    .HasColumnName("STORY");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Namee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMEE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CATEGORY_ID");
            });

            modelBuilder.Entity<Product1>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("SYS_C00220990");

                entity.ToTable("PRODUCT1");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Categoryproductid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYPRODUCTID");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCTNAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Sale)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Categoryproduct)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.Categoryproductid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRODUCT1_FK");
            });

            modelBuilder.Entity<ProductCustomer>(entity =>
            {
                entity.ToTable("PRODUCT_CUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_FROM");

                entity.Property(e => e.DateTo)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_TO");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK1_CUSTOMER_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCustomers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK1_PRODUCT_ID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C00213357");

                entity.ToTable("ROLE1");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Slidehome>(entity =>
            {
                entity.ToTable("SLIDEHOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Img1)
                    .HasMaxLength(100)
                    .HasColumnName("IMG1");

                entity.Property(e => e.Img2)
                    .HasMaxLength(100)
                    .HasColumnName("IMG2");

                entity.Property(e => e.Img3)
                    .HasMaxLength(100)
                    .HasColumnName("IMG3");
            });

            modelBuilder.Entity<Socialmedia1>(entity =>
            {
                entity.ToTable("SOCIALMEDIA1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Socialicon)
                    .HasMaxLength(100)
                    .HasColumnName("SOCIALICON");

                entity.Property(e => e.Socialurl)
                    .HasMaxLength(255)
                    .HasColumnName("SOCIALURL");
            });

            modelBuilder.Entity<Socialmedium>(entity =>
            {
                entity.ToTable("SOCIALMEDIA");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Socialicon)
                    .HasMaxLength(100)
                    .HasColumnName("SOCIALICON");

                entity.Property(e => e.Socialurl)
                    .HasMaxLength(255)
                    .HasColumnName("SOCIALURL");
            });

            modelBuilder.Entity<Store1>(entity =>
            {
                entity.HasKey(e => e.Storeid)
                    .HasName("SYS_C00220982");

                entity.ToTable("STORE1");

                entity.Property(e => e.Storeid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STOREID");

                entity.Property(e => e.Categorystoreid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYSTOREID");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Storename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("STORENAME");

                entity.HasOne(d => d.Categorystore)
                    .WithMany(p => p.Store1s)
                    .HasForeignKey(d => d.Categorystoreid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("STORE1_FK");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.ToTable("USERLOGIN");

                entity.HasIndex(e => e.Username, "SYS_C00215046")
                    .IsUnique();

                entity.Property(e => e.Userloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERLOGINID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CUSTOMER_IDLOGIN");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ROLE_FKLOGIN");
            });

            modelBuilder.Entity<Userlogin1>(entity =>
            {
                entity.HasKey(e => e.Userloginid)
                    .HasName("SYS_C00220977");

                entity.ToTable("USERLOGIN1");

                entity.Property(e => e.Userloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERLOGINID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Userlogin1s)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CUSTOMER_ID_LOGIN");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userlogin1s)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ROLE_FK_LOGIN");
            });

            modelBuilder.Entity<Worktime>(entity =>
            {
                entity.ToTable("WORKTIME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.FriSatclose)
                    .HasMaxLength(20)
                    .HasColumnName("FRI_SATCLOSE");

                entity.Property(e => e.FriSatopen)
                    .HasMaxLength(20)
                    .HasColumnName("FRI_SATOPEN");

                entity.Property(e => e.SunThursdayclose)
                    .HasMaxLength(20)
                    .HasColumnName("SUN_THURSDAYCLOSE");

                entity.Property(e => e.SunThursdayopen)
                    .HasMaxLength(20)
                    .HasColumnName("SUN_THURSDAYOPEN");
            });

            modelBuilder.HasSequence("DEP_SEQ");

            modelBuilder.HasSequence("EMP_SEQ");

            modelBuilder.HasSequence("JORDAN_SEQUENCE");

            modelBuilder.HasSequence("PK_SEQ_ORDER");

            modelBuilder.HasSequence("PK_SEQ_PRO");

            modelBuilder.HasSequence("PK_SEQ_TABLE");

            modelBuilder.HasSequence("PK_SEQ_USER");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
