using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Infrastructure.Repos
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars", "cars");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Vin, "vin_idx").IsUnique();
        }
    }
}
