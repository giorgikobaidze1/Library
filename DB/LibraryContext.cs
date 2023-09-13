using Library1.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library1.DB
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
        {
        }

        public DbSet<Author> authors { get; set; }
        public DbSet<AuthorPersonallInfo> authorPersonallInfos { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<BookGenre> bookGenres { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> userRoles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<Role>().HasKey(x=> x.Id);

            modelBuilder.Entity<UserRole>().HasKey(x=> new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRole>().HasOne(x=> x.User).WithMany(x=> x.userRoles).HasForeignKey(x=>x.UserId);

            modelBuilder.Entity<UserRole>().HasOne(x => x.Role).WithMany(x => x.RoleUsers).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Author>().Property(x=> x.FirsName).IsRequired();
            modelBuilder.Entity<Author>().Property(x => x.LastName).IsRequired();
            

            modelBuilder.Entity<Author>().HasOne(x => x.AuthorPersonallInfo).WithOne(x=> x.Author)
                .HasForeignKey<AuthorPersonallInfo>(x => x.AuthorId);

            modelBuilder.Entity<AuthorPersonallInfo>().HasKey(x=> x.Id);

           

            modelBuilder.Entity<Book>().HasKey(x=> x.Id);
            modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.authorId);
            modelBuilder.Entity<Book>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Book>().Property(x=> x.Description).IsRequired();

            modelBuilder.Entity<Genre>().HasKey(x => x.Id);
            modelBuilder.Entity<Genre>().ToTable(nameof(Genre)); 

            modelBuilder.Entity<BookGenre>().HasKey(x => new {x.bookId, x.GreneId});

            modelBuilder.Entity<BookGenre>().HasOne(x=> x.Book).WithMany(x=> x.bookGenres).HasForeignKey(x=> x.bookId);

            modelBuilder.Entity<BookGenre>().HasOne(x => x.Grene).WithMany(x => x.GenreBook)
                .HasForeignKey(x => x.GreneId);





        }
    }
}
