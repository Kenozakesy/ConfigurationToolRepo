using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class OAProcessCellDefinitionConfiguration : EntityTypeConfiguration<OAProcessCellDefinition>
    {
        public OAProcessCellDefinitionConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.opc_ProcCellId, t.opc_RouteId, t.opc_OAProcCellPUObjectNm });

            // Properties
            this.Property(t => t.opc_ProcCellId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.opc_RouteId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.opc_OAProcCellPUObjectNm)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.opc_OAProcCellBatchInfo)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.opc_BatchNm)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("opc_OAProcCellDefs");
            this.Property(t => t.opc_ProcCellId).HasColumnName("opc_ProcCellId");
            this.Property(t => t.opc_RouteId).HasColumnName("opc_RouteId");
            this.Property(t => t.opc_OAProcCellPUObjectNm).HasColumnName("opc_OAProcCellPUObjectNm");
            this.Property(t => t.opc_OAProcCellBatchInfo).HasColumnName("opc_OAProcCellBatchInfo");
            this.Property(t => t.opc_OAProcCellColor).HasColumnName("opc_OAProcCellColor");
            this.Property(t => t.opc_BatchNm).HasColumnName("opc_BatchNm");

            // Relationships
            this.HasRequired(t => t.Route)
                .WithMany(t => t.OAProcessCellDefinitions)
                .HasForeignKey(d => new { d.opc_ProcCellId, d.opc_RouteId });
        }

    }
}
