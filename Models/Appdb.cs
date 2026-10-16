
using Microsoft.EntityFrameworkCore;
using WebAppi.Models;

namespace WebAppi.Models
{
    public class Appdb : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectModels;Initial Catalog=db_webappi;Integrated Security=true;TrustServerCertificate=true"
            );
        }

        public DbSet<TrainBooking> TrainBookings { get; set; }
    }
}
