using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReview.Data;

namespace PokemonReview.EntityConfiguration;

public class PokemonCategoryConfiguration : IEntityTypeConfiguration<PokemonCategory>
{
    public void Configure(EntityTypeBuilder<PokemonCategory> builder)
    {   
        builder.HasKey(pc => new {pc.PokemonId, pc.CategoryId });
        builder.HasOne(p => p.Pokemon)
            .WithMany(p => p.PokemonCategories)
            .HasForeignKey(pc => pc.PokemonId);
        builder.HasOne(c => c.Category)
            .WithMany(c => c.PokemonCategories)
            .HasForeignKey(pc => pc.CategoryId);
    }
}