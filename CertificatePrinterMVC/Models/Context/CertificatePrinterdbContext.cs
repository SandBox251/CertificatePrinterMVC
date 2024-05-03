using CertificatePrinterMVC.Models.Entity;
using CertificatePrinterMVC.Models.EntityConfigurations;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;

namespace CertificatePrinterMVC.Models.Context
{
    public class CertificatePrinterdbContext : DbContext
    {
        public CertificatePrinterdbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsersEntityConfiiguration());
        }
        public virtual DbSet<Users> Users { get; set; }
    }
}
