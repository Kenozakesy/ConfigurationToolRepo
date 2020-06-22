using ConfigurationToolStructurePOC.Business.Model.Parameters;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class RouteParameterConfiguration : EntityTypeConfiguration<RouteParameter>
    {
        public RouteParameterConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.rop_ProcCellId, t.rop_RouteId, t.rop_ParNm });

            // Properties
            this.Property(t => t.rop_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rop_RouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rop_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rop_ParDesc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(100);

            this.Property(t => t.rop_ParValueUOM)
                .HasMaxLength(50);

            this.Property(t => t.rop_DisplayToUser)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("rop_RoutePars");
            this.Property(t => t.rop_ProcCellId).HasColumnName("rop_ProcCellId");
            this.Property(t => t.rop_RouteId).HasColumnName("rop_RouteId");
            this.Property(t => t.rop_ParNm).HasColumnName("rop_ParNm");
            this.Property(t => t.rop_ParDesc).HasColumnName("rop_ParDesc");
            this.Property(t => t.Value).HasColumnName("rop_ParValue");
            this.Property(t => t.rop_ParValueUOM).HasColumnName("rop_ParValueUOM");
            this.Property(t => t.rop_DisplayToUser).HasColumnName("rop_DisplayToUser");

            // Relationships
            this.HasRequired(t => t.Route)
                .WithMany(t => t.RouteParameters)
                .HasForeignKey(d => new { d.rop_ProcCellId, d.rop_RouteId });

            this.HasRequired(t => t.ParameterDefinition)
               .WithMany(t => t.RouteParameters)
               .HasForeignKey(d => d.rop_ParNm);
        }

    }
}
