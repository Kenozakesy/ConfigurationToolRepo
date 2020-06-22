using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class OAUnitDefinitionConfiguration: EntityTypeConfiguration<OAUnitDefinition>
    {
        public OAUnitDefinitionConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.oud_OAUnitId);

            // Properties
            this.Property(t => t.oud_OAUnitId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.oud_OAUnitPUObjectNm)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.oud_OAOperPUObjectNm)
                .HasMaxLength(256);

            this.Property(t => t.oud_OAUnitAllocNm)
                .HasMaxLength(256);

            this.Property(t => t.oud_OAUnitCntObjectNm)
                .HasMaxLength(256);

            this.Property(t => t.oud_OAPropEMObjectNm)
                .HasMaxLength(256);

            this.Property(t => t.oud_OAIndObjectNm)
                .HasMaxLength(256);

            this.Property(t => t.oud_ImplementedIFs)
                .HasMaxLength(50);

            this.Property(t => t.oud_UnitNm)
                .HasMaxLength(50);

            this.Property(t => t.oud_UnitRoles)
                .HasMaxLength(50);

            this.Property(t => t.oud_BatchRegTypeId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("oud_OAUnitDefs");
            this.Property(t => t.oud_OAUnitId).HasColumnName("oud_OAUnitId");
            this.Property(t => t.oud_OAUnitPUObjectNm).HasColumnName("oud_OAUnitPUObjectNm");
            this.Property(t => t.oud_OAOperPUObjectNm).HasColumnName("oud_OAOperPUObjectNm");
            this.Property(t => t.oud_OAUnitAllocNm).HasColumnName("oud_OAUnitAllocNm");
            this.Property(t => t.oud_OAUnitCntObjectNm).HasColumnName("oud_OAUnitCntObjectNm");
            this.Property(t => t.oud_OAPropEMObjectNm).HasColumnName("oud_OAPropEMObjectNm");
            this.Property(t => t.oud_OAIndObjectNm).HasColumnName("oud_OAIndObjectNm");
            this.Property(t => t.oud_ImplementedIFs).HasColumnName("oud_ImplementedIFs");
            this.Property(t => t.oud_UnitNm).HasColumnName("oud_UnitNm");
            this.Property(t => t.oud_UnitRoles).HasColumnName("oud_UnitRoles");
            this.Property(t => t.oud_BatchRegTypeId).HasColumnName("oud_BatchRegTypeId");
            this.Property(t => t.oud_IsUnit).HasColumnName("oud_IsUnit");
            this.Property(t => t.oud_IsTransportHandler).HasColumnName("oud_IsTransportHandler");
            this.Property(t => t.oud_OAUnitInTransportHandler).HasColumnName("oud_OAUnitInTransportHandler");
        }
    }
}
