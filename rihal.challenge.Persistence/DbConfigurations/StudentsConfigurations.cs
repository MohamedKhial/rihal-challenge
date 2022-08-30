using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rihal.challenge.Domain.Entities;

namespace PaymentPlatform.Persistence.DbConfigurations
{
    public class StudentsConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasMaxLength(50);

            builder.HasOne(x => x.Country).WithMany(x => x.Students).HasForeignKey(x => x.CountryId);
            builder.HasOne(x => x.Class).WithMany(x => x.Students).HasForeignKey(x => x.ClassId);
        }
    }



}
