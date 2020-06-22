using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ParameterDefinitionProcessCellTypeConfiguration : EntityTypeConfiguration<ParameterDefinitionProcessCellType>
    {
        public ParameterDefinitionProcessCellTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.pac_ParNm, t.pac_ProcCellTypeId });

            // Properties
            this.Property(t => t.pac_ParNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pac_ProcCellTypeId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pac_ParDefsProcCellTypes");
            this.Property(t => t.pac_ParNm).HasColumnName("pac_ParNm");
            this.Property(t => t.pac_ProcCellTypeId).HasColumnName("pac_ProcCellTypeId");
            this.Property(t => t.pac_IsRequired).HasColumnName("pac_IsRequired");

            // Relationships
            this.HasRequired(t => t.ParameterDefinition)
                .WithMany(t => t.ParameterDefinitionProcessCellTypes)
                .HasForeignKey(d => d.pac_ParNm);
            //this.HasRequired(t => t.pct_ProcCellTypes)
            //    .WithMany(t => t.pac_ParDefsProcCellTypes)
            //    .HasForeignKey(d => d.pac_ProcCellTypeId);
        }
    }
}
