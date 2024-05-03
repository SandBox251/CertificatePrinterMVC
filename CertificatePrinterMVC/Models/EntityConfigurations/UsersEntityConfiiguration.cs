using CertificatePrinterMVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CertificatePrinterMVC.Models.EntityConfigurations
{
    public class UsersEntityConfiiguration : IEntityTypeConfiguration <Users>
    {

        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property (t=>t.Id).UseIdentityColumn ();
        }

    }
}
