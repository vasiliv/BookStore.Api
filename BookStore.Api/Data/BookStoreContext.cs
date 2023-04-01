using BookStore.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    //because we are using both Identity and DbContext
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        //No need any more, because we defined everythin in Startup.cs
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=BookStoreApi;Trusted_Connection=True;MultipleActiveResultSets=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
