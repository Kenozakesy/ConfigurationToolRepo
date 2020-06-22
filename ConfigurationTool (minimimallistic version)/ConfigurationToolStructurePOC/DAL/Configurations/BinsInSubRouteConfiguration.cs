using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class BinsInSubRouteConfiguration : EntityTypeConfiguration<BinsInSubRoute>
    {
        public BinsInSubRouteConfiguration(){
            // Primary Key
            this.HasKey(t => new { t.bir_ProcCellId, t.bir_SubRouteId, t.bir_SourceDest, t.bir_BinId });

            // Properties
            this.Property(t => t.bir_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bir_SubRouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bir_SourceDest)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bir_BinId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("bir_BinsInSubRoutes");
            this.Property(t => t.bir_ProcCellId).HasColumnName("bir_ProcCellId");
            this.Property(t => t.bir_SubRouteId).HasColumnName("bir_SubRouteId");
            this.Property(t => t.bir_SourceDest).HasColumnName("bir_SourceDest");
            this.Property(t => t.bir_BinId).HasColumnName("bir_BinId");

            // Relationships
            this.HasRequired(t => t.Bin)
                .WithMany(t => t.BinsInSubRoutes)
                .HasForeignKey(d => d.bir_BinId);
            this.HasRequired(t => t.Subroute)
               .WithMany(t => t.BinsInSubRoutes)
               .HasForeignKey(d => new { d.bir_ProcCellId, d.bir_SubRouteId });
        }
    }
}
