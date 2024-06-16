using Class.User.UserModel;
using Class.User.CategoryModel;
using Microsoft.EntityFrameworkCore;


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
    }
}
