using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class ParameterDefinition : TreeViewObject
    {
        #region Fields
        private string _paf_ParNm;
        private string _paf_ParDesc;
        private string _paf_ParValueUOM;
        private int _paf_BeforeSep;
        private int _paf_AfterSep;
        private string _paf_ValidValues;
        private string _paf_DefValue;
        private ParameterType _paf_Type;
        private Alignment _paf_Alignm;
        private int _paf_Editable;
        private int? _paf_DisplaySeqNr;
        private int? _paf_DisplayWidth;
        private string _paf_ParUOM_TextId;
        private string _paf_DisplayToUser;
        private int? _paf_Column;
        private bool _paf_IsStandardPar;
        // private ObservableCollection<rop_RoutePars> _RouteParametersList = new Ob
        //private ObservableCollection<bip_BinPars> _BinParametersList = new Observ
        #endregion

        #region Properties
        public virtual ObservableCollection<BinParameter> BinParameters { get; set; }
        public virtual ObservableCollection<RouteParameter> RouteParameters { get; set; }
        public virtual ObservableCollection<ProcessCellParameter> ProcessCellParameters { get; set; }
        public virtual ObservableCollection<ProcessCellParameterMapping> ProcessCellParameterMappings { get; set; }
        public virtual ObservableCollection<TableParameterMapping> TableParameterMappings { get; set; }
        public virtual ObservableCollection<ParameterTable> ParameterTables { get; set; }
        public virtual ObservableCollection<ParameterDefinitionProcessCellType> ParameterDefinitionProcessCellTypes { get; set; }


        public string paf_ParNm
        {
            get { return _paf_ParNm; }
            set { SetProperty(ref _paf_ParNm, value); }
        }
        public string paf_ParDesc
        {
            get { return _paf_ParDesc; }
            set { SetProperty(ref _paf_ParDesc, value); }
        }
        public string paf_ParValueUOM
        {
            get { return _paf_ParValueUOM; }
            set { SetProperty(ref _paf_ParValueUOM, value); }
        }
        public int paf_BeforeSep
        {
            get { return _paf_BeforeSep; }
            set { SetProperty(ref _paf_BeforeSep, value); }
        }
        public int paf_AfterSep
        {
            get { return _paf_AfterSep; }
            set { SetProperty(ref _paf_AfterSep, value); }
        }
        public string paf_ValidValues
        {
            get { return _paf_ValidValues; }
            set { SetProperty(ref _paf_ValidValues, value); }
        }
        public string paf_DefValue
        {
            get { return _paf_DefValue; }
            set { SetProperty(ref _paf_DefValue, value); }
        }
        public ParameterType paf_Type
        {
            get { return _paf_Type; }
            set { SetProperty(ref _paf_Type, value); }
        }
        public Alignment paf_Alignm
        {
            get { return _paf_Alignm; }
            set { SetProperty(ref _paf_Alignm, value); }
        }
        public int paf_Editable
        {
            get { return _paf_Editable; }
            set { SetProperty(ref _paf_Editable, value); }
        }
        public int? paf_DisplaySeqNr
        {
            get { return _paf_DisplaySeqNr; }
            set { SetProperty(ref _paf_DisplaySeqNr, value); }
        }
        public int? paf_DisplayWidth
        {
            get { return _paf_DisplayWidth; }
            set { SetProperty(ref _paf_DisplayWidth, value); }
        }
        public string paf_ParUOM_TextId
        {
            get { return _paf_ParUOM_TextId; }
            set { SetProperty(ref _paf_ParUOM_TextId, value); }
        }
        public string paf_DisplayToUser
        {
            get { return _paf_DisplayToUser; }
            set { SetProperty(ref _paf_DisplayToUser, value); }
        }
        public int? paf_Column
        {
            get { return _paf_Column; }
            set { SetProperty(ref _paf_Column, value); }
        }
        public bool paf_IsStandardPar
        {
            get { return _paf_IsStandardPar; }
            set { SetProperty(ref _paf_IsStandardPar, value); }
        }
        #endregion

        #region Override

        public override void DeleteTreeViewObject()
        {
            ParameterDefinitionService service = new ParameterDefinitionService();
            service.DeleteParameterDefinition(this);
        }

        public override int CompareTo(object obj)
        {
            ParameterDefinition pardef = obj as ParameterDefinition;
            return string.Compare(this.paf_ParNm, pardef.paf_ParNm);
        }

        public override string GetName()
        {
            return paf_ParNm;
        }

        #endregion
    }
}
