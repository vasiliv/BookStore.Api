using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
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
