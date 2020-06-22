using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class SubroutesInRouteConfiguration : EntityTypeConfiguration<SubroutesInRoute>
    {
        public SubroutesInRouteConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.sri_ProcCellId, t.sri_RouteId, t.sri_SubRouteId });

            // Properties
            this.Property(t => t.sri_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sri_RouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sri_SubRouteId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("sri_SubRoutesInRoutes");
            this.Property(t => t.sri_ProcCellId).HasColumnName("sri_ProcCellId");
            this.Property(t => t.sri_RouteId).HasColumnName("sri_RouteId");
            this.Property(t => t.sri_SubRouteId).HasColumnName("sri_SubRouteId");
            this.Property(t => t.sri_SeqNr).HasColumnName("sri_SeqNr");

            // Relationships
            this.HasRequired(t => t.Route)
                .WithMany(t => t.SubroutesInRoutes)
                .HasForeignKey(d => new { d.sri_ProcCellId, d.sri_RouteId });

            this.HasRequired(t => t.Subroute)
                .WithMany(t => t.SubroutesInRoutes)
                .HasForeignKey(d => new { d.sri_ProcCellId, d.sri_SubRouteId });

        }
    }
}
