using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class SubroutesInRoute : TreeViewObject
    {
        #region Fields

        private string _sri_ProcCellId;
        private string _sri_RouteId;
        private string _sri_SubRouteId;
        private int _sri_SeqNr;

        #endregion

        public SubroutesInRoute()
        {

        }

        #region Properties

        public string sri_ProcCellId
        {
            get { return _sri_ProcCellId; }
            set { SetProperty(ref _sri_ProcCellId, value); }
        }
        public string sri_RouteId
        {
            get { return _sri_RouteId; }
            set { SetProperty(ref _sri_RouteId, value); }
        }
        public string sri_SubRouteId
        {
            get { return _sri_SubRouteId; }
            set { SetProperty(ref _sri_SubRouteId, value); }
        }
        public int sri_SeqNr
        {
            get { return _sri_SeqNr; }
            set { SetProperty(ref _sri_SeqNr, value); }
        }

        public virtual Route Route { get; set; }
        public virtual Subroute Subroute { get; set; }

        #endregion

        #region Override

        [NotMapped]
        public override Brush Colour
        {
            get { return Subroute.Colour; }
        }

        public override void DeleteTreeViewObject()
        {
            SubrouteInRouteService service = new SubrouteInRouteService();
            service.DeleteSubrouteInRoute(this);
            service.RemoveRelationShips(this);
        }

        public override int CompareTo(object obj)
        {
            SubroutesInRoute subrouteinroute = obj as SubroutesInRoute;
            return string.Compare(this._sri_SubRouteId, subrouteinroute._sri_SubRouteId);
        }

        public override string GetName()
        {
            return Subroute.sur_SubRouteNm + " relationship";
        }

        #endregion


    }
}
