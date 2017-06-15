using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class SeatContext : DbContext
    {
        public DbSet<Seat> Seats { get;set; }

        public SeatContext(DbContextOptions<SeatContext> options)
            : base(options) { }
    }
}