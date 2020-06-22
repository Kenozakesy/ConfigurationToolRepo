using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class UnitsInSubRouteConfiguration: EntityTypeConfiguration<UnitsInSubRoute>
    {
        public UnitsInSubRouteConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.uis_ProcCellId, t.uis_SubRouteId, t.uis_OAUnitId });

            // Properties
            this.Property(t => t.uis_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.uis_SubRouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.uis_OAUnitId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("uis_UnitsInSubRoutes");
            this.Property(t => t.uis_ProcCellId).HasColumnName("uis_ProcCellId");
            this.Property(t => t.uis_SubRouteId).HasColumnName("uis_SubRouteId");
            this.Property(t => t.uis_OAUnitId).HasColumnName("uis_OAUnitId");
            this.Property(t => t.uis_SeqNr).HasColumnName("uis_SeqNr");
            this.Property(t => t.uis_IsTransporthandlerUnit).HasColumnName("uis_IsTransporthandlerUnit");

             //Relationships
            this.HasRequired(t => t.SubRoute)
               .WithMany(t => t.UnitsInSubRoutes)
               .HasForeignKey(d => new { d.uis_ProcCellId, d.uis_SubRouteId });

            this.HasRequired(t => t.Unit)
                .WithMany(t => t.UnitsInSubroute)
                .HasForeignKey(d => d.uis_OAUnitId);
        }
    }
}
