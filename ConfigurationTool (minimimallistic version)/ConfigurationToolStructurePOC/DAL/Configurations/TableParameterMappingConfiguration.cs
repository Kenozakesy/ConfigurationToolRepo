using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class TableParameterMappingConfiguration : EntityTypeConfiguration<TableParameterMapping>
    {
        public TableParameterMappingConfiguration(){
             // Primary Key
            this.HasKey(t => new { t.tpm_ParNm, t.tpm_TableId });

            // Properties
            this.Property(t => t.tpm_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.tpm_TableId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tpm_TableParMaps");
            this.Property(t => t.tpm_ParNm).HasColumnName("tpm_ParNm");
            this.Property(t => t.tpm_TableId).HasColumnName("tpm_TableId");
            this.Property(t => t.tpm_MappingIsEnabled).HasColumnName("tpm_MappingIsEnabled");

            // Relationships
            this.HasRequired(t => t.ParameterDefinition)
                .WithMany(t => t.TableParameterMappings)
                .HasForeignKey(d => d.tpm_ParNm);
            this.HasRequired(t => t.ParameterTable)
                .WithMany(t => t.TableParameterMappings)
                .HasForeignKey(d => d.tpm_TableId);
        }
    }
}
