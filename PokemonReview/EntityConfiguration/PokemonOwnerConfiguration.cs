﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReview.Data;

namespace PokemonReview.EntityConfiguration;

public class PokemonOwnerConfiguration : IEntityTypeConfiguration<PokemonOwner>
{
    public void Configure(EntityTypeBuilder<PokemonOwner> builder)
    {
        builder.HasKey(po => new {po.PokemonId, po.OwnerId });
        builder.HasOne(po => po.Pokemon)
            .WithMany(p => p.PokemonOwners)
            .HasForeignKey(po => po.PokemonId);
        builder.HasOne(po => po.Owner)
            .WithMany(o => o.PokemonOwners)
            .HasForeignKey(po => po.OwnerId);
    }
}