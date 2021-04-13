using Microsoft.EntityFrameworkCore;

namespace FiledPaymentService.DB
{
    public class FiledDbContext : DbContext
    {
        public FiledDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
    }
}
