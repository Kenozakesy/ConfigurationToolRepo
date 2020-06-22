using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Statics;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class SubrouteService
    {
        public IEnumerable<Subroute> GetAllSubroutes()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new SubrouteRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateSubroute(Subroute subroute)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new SubrouteRepository(context);
                repository.Add(subroute);
                context.SaveChanges();
            }
        }

        public void DeleteSubroute(Subroute subroute)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new SubrouteRepository(context);
                repository.Delete(subroute);
                context.SaveChanges();
            }
        }

        public Subroute GenerateNewSubroute(Procescell procescell, string name)
        {
            List<int> SubrouteIds = new List<int>();
            foreach (Subroute r in procescell.Subroutes)
            {
                string routeid = new String(r.sur_SubRouteId.Where(Char.IsDigit).ToArray());
                SubrouteIds.Add(Convert.ToInt32(routeid));
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(SubrouteIds).FirstOrDefault();

            string SubrouteId = "SR" + firstAvailable;
            Subroute subroute = new Subroute
            {
                sur_ProcCellId = procescell.prc_ProcescellId,
                sur_SubRouteId = SubrouteId,
                sur_SubRouteNm = name                               
            };
            return subroute;
        }

        public void RemoveRelationShips(Procescell procescell, Subroute subroute)
        {
            //remove procescell relationship
            procescell.Subroutes.Remove(subroute);
            subroute.Procescell = null;

            //remove route relationship
            foreach (SubroutesInRoute S in subroute.SubroutesInRoutes)
	        {
                S.Route.SubroutesInRoutes.Remove(S);
	        }
       
            //remove bin relationship
            foreach (BinsInSubRoute bir in subroute.BinsInSubRoutes)
            {
                //bir.Subroute.BinsInSubRoutes.Remove(bir);
                bir.Bin.BinsInSubRoutes.Remove(bir);
            }

        }

        public void AddSubrouteToCell(Procescell procescell, Subroute subroute)
        {
            OrderObservableList.AddSorted(procescell.Subroutes, subroute);
            subroute.Procescell = procescell;
        }

        public List<Subroute> GetSubroutesNotInRoute(Route route)
        {
            List<Subroute> subroutesInRoute = new List<Subroute>();
            List<Subroute> subroutesNotInRoute = new List<Subroute>();
            Procescell procescell = route.ProcesCell;

            foreach (SubroutesInRoute sri in route.SubroutesInRoutes)
            {
                subroutesInRoute.Add(sri.Subroute);
            }

            foreach (Subroute S in procescell.Subroutes)
            {
                if (!subroutesInRoute.Contains(S))
                {
                    OrderObservableList.AddSorted(subroutesNotInRoute, S);
                }
            }
            return subroutesNotInRoute;       
        }

        public List<BinsInSubRoute> GetAllSourcebins(Subroute subroute)
        {
            List<BinsInSubRoute> SourceBins = new List<BinsInSubRoute>();

            foreach (BinsInSubRoute bir in subroute.BinsInSubRoutes)
            {
                if (bir.bir_SourceDest == "S" )
                {
                    OrderObservableList.AddSorted(SourceBins, bir);
                }
            }
            return SourceBins;
        }

        public List<BinsInSubRoute> GetAllDestinationBins(Subroute subroute)
        {
            List<BinsInSubRoute> SourceBins = new List<BinsInSubRoute>();

            foreach (BinsInSubRoute bir in subroute.BinsInSubRoutes)
            {
                if (bir.bir_SourceDest == "D" )
                {
                    OrderObservableList.AddSorted(SourceBins, bir);
                }
            }
            return SourceBins;
        }


        
    }
}
