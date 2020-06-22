using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    class ParameterDefinitionConfiguration : EntityTypeConfiguration<ParameterDefinition>
    {
        public ParameterDefinitionConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.paf_ParNm);

            // Properties
            this.Property(t => t.paf_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.paf_ParDesc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.paf_ParValueUOM)
                .HasMaxLength(50);

            this.Property(t => t.paf_ValidValues)
                .HasMaxLength(1000);

            this.Property(t => t.paf_DefValue)
                .HasMaxLength(100);

            this.Property(t => t.paf_ParUOM_TextId)
                .HasMaxLength(30);

            this.Property(t => t.paf_DisplayToUser)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("paf_ParDefs");
            this.Property(t => t.paf_ParNm).HasColumnName("paf_ParNm");
            this.Property(t => t.paf_ParDesc).HasColumnName("paf_ParDesc");
            this.Property(t => t.paf_ParValueUOM).HasColumnName("paf_ParValueUOM");
            this.Property(t => t.paf_BeforeSep).HasColumnName("paf_BeforeSep");
            this.Property(t => t.paf_AfterSep).HasColumnName("paf_AfterSep");
            this.Property(t => t.paf_ValidValues).HasColumnName("paf_ValidValues");
            this.Property(t => t.paf_DefValue).HasColumnName("paf_DefValue");
            this.Property(t => t.paf_Type).HasColumnName("paf_Type");
            this.Property(t => t.paf_Alignm).HasColumnName("paf_Alignm");
            this.Property(t => t.paf_Editable).HasColumnName("paf_Editable");
            this.Property(t => t.paf_DisplaySeqNr).HasColumnName("paf_DisplaySeqNr");
            this.Property(t => t.paf_DisplayWidth).HasColumnName("paf_DisplayWidth");
            this.Property(t => t.paf_ParUOM_TextId).HasColumnName("paf_ParUOM_TextId");
            this.Property(t => t.paf_DisplayToUser).HasColumnName("paf_DisplayToUser");
            this.Property(t => t.paf_Column).HasColumnName("paf_Column");
            this.Property(t => t.paf_IsStandardPar).HasColumnName("paf_IsStandardPar");
        }
    }
}
