﻿using Codidact.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codidact.Core.Infrastructure.Persistence.Configuration
{
    public class SettingHistoryConfiguration : IEntityTypeConfiguration<SettingHistory>
    {
        public void Configure(EntityTypeBuilder<SettingHistory> entity)
        {
            entity.HasKey(e => e.HistoryId)
                .HasName("setting_history_pk");

            entity.Property(e => e.HistoryId)
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()");

            entity.Property(e => e.HistoryActivityAt)
                .HasDefaultValueSql("now()");

            entity.Property(e => e.LastModifiedAt)
                .HasDefaultValueSql("now()");

            entity.HasOne(d => d.HistoryActivityMember)
                .WithMany(p => p.SettingHistory)
                .HasForeignKey(d => d.HistoryActivityMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("setting_history_member_fk");

        }
    }
}
