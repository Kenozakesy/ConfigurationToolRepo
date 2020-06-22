using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ProcessCellParameterMappingConfiguration : EntityTypeConfiguration<ProcessCellParameterMapping>
    {
        public ProcessCellParameterMappingConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.ppr_ProcCellId, t.ppr_RouteId, t.ppr_ParNm, t.ppr_UniqueId });

            // Properties
            this.Property(t => t.ppr_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_RouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_UniqueId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ppr_ParType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_HeaderPropDest)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_ParScope)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ppr_OAUnitId)
                .HasMaxLength(50);

            this.Property(t => t.ppr_MapToParNm)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ppr_ProcParMaps");
            this.Property(t => t.ppr_ProcCellId).HasColumnName("ppr_ProcCellId");
            this.Property(t => t.ppr_RouteId).HasColumnName("ppr_RouteId");
            this.Property(t => t.ppr_ParNm).HasColumnName("ppr_ParNm");
            this.Property(t => t.ppr_UniqueId).HasColumnName("ppr_UniqueId");
            this.Property(t => t.ppr_ParType).HasColumnName("ppr_ParType");
            this.Property(t => t.ppr_HeaderPropDest).HasColumnName("ppr_HeaderPropDest");
            this.Property(t => t.ppr_ParScope).HasColumnName("ppr_ParScope");
            this.Property(t => t.ppr_OAUnitId).HasColumnName("ppr_OAUnitId");
            this.Property(t => t.ppr_MapToParNm).HasColumnName("ppr_MapToParNm");
            this.Property(t => t.ppr_MustBeFilled).HasColumnName("ppr_MustBeFilled");

            // Relationships
            this.HasRequired(t => t.ParameterDefinition)
                .WithMany(t => t.ProcessCellParameterMappings)
                .HasForeignKey(d => d.ppr_ParNm);

            ////TODO - Nodig?
            //this.HasRequired(t => t.ppr_HeaderPropDest)
            //    .WithMany(t => t.ppr_ProcParMaps)
            //    .HasForeignKey(d => new { d.ppr_ProcCellId, d.ppr_RouteId });

        }
    }
}
