using ConfigurationToolStructurePOC.Business.Model;
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
    public class SubrouteInRouteService
    {
        public IEnumerable<SubroutesInRoute> GetAllSubrouteInRoutes()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new SubroutesInRouteRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateSubrouteInRoute(SubroutesInRoute subrouteinroute)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new SubroutesInRouteRepository(context);
                repository.Add(subrouteinroute);
                context.SaveChanges();
            }
        }

       public void DeleteSubrouteInRoute(SubroutesInRoute subrouteinroute)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new SubroutesInRouteRepository(context);
                repository.Delete(subrouteinroute);
                context.SaveChanges();
            }
        }

       public SubroutesInRoute GenerateNewSubrouteInRoute(Subroute subroute, Route route, int sequencenumber)
       {
           SubroutesInRoute subrouteInRoute = new SubroutesInRoute()
           {
               sri_ProcCellId = route.ProcesCell.prc_ProcescellId,
               sri_RouteId = route.rot_RouteId,
               sri_SeqNr = sequencenumber,
               sri_SubRouteId = subroute.sur_SubRouteId
           };

           return subrouteInRoute; 
       }

       public void RemoveRelationShips(SubroutesInRoute subrouteinroute)
       { 
           //route
           subrouteinroute.Route.SubroutesInRoutes.Remove(subrouteinroute);

           //subroute
           subrouteinroute.Subroute.SubroutesInRoutes.Remove(subrouteinroute);
       }

       public void AddRelationShips(SubroutesInRoute subrouteInRoute, Subroute subroute, Route route)
       {
           subrouteInRoute.Subroute = subroute;
           subrouteInRoute.Route = route;

           //route
           OrderObservableList.AddSorted(subrouteInRoute.Route.SubroutesInRoutes, subrouteInRoute);

           //subroute
           OrderObservableList.AddSorted(subrouteInRoute.Subroute.SubroutesInRoutes, subrouteInRoute);

       }
    }
}
