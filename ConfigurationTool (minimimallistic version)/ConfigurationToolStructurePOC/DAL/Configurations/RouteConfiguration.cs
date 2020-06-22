using ConfigurationToolStructurePOC.Business.Model;
using System.Data.Entity.ModelConfiguration;


namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class RouteConfiguration : EntityTypeConfiguration<Route>
    {
        public RouteConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.rot_ProcesCellId, t.rot_RouteId });

            // Properties
            this.Property(t => t.rot_ProcesCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rot_RouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rot_RouteNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rot_ShortRouteNm)
                .HasMaxLength(50);

            this.Property(t => t.rot_ProcedureId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("rot_Routes");
            this.Property(t => t.rot_ProcesCellId).HasColumnName("rot_ProcCellId");
            this.Property(t => t.rot_RouteId).HasColumnName("rot_RouteId");
            this.Property(t => t.rot_RouteNm).HasColumnName("rot_RouteNm");
            this.Property(t => t.rot_ShortRouteNm).HasColumnName("rot_ShortRouteNm");
            this.Property(t => t.rot_ProcedureId).HasColumnName("rot_ProcedureId");
            this.Property(t => t.rot_Available).HasColumnName("rot_Available");
            this.Property(t => t.rot_SelectPriority).HasColumnName("rot_SelectPriority");

            // Relationships
            this.HasRequired(t => t.ProcesCell)
                .WithMany(t => t.Routes)
                .HasForeignKey(d => d.rot_ProcesCellId);
            this.HasOptional(t => t.Procedure)
                .WithMany(t => t.Routes)
                .HasForeignKey(d => d.rot_ProcedureId);
        }

    }
}

