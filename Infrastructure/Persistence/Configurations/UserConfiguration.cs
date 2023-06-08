using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


            builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);




            builder.Property(e => e.Name)
                      .IsRequired();

           


            builder.Property(e => e.StreetId).IsRequired();



        }
    }
}
