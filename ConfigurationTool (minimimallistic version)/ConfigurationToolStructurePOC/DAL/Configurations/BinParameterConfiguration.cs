using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class BinParameterConfiguration : EntityTypeConfiguration<BinParameter>
    {
        public BinParameterConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.bip_BinId, t.bip_ParNm });

            // Properties
            this.Property(t => t.bip_BinId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bip_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bip_ParDesc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(100);

            this.Property(t => t.bip_ParValueUOM)
                .HasMaxLength(50);

            this.Property(t => t.bip_DisplayToUser)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("bip_BinPars");
            this.Property(t => t.bip_BinId).HasColumnName("bip_BinId");
            this.Property(t => t.bip_ParNm).HasColumnName("bip_ParNm");
            this.Property(t => t.bip_ParDesc).HasColumnName("bip_ParDesc");
            this.Property(t => t.Value).HasColumnName("bip_ParValue");
            this.Property(t => t.bip_ParValueUOM).HasColumnName("bip_ParValueUOM");
            this.Property(t => t.bip_DisplayToUser).HasColumnName("bip_DisplayToUser");

            // Relationships
            this.HasRequired(t => t.Bin)
                .WithMany(t => t.BinParameters)
                .HasForeignKey(d => d.bip_BinId);

            this.HasRequired(t => t.ParameterDefinition)
                .WithMany(t => t.BinParameters)
                .HasForeignKey(d => d.bip_ParNm);
        }
    }
}
