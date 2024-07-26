using Class.User.UserModel;
using Class.User.CategoryModel;
using Microsoft.EntityFrameworkCore;
using ServiceProvider.Shared.User;
using ServiceProvider.Shared.Requests;
using ServiceProvider.Shared.Chats;
using System.Security.AccessControl;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public virtual DbSet<UserModel> UsersModelDB { get; set; }
    public virtual DbSet<CategoryModel> CategoriesDB { get; set; }
    public virtual DbSet<ServiceProviderProfile> ServiceProviderProfilesDB { get; set; }
    public virtual DbSet<RequestClass> RequestsDB { get; set; }
    public virtual DbSet<RequestDetailClass> RequestDetailsDB { get; set; }
    public virtual DbSet<ChatAuditClass> ChatAuditDB { get; set; }
    public virtual DbSet<ChatHistoryClass> ChatHistoryDB { get; set; }

    public virtual DbSet<GetRequestInfoModel> GetRequestInfoModelDB { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(uc =>
        {
            uc.ToTable("UserTB");
            uc.Property(e => e.ID).HasColumnName("UserID").IsRequired();
            uc.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            uc.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(50);
            uc.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
            uc.Property(e => e.EmailID).HasColumnName("EmailID").HasMaxLength(100);
            uc.Property(e => e.Password).HasColumnName("Password").HasMaxLength(100);
            uc.Property(e => e.CategoryID).HasColumnName("CategoryID").IsRequired();
        });

        modelBuilder.Entity<CategoryModel>(c =>
        {
            c.ToTable("CategoryTB");
            c.Property(e => e.CategoryID).HasColumnName("CategoryID").IsRequired();
            c.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
            c.Property(e => e.Description).HasColumnName("Description").HasMaxLength(500);
        });

        modelBuilder.Entity<ServiceProviderProfile>(sp =>
        {
            sp.ToTable("ServiceProviderProfileTB");
            sp.Property(e => e.ServiceproviderProfileID).HasColumnName("ServiceproviderProfileID").IsRequired();
            sp.Property(e => e.UserID).HasColumnName("UserID");
            sp.Property(e => e.ShopName).HasColumnName("ShopName").HasMaxLength(200);
            sp.Property(e => e.PinCode).HasColumnName("PinCode").HasMaxLength(6);
        });

        modelBuilder.Entity<RequestClass>(r =>
        {
            r.ToTable("RequsetsTB");
            r.Property(e => e.RequestID).HasColumnName("RequestID").IsRequired();
            r.Property(e => e.UserID).HasColumnName("UserID").IsRequired();
            r.Property(e => e.Problem).HasColumnName("Problem").HasMaxLength(100);
            r.Property(e => e.Description).HasColumnName("Description");
            r.Property(e => e.Pincode).HasColumnName("Pincode").HasMaxLength(6);
            r.Property(e => e.CreateDate).HasColumnName("CreateDate");
            r.Property(e => e.IsCanceled).HasColumnName("IsCanceled");
            r.Property(e => e.IsCanceledBy).HasColumnName("IsCanceledBy");
            r.Property(e => e.IsAccepted).HasColumnName("IsAccepted");
            r.Property(e => e.IsCanceledByID).HasColumnName("IsCanceledByID");
            r.Property(e => e.CancelReason).HasColumnName("CancelReason").HasMaxLength(100);
            r.Property(e => e.CancelResonDate).HasColumnName("CancelResonDate");
        });

        modelBuilder.Entity<RequestDetailClass>(rd =>
        {
            rd.ToTable("RequestDetailTB");
            rd.Property(e => e.RequestDetailID).HasColumnName("RequestDetailID").IsRequired();
            rd.Property(e => e.RequestID).HasColumnName("RequestID");
            rd.Property(e => e.AcceptedByID).HasColumnName("AcceptedByID");
            rd.Property(e => e.AcceptDate).HasColumnName("AcceptDate");
            rd.Property(e => e.RequestStatus).HasColumnName("RequestStatus").HasMaxLength(50);
            rd.Property(e => e.IsCanceledBy).HasColumnName("IsCanceledBy");
        });

        modelBuilder.Entity<RequestDetailClass>(rd =>
        {
            rd.ToTable("RequestDetailTB");
            rd.Property(e => e.RequestDetailID).HasColumnName("RequestDetailID").IsRequired();
            rd.Property(e => e.RequestID).HasColumnName("RequestID");
            rd.Property(e => e.AcceptedByID).HasColumnName("AcceptedByID");
            rd.Property(e => e.AcceptDate).HasColumnName("AcceptDate");
            rd.Property(e => e.RequestStatus).HasColumnName("RequestStatus").HasMaxLength(50);
            rd.Property(e => e.IsCanceledBy).HasColumnName("IsCanceledBy");
        });
        modelBuilder.Entity<ChatHistoryClass>(ch =>
        {
            ch.ToTable("ChatHistoryTB");
            ch.HasKey(e=>e.ChatHistoryID);
            ch.Property(e => e.ChatHistoryID).HasColumnName("ChatHistoryID").IsRequired();
            ch.Property(e => e.AuditID).HasColumnName("AuditID").IsRequired();
            ch.Property(e => e.Messege).HasColumnName("Messege").IsRequired().HasColumnType("nvarchar(max)");
            ch.Property(e => e.ShopName).HasColumnName("ShopName").IsRequired().HasMaxLength(500);
            ch.Property(e => e.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(500);
            ch.Property(e => e.MessegeFrom).HasColumnName("MessegeFrom").IsRequired().HasMaxLength(20);
            ch.Property(e => e.ChatHistoryDate).HasColumnName("ChatHistoryDate").IsRequired();
        });
        modelBuilder.Entity<ChatAuditClass>(a =>
        {
            a.ToTable("ChatAuditTB"); // Name of the table in your database
            a.HasKey(e => e.AuditID); // Setting primary key, if applicable

            a.Property(e => e.AuditID)
                .HasColumnName("AuditID")
                .IsRequired();

            a.Property(e => e.ShopID)
                .HasColumnName("ShopID")
                .IsRequired();

            a.Property(e => e.UserID)
                .HasColumnName("UserID")
                .IsRequired();

            a.Property(e => e.AuditDate)
                .HasColumnName("AuditDate")
                .IsRequired();
        });

        modelBuilder.Entity<GetRequestInfoModel>().HasNoKey().ToView("GetRequestInfoModel");
    }
}
