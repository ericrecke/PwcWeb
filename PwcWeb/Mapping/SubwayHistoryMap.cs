using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PwcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Mapping
{
    public class Subway_HistoryMap : IEntityTypeConfiguration<SubwayHistory>
    {
        public void Configure(EntityTypeBuilder<SubwayHistory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Line).IsRequired().HasMaxLength(50);
            builder.ToTable("Subway_History");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Line).HasColumnName("Line");
            builder.Property(t => t.Result).HasColumnName("Result");
            builder.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
