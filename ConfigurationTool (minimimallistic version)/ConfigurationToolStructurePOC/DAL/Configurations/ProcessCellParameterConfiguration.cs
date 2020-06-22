using ConfigurationToolStructurePOC.Business.Model.Parameters;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ProcessCellParameterConfiguration : EntityTypeConfiguration<ProcessCellParameter>
    {
        public ProcessCellParameterConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.pca_ProcCellId, t.pca_ParNm });

            // Properties
            this.Property(t => t.pca_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pca_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pca_ParDesc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(100);

            this.Property(t => t.pca_ParValueUOM)
                .HasMaxLength(50);

            this.Property(t => t.pca_DisplayToUser)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pca_ProcCellPars");
            this.Property(t => t.pca_ProcCellId).HasColumnName("pca_ProcCellId");
            this.Property(t => t.pca_ParNm).HasColumnName("pca_ParNm");
            this.Property(t => t.pca_ParDesc).HasColumnName("pca_ParDesc");
            this.Property(t => t.Value).HasColumnName("pca_ParValue");
            this.Property(t => t.pca_ParValueUOM).HasColumnName("pca_ParValueUOM");
            this.Property(t => t.pca_DisplayToUser).HasColumnName("pca_DisplayToUser");

            // Relationships
            this.HasRequired(t => t.ProcessCell)
                .WithMany(t => t.ProcessCellParameters)
                .HasForeignKey(d => d.pca_ProcCellId);

            this.HasRequired(t => t.ParameterDefinition)
                .WithMany(t => t.ProcessCellParameters)
                .HasForeignKey(d => d.pca_ParNm);
        }
    }
}
