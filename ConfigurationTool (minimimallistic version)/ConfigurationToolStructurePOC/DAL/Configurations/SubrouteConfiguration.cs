using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class SubrouteConfiguration : EntityTypeConfiguration<Subroute>
    {
        public SubrouteConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.sur_ProcCellId, t.sur_SubRouteId });

            // Properties
            this.Property(t => t.sur_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sur_SubRouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sur_SubRouteNm)
                .IsRequired()
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("sur_SubRoutes");
            this.Property(t => t.sur_ProcCellId).HasColumnName("sur_ProcCellId");
            this.Property(t => t.sur_SubRouteId).HasColumnName("sur_SubRouteId");
            this.Property(t => t.sur_SubRouteNm).HasColumnName("sur_SubRouteNm");

            //Relationships
            this.HasRequired(t => t.Procescell)
            .WithMany(t => t.Subroutes)
            .HasForeignKey(d => d.sur_ProcCellId);
        }
    }
}
