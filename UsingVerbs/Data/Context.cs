using Microsoft.EntityFrameworkCore;
using UsingVerbs.Model;

namespace UsingVerbs.Data
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }

        public Context(DbContextOptions options) : base(options){}

    }
}
