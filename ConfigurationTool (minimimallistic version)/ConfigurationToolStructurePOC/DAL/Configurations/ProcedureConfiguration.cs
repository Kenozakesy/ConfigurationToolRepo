using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ProcedureConfiguration : EntityTypeConfiguration<Procedure>
    {
        public ProcedureConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.pru_ProcedureId);

            // Properties
            this.Property(t => t.pru_ProcedureId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pru_ProcedureNm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pru_ProcedureTypeId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pru_Procedures");
            this.Property(t => t.pru_ProcedureId).HasColumnName("pru_ProcedureId");
            this.Property(t => t.pru_ProcedureNm).HasColumnName("pru_ProcedureNm");
            this.Property(t => t.pru_ProcedureTypeId).HasColumnName("pru_ProcedureTypeId");
        }
    }
}
