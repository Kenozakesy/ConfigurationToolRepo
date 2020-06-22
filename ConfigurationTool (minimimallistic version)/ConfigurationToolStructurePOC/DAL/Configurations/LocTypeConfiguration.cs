using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class LocTypeConfiguration : EntityTypeConfiguration<LocType>
    {
        public LocTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.lts_LocTypeId);

            // Properties
            this.Property(t => t.lts_LocTypeId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lts_LocTypes");
            this.Property(t => t.lts_LocTypeId).HasColumnName("lts_LocTypeId");
            this.Property(t => t.lts_LocTypeNm).HasColumnName("lts_LocTypeNm");

        }
    }
}
