using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Subroute : TreeViewObject
    {
        #region Fields
        private string _sur_ProcCellId;
        private string _sur_SubRouteId;
        private string _sur_SubRouteNm;

        private ObservableCollection<SubroutesInRoute> _SubroutesInRoutes;
        private ObservableCollection<BinsInSubRoute> _BinsInSubRoutes;
        private ObservableCollection<UnitsInSubRoute> _UnitsInSubRoutes;

        #endregion

        public Subroute()
        {
            this.BinsInSubRoutes = new ObservableCollection<BinsInSubRoute>();
            this.SubroutesInRoutes = new ObservableCollection<SubroutesInRoute>();
            this.UnitsInSubRoutes = new ObservableCollection<UnitsInSubRoute>();
        }

        #region Properties
        public virtual Procescell Procescell { get; set; }
        public virtual ObservableCollection<SubroutesInRoute> SubroutesInRoutes 
        {
            get { return _SubroutesInRoutes; }
            set { SetProperty(ref _SubroutesInRoutes, value); }
        }
        public virtual ObservableCollection<BinsInSubRoute> BinsInSubRoutes 
        {
            get { return _BinsInSubRoutes; }
            set { SetProperty(ref _BinsInSubRoutes, value); }
        }
        public virtual ObservableCollection<UnitsInSubRoute> UnitsInSubRoutes
        {
            get { return _UnitsInSubRoutes; }
            set { SetProperty(ref _UnitsInSubRoutes, value); }
        }

        public string sur_ProcCellId
        {
            get { return _sur_ProcCellId; }
            set { SetProperty(ref _sur_ProcCellId, value); }
        }
        public string sur_SubRouteId
        {
            get { return _sur_SubRouteId; }
            set { SetProperty(ref _sur_SubRouteId, value); }
        }
        public string sur_SubRouteNm
        {
            get { return _sur_SubRouteNm; }
            set { SetProperty(ref _sur_SubRouteNm, value); }
        }
        #endregion

        #region Override

        public override void DeleteTreeViewObject()
        {
            SubrouteService service = new SubrouteService();
            service.DeleteSubroute(this);
            service.RemoveRelationShips(Procescell, this);
        }

        public override int CompareTo(object obj)
        {
            Subroute subroute = obj as Subroute;
            return string.Compare(this._sur_SubRouteId, subroute._sur_SubRouteId);
        }

        public override string GetName()
        {
            return sur_SubRouteNm;
        }
        #endregion
    }
}
