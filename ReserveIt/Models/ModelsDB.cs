using Microsoft.EntityFrameworkCore;

namespace ReserveIt.Models
{
    public class ModelsDB : DbContext
    {
        public ModelsDB(DbContextOptions<ModelsDB> options) : base(options)

        {

        }
        public DbSet<MyMessages> MyMessages { get; set; }
    }
    public class MyMessages
    {
        public int Id { get; set; }
        public string Words { get; set; }
    }
}
