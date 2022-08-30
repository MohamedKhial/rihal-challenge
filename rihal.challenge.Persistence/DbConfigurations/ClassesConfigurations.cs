using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rihal.challenge.Domain.Entities;

namespace PaymentPlatform.Persistence.DbConfigurations
{
    public class ClassesConfigurations : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasMaxLength(50);

           
        }
    }



}
