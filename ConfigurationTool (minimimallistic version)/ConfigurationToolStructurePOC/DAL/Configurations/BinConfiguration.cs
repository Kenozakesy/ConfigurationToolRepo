using ConfigurationToolStructurePOC.Business.Model;
using System.Data.Entity.ModelConfiguration;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class BinConfiguration : EntityTypeConfiguration<Bin>
    {
        public BinConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.bin_BinId);

            // Properties
            this.Property(t => t.bin_BinId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_BinNm)
                .HasMaxLength(50);

            this.Property(t => t.bin_ArtId)
                .HasMaxLength(50);

            this.Property(t => t.bin_StatusFill)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_StatusDisc)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_ProdOrderId)
                .HasMaxLength(50);

            this.Property(t => t.bin_LocTypeId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_LevelUOM)
                .HasMaxLength(50);

            this.Property(t => t.bin_OccupControler)
                .HasMaxLength(50);

            this.Property(t => t.bin_StockControler)
                .HasMaxLength(50);

            this.Property(t => t.bin_OptRcp)
                .HasMaxLength(50);

            this.Property(t => t.bin_OAObjectNm)
                .HasMaxLength(256);

            this.Property(t => t.bin_DeclaredEmpty)
                .HasMaxLength(50);

            this.Property(t => t.bin_Options)
                .HasMaxLength(50);

            this.Property(t => t.bin_LocBatchId)
                .HasMaxLength(50);

            this.Property(t => t.bin_BinDivideCode)
                .HasMaxLength(50);

            this.Property(t => t.bin_LocTypeFeedtrac)
                .HasMaxLength(50);

            this.Property(t => t.bin_BinBlocked)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_BinGroupId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.bin_WareHouseId)
                .HasMaxLength(50);

            this.Property(t => t.bin_WareHousePositionId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("bin_Bins");
            this.Property(t => t.bin_BinId).HasColumnName("bin_BinId");
            this.Property(t => t.bin_BinNm).HasColumnName("bin_BinNm");
            this.Property(t => t.bin_ArtId).HasColumnName("bin_ArtId");
            this.Property(t => t.bin_Cap).HasColumnName("bin_Cap");
            this.Property(t => t.bin_Stock).HasColumnName("bin_Stock");
            this.Property(t => t.bin_StatusFill).HasColumnName("bin_StatusFill");
            this.Property(t => t.bin_StatusDisc).HasColumnName("bin_StatusDisc");
            this.Property(t => t.bin_PropPrioNr).HasColumnName("bin_PropPrioNr");
            this.Property(t => t.bin_DateEmpty).HasColumnName("bin_DateEmpty");
            this.Property(t => t.bin_TimeEmpty).HasColumnName("bin_TimeEmpty");
            this.Property(t => t.bin_DateCleaned).HasColumnName("bin_DateCleaned");
            this.Property(t => t.bin_TimeCleaned).HasColumnName("bin_TimeCleaned");
            this.Property(t => t.bin_DateFilledUp).HasColumnName("bin_DateFilledUp");
            this.Property(t => t.bin_TimeFilledUp).HasColumnName("bin_TimeFilledUp");
            this.Property(t => t.bin_ProdOrderId).HasColumnName("bin_ProdOrderId");
            this.Property(t => t.bin_PropPosSeqNr).HasColumnName("bin_PropPosSeqNr");
            this.Property(t => t.bin_NoFlowDetected).HasColumnName("bin_NoFlowDetected");
            this.Property(t => t.bin_LocTypeId).HasColumnName("bin_LocTypeId");
            this.Property(t => t.bin_MaxLevel).HasColumnName("bin_MaxLevel");
            this.Property(t => t.bin_CallLevel).HasColumnName("bin_CallLevel");
            this.Property(t => t.bin_MinLevel).HasColumnName("bin_MinLevel");
            this.Property(t => t.bin_LevelUOM).HasColumnName("bin_LevelUOM");
            this.Property(t => t.bin_OccupControler).HasColumnName("bin_OccupControler");
            this.Property(t => t.bin_StockControler).HasColumnName("bin_StockControler");
            this.Property(t => t.bin_DefViewSequence).HasColumnName("bin_DefViewSequence");
            this.Property(t => t.bin_OptRcp).HasColumnName("bin_OptRcp");
            this.Property(t => t.bin_OAObjectNm).HasColumnName("bin_OAObjectNm");
            this.Property(t => t.bin_DeclaredEmpty).HasColumnName("bin_DeclaredEmpty");
            this.Property(t => t.bin_IsFGBin).HasColumnName("bin_IsFGBin");
            this.Property(t => t.bin_IsSemiFinishedBin).HasColumnName("bin_IsSemiFinishedBin");
            this.Property(t => t.bin_Options).HasColumnName("bin_Options");
            this.Property(t => t.bin_LocBatchId).HasColumnName("bin_LocBatchId");
            this.Property(t => t.bin_BinDivideCode).HasColumnName("bin_BinDivideCode");
            this.Property(t => t.bin_LocTypeFeedtrac).HasColumnName("bin_LocTypeFeedtrac");
            this.Property(t => t.bin_EmptyInterval).HasColumnName("bin_EmptyInterval");
            this.Property(t => t.bin_EmptyControl).HasColumnName("bin_EmptyControl");
            this.Property(t => t.bin_BinBlocked).HasColumnName("bin_BinBlocked");
            this.Property(t => t.bin_BinGroupId).HasColumnName("bin_BinGroupId");
            this.Property(t => t.bin_WareHouseId).HasColumnName("bin_WareHouseId");
            this.Property(t => t.bin_DimLStraight).HasColumnName("bin_DimLStraight");
            this.Property(t => t.bin_DimLAngled).HasColumnName("bin_DimLAngled");
            this.Property(t => t.bin_DimAMax).HasColumnName("bin_DimAMax");
            this.Property(t => t.bin_DimAMin).HasColumnName("bin_DimAMin");
            this.Property(t => t.bin_WareHousePositionId).HasColumnName("bin_WareHousePositionId");

            // Relationships
            this.HasMany(t => t.OAUnitDefinitions)
               .WithMany(t => t.Bins)
               .Map(m =>
               {
                   m.ToTable("biu_BinInUnits");
                   m.MapLeftKey("biu_BinID");
                   m.MapRightKey("biu_OAUnitID");
               });

            //this.HasOptional(t => t.WareHouse)
            //    .WithMany(t => t.Bins)
            //    .HasForeignKey(d => d.bin_WareHouseId);
        }
    }
}
