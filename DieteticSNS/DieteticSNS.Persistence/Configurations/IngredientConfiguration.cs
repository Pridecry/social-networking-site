using DieteticSNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DieteticSNS.Persistence.Configurations
{
    class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Protein).HasDefaultValue(0);
            builder.Property(x => x.Carbohydrate).HasDefaultValue(0);
            builder.Property(x => x.Fat).HasDefaultValue(0);
        }
    }
}
