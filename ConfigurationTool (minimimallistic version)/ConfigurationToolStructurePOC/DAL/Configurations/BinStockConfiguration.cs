using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class BinStockConfiguration : EntityTypeConfiguration<BinStock>
    {
        public BinStockConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.bis_BinId);

            // Properties
            this.Property(t => t.bis_BinId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("bis_BinStocks");
            this.Property(t => t.bis_BinId).HasColumnName("bis_BinId");
            this.Property(t => t.bis_Stock).HasColumnName("bis_Stock");

            // Relationships
            this.HasRequired(t => t.Bin)
                .WithOptional(t => t.BinStock);
        }
    }
}
