using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class ProcescellConfiguration : EntityTypeConfiguration<Procescell>
    {
        public ProcescellConfiguration()
        {
            // Primary Key
            HasKey(t => t.prc_ProcescellId);

            // Properties
            Property(t => t.prc_ProcescellId)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.prc_ProcescellNm)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.prc_ProcescellTypeId)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.prc_OABatchReqObjectNm)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            ToTable("prc_ProcCells");
            Property(t => t.prc_ProcescellId).HasColumnName("prc_ProcCellId");
            Property(t => t.prc_ProcescellNm).HasColumnName("prc_ProcCellNm");
            Property(t => t.prc_ShortProcescellNm).HasColumnName("prc_ShortProcCellNm");
            Property(t => t.prc_ProdLocked).HasColumnName("prc_ProdLocked");
            Property(t => t.prc_ProcescellTypeId).HasColumnName("prc_ProcCellTypeId");
            Property(t => t.prc_OAProcesCellId).HasColumnName("prc_OAProcCellId");
            Property(t => t.prc_OABatchReqObjectNm).HasColumnName("prc_OABatchReqObjectNm");
            Property(t => t.prc_BatchReqTypeId).HasColumnName("prc_BatchRegTypeId");
            Property(t => t.prc_BatchStartTypeId).HasColumnName("prc_BatchStartTypeId");
            Property(t => t.prc_BatchOptions).HasColumnName("prc_BatchOptions");
            Property(t => t.prc_Display).HasColumnName("prc_Display");
            Property(t => t.prc_Computer).HasColumnName("prc_Computer");

            //Relationships
            //this.HasMany(t => t.Routes)
            //.WithRequired(t => t.ProcesCell)
            //.HasForeignKey(d => d.rot_ProcesCellId)
            //.WillCascadeOnDelete(false);
        }
    }
}
