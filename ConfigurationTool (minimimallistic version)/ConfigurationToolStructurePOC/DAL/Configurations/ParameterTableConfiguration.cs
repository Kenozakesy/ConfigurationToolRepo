using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ParameterTableConfiguration: EntityTypeConfiguration<ParameterTable>
    {
        public ParameterTableConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.pat_TableId);

            // Properties
            this.Property(t => t.pat_TableId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pat_TableDesc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.pat_Priority)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pat_ParTables");
            this.Property(t => t.pat_TableId).HasColumnName("pat_TableId");
            this.Property(t => t.pat_TableDesc).HasColumnName("pat_TableDesc");
            this.Property(t => t.pat_Priority).HasColumnName("pat_Priority");
        }
    }
}
