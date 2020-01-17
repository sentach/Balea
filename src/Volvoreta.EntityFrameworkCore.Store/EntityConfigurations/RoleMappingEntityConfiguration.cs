﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volvoreta.EntityFrameworkCore.Store.Entities;
using Volvoreta.EntityFrameworkCore.Store.Options;

namespace Volvoreta.EntityFrameworkCore.Store.EntityConfigurations
{
    internal class RoleMappingEntityConfiguration : IEntityTypeConfiguration<RoleMappingEntity>
    {
        private readonly StoreOptions options;

        public RoleMappingEntityConfiguration(StoreOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Configure(EntityTypeBuilder<RoleMappingEntity> builder)
        {
            builder.ToTable($"{options.Roles.Name}{options.Mappings.Name}");
            builder.HasKey(x => new { x.RoleId, x.MappingId });
            builder
                .HasOne(x => x.Mapping)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.MappingId);
            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Mappings)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
