using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Procedure
    {
        public Procedure()
        {
            OARecipes = new ObservableCollection<OARecipe>();
            Routes = new ObservableCollection<Route>();
        }

        public Procedure(Route route)
        {
            OARecipes = new HashSet<OARecipe>();
            Routes = new ObservableCollection<Route>();
            Routes.Add(route);

            this.pru_ProcedureId = route.ProcesCell.prc_ProcescellId + route.rot_RouteId;
            this.pru_ProcedureNm = "Procedure " + pru_ProcedureId;
            this.pru_ProcedureTypeId = route.ProcesCell.prc_ProcescellTypeId.Replace("L", "");
        }

        public string pru_ProcedureId { get; set; }
        public string pru_ProcedureNm { get; set; }
        public string pru_ProcedureTypeId { get; set; }
        public virtual ICollection<OARecipe> OARecipes { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
