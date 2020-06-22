using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.Business.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Route : TreeViewObject
    {
        private ObservableCollection<SubroutesInRoute> _SubroutesInRoutes = new ObservableCollection<SubroutesInRoute>();
        private ObservableCollection<RouteParameter> _RouteParameters = new ObservableCollection<RouteParameter>();

        public Route()
        {
            SubroutesInRoutes = new ObservableCollection<SubroutesInRoute>();
            RouteParameters = new ObservableCollection<RouteParameter>();
            OAProcessCellDefinitions = new ObservableCollection<OAProcessCellDefinition>();
            ProcessCellParameterMappings = new ObservableCollection<ProcessCellParameterMapping>();
        }

        #region Fields

        private string _rot_ProcesCellId;
        private string _rot_RouteId;
        private string _rot_RouteNm;
        private string _rot_ShortRouteNm;
        private string _rot_ProcedureId;
        private int _rot_Available;
        private int _rot_SelectPriority;

        #endregion

        #region Properties
        public virtual Procescell ProcesCell { get; set; }
        public virtual Procedure Procedure { get; set; }
        public virtual ObservableCollection<SubroutesInRoute> SubroutesInRoutes
        {
            get { return _SubroutesInRoutes; }
            set { SetProperty(ref _SubroutesInRoutes, value); } 
        }
        public virtual ObservableCollection<RouteParameter> RouteParameters
        {
            get { return _RouteParameters; }
            set { SetProperty(ref _RouteParameters, value); }
        }
        public virtual ICollection<OAProcessCellDefinition> OAProcessCellDefinitions { get; set; }
        public virtual ICollection<ProcessCellParameterMapping> ProcessCellParameterMappings { get; set; }

        public string rot_ProcesCellId
        {
            get { return _rot_ProcesCellId; }
            set { SetProperty(ref _rot_ProcesCellId, value); }
        }
        public string rot_RouteId
        {
            get { return _rot_RouteId; }
            set { SetProperty(ref _rot_RouteId, value); }
        }
        public string rot_RouteNm
        {
            get { return _rot_RouteNm; }
            set { SetProperty(ref _rot_RouteNm, value); }
        }
        public string rot_ShortRouteNm
        {
            get { return _rot_ShortRouteNm; }
            set { SetProperty(ref _rot_ShortRouteNm, value); }
        }
        public string rot_ProcedureId
        {
            get { return _rot_ProcedureId; }
            set { SetProperty(ref _rot_ProcedureId, value); }
        }
        public int rot_Available
        {
            get { return _rot_Available; }
            set { SetProperty(ref _rot_Available, value); }
        }
        public int rot_SelectPriority
        {
            get { return _rot_SelectPriority; }
            set { SetProperty(ref _rot_SelectPriority, value); }
        }
       #endregion

        #region Override

        public override void DeleteTreeViewObject()
        {
            RouteService service = new RouteService();
            service.DeleteRoute(this);
            service.RemoveRouteFromCell(ProcesCell, this);
        }

        public override int CompareTo(object obj)
        {
            Route route = obj as Route;
            return string.Compare(this.rot_RouteNm, route.rot_RouteNm);
        }

        public override string GetName()
        {
            return rot_RouteNm;
        }
        #endregion


    }
}
