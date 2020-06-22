using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Bin : TreeViewObject
    {
        #region Fields

        private ObservableCollection<BinsInSubRoute> _BinsInSubRoute = new ObservableCollection<BinsInSubRoute>();

        #endregion

        public Bin()
        {
            //this.BinBatches = new List<BinBatch>();
            //this.BinPars = new List<BinPar>();
            //this.BinsInSubRoutes = new List<BinsInSubRoute>();
            //this.PropInstruments = new List<PropIns>();
            //this.TempBinBatches = new List<TempBinBatch>();
        }

        public Bin(string id, string bintype)
        {
            bin_BinId = id;
            bin_LocTypeId = bintype;

            bin_Cap = 0;
            bin_Stock = 0;
            bin_StatusFill = "1";
            bin_StatusDisc = "1";
            bin_PropPrioNr = 1;
            bin_PropPosSeqNr = 1;
            bin_NoFlowDetected = 0;
            bin_MaxLevel = 0;
            bin_CallLevel = 0;
            bin_MinLevel = 0;
            bin_LevelUOM = "m3";
            bin_DefViewSequence = 1;
            bin_DeclaredEmpty = "0";
            bin_EmptyInterval = 50;
            bin_EmptyControl = 1;
            bin_BinBlocked = "0";
            bin_BinGroupId = "0";
        }

        public string bin_BinId { get; set; }
        public string bin_BinNm { get; set; }
        public string bin_ArtId { get; set; }
        public Nullable<double> bin_Cap { get; set; }
        public double bin_Stock { get; set; }
        public string bin_StatusFill { get; set; }
        public string bin_StatusDisc { get; set; }
        public int bin_PropPrioNr { get; set; }
        public Nullable<System.DateTime> bin_DateEmpty { get; set; }
        public Nullable<System.DateTime> bin_TimeEmpty { get; set; }
        public Nullable<System.DateTime> bin_DateCleaned { get; set; }
        public Nullable<System.DateTime> bin_TimeCleaned { get; set; }
        public Nullable<System.DateTime> bin_DateFilledUp { get; set; }
        public Nullable<System.DateTime> bin_TimeFilledUp { get; set; }
        public string bin_ProdOrderId { get; set; }
        public int bin_PropPosSeqNr { get; set; }
        public Nullable<int> bin_NoFlowDetected { get; set; }
        public string bin_LocTypeId { get; set; }
        public Nullable<double> bin_MaxLevel { get; set; }
        public Nullable<double> bin_CallLevel { get; set; }
        public Nullable<double> bin_MinLevel { get; set; }
        public string bin_LevelUOM { get; set; }
        public string bin_OccupControler { get; set; }
        public string bin_StockControler { get; set; }
        public Nullable<int> bin_DefViewSequence { get; set; }
        public string bin_OptRcp { get; set; }
        public string bin_OAObjectNm { get; set; }
        public string bin_DeclaredEmpty { get; set; }
        public Nullable<int> bin_IsFGBin { get; set; }
        public Nullable<int> bin_IsSemiFinishedBin { get; set; }
        public string bin_Options { get; set; }
        public string bin_LocBatchId { get; set; }
        public string bin_BinDivideCode { get; set; }
        public string bin_LocTypeFeedtrac { get; set; }
        public int bin_EmptyInterval { get; set; }
        public int bin_EmptyControl { get; set; }
        public string bin_BinBlocked { get; set; }
        public string bin_BinGroupId { get; set; }
        public string bin_WareHouseId { get; set; }
        public Nullable<double> bin_DimLStraight { get; set; }
        public Nullable<double> bin_DimLAngled { get; set; }
        public Nullable<double> bin_DimAMax { get; set; }
        public Nullable<double> bin_DimAMin { get; set; }
        public string bin_WareHousePositionId { get; set; }
        //public virtual ICollection<BinBatch> BinBatches { get; set; }
        //public virtual WareHouse WareHouse { get; set; }
        public virtual ICollection<BinParameter> BinParameters { get; set; }
        public virtual ObservableCollection<BinsInSubRoute> BinsInSubRoutes
        {
            get { return _BinsInSubRoute; }
            set { SetProperty(ref _BinsInSubRoute, value); } 
        }
        public virtual ICollection<OAUnitDefinition> OAUnitDefinitions { get; set; }
        public virtual BinStock BinStock { get; set; }
        //public virtual ContainerProperty ContainerProperty { get; set; }
        //public virtual ICollection<PropIns> PropInstruments { get; set; }
        //public virtual ICollection<TempBinBatch> TempBinBatches { get; set; }

        #region Properties


        //public string prc_ProcescellId 
        //{
        //    get { return _prc_ProcCellId; }
        //    set { SetProperty(ref _prc_ProcCellId, value); } 
        //}

        #endregion


        #region Override

        public override void DeleteTreeViewObject()
        {
            BinService service = new BinService();
            service.DeleteBin(this);
            service.RemoveRelationShips(this);
        }

        public override int CompareTo(object obj)
        {
            Bin bin = obj as Bin;
            return string.Compare(this.bin_BinId, bin.bin_BinId);
        }

        public override string GetName()
        {
            return "";
        }

        #endregion

    }
}
