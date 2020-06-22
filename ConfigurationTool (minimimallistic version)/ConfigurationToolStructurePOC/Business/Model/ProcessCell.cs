using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.Business.Statics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Procescell : TreeViewObject
    {
        #region Fields

        private string _prc_ProcCellId;
        private string _prc_ProcCellNm;
        private string _prc_ShortProcescellNm;
        private bool _prc_ProdLocked;
        private string _prc_ProcescellTypeId;
        private string _prc_OAProcesCellId;
        private string _prc_OABatchReqObjectNm;
        private string _prc_BatchReqTypeId;
        private string _prc_BatchStartTypeId;
        private string _prc_BatchOptions;
        private string _prc_Display;
        private string _prc_Computer;

        private ObservableCollection<Route> _Routes = new ObservableCollection<Route>();

        #endregion

        public Procescell()
        {
            Routes = new ObservableCollection<Route>();
            Subroutes = new ObservableCollection<Subroute>();
            ProcessCellParameters = new ObservableCollection<ProcessCellParameter>();
        }

        public Procescell(ProcescellType type, int firstavailableNumber)
        {        
            prc_ProcescellId = type.ToString() + firstavailableNumber;
            prc_ProcescellNm = Enumerations.GetEnumDescription(type) + " " + firstavailableNumber;
            prc_ShortProcescellNm = type.ToString() + firstavailableNumber;
            prc_ProdLocked = false;
            prc_ProcescellTypeId = type.ToString();
            prc_OAProcesCellId = "pc" + type.ToString() + "" + firstavailableNumber;
            prc_OABatchReqObjectNm = "Customer."+ Enumerations.GetEnumDescription(type) + ".pc" + type.ToString() + firstavailableNumber + ".General.scBatchRequest" + type.ToString() + firstavailableNumber;
            prc_BatchReqTypeId = "DC";
            prc_BatchStartTypeId = "Scheduled";
            prc_BatchOptions = "";
            prc_Display = "1";

            Routes = new ObservableCollection<Route>();
            Subroutes = new ObservableCollection<Subroute>();
            ProcessCellParameters = new ObservableCollection<ProcessCellParameter>();
        }

        #region Properties
        public virtual ObservableCollection<Route> Routes
        {
            get { return _Routes; }
            set { SetProperty(ref _Routes, value); } 
        }
        public virtual ObservableCollection<Subroute> Subroutes { get; set; }
        public virtual ObservableCollection<ProcessCellParameter> ProcessCellParameters
        { get; set; }
        
        public string prc_ProcescellId 
        {
            get { return _prc_ProcCellId; }
            set { SetProperty(ref _prc_ProcCellId, value); } 
        }
        public string prc_ProcescellNm
        {
            get { return _prc_ProcCellNm; }
            set { SetProperty(ref _prc_ProcCellNm, value); }
        }
        public string prc_ShortProcescellNm
        {
            get { return _prc_ShortProcescellNm; }
            set { SetProperty(ref _prc_ShortProcescellNm, value); }
        }
        public bool prc_ProdLocked
        {
            get { return _prc_ProdLocked; }
            set { SetProperty(ref _prc_ProdLocked, value); }
        }
        public string prc_ProcescellTypeId
        {
            get { return _prc_ProcescellTypeId; }
            set { SetProperty(ref _prc_ProcescellTypeId, value); }
        }
        public string prc_OAProcesCellId
        {
            get { return _prc_OAProcesCellId; }
            set { SetProperty(ref _prc_OAProcesCellId, value); }
        }
        public string prc_OABatchReqObjectNm
        {
            get { return _prc_OABatchReqObjectNm; }
            set { SetProperty(ref _prc_OABatchReqObjectNm, value); }
        }
        public string prc_BatchReqTypeId
        {
            get { return _prc_BatchReqTypeId; }
            set { SetProperty(ref _prc_BatchReqTypeId, value); }
        }
        public string prc_BatchStartTypeId
        {
            get { return _prc_BatchStartTypeId; }
            set { SetProperty(ref _prc_BatchStartTypeId, value); }
        }
        public string prc_BatchOptions
        {
            get { return _prc_BatchOptions; }
            set { SetProperty(ref _prc_BatchOptions, value); }
        }
        public string prc_Display
        {
            get { return _prc_Display; }
            set { SetProperty(ref _prc_Display, value); }
        }
        public string prc_Computer
        {
            get { return _prc_Computer; }
            set { SetProperty(ref _prc_Computer, value); }
        }
        #endregion

        #region Override 

        public override void DeleteTreeViewObject()
        {
            ProcessCellService service = new ProcessCellService();
            service.DeleteProcescell(this);
        }

        public override int CompareTo(object obj)
        {
            Procescell cell = obj as Procescell;
            return string.Compare(this.prc_ProcescellId, cell.prc_ProcescellId);
        }

        public override string GetName()
        {
            return prc_ProcescellId;
        }

        #endregion




    }
}
