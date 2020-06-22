using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
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
    public class RouteService
    {
        public IEnumerable<Route> GetAllRoutes()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new RouteRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateNewRoute(Route route, Procescell procescell)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new RouteRepository(context);
                var parameterDefinitionRepository = new ParameterDefinitionRepository(context);

                //Gets required parameters for a new procescell
                IEnumerable<ParameterDefinition> requiredParameters;
                requiredParameters = parameterDefinitionRepository.GetRequiredParameters("rop_RoutePars", procescell.prc_ProcescellTypeId);

                //convert parDef to proccellPars and add them to the procescell
                foreach (ParameterDefinition paf in requiredParameters)
                {
                    RouteParameter rop = new RouteParameter(route, paf, procescell);
                    route.RouteParameters.Add(rop);
                }

                repository.Add(route);
                context.SaveChanges();
            }
        }

        public void DeleteRoute(Route route)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new RouteRepository(context);
                repository.Delete(route);
                context.SaveChanges();
            }
        }

        public Route GenerateNewRoute(Procescell cell)
        {
            List<int> RouteIds = new List<int>();
            foreach (Route r in cell.Routes)
            {
                string routeid = new String(r.rot_RouteId.Where(Char.IsDigit).ToArray());
                RouteIds.Add(Convert.ToInt32(routeid));
            }
            int? firstAvailable = Enumerable.Range(1, int.MaxValue).Except(RouteIds).FirstOrDefault();

            string routeId = "R" + firstAvailable;
            Route route = new Route
            {
                rot_RouteId = routeId,
                rot_RouteNm = cell.prc_ProcescellId +":"+ routeId + ":",
                rot_ShortRouteNm = routeId,
                rot_Available = 1,
                rot_SelectPriority = 1,
                //rot_ProcedureId = cell.prc_ProcescellId + routeId,               
                rot_ProcesCellId = cell.prc_ProcescellId,           
            };
            return route;
        }

        public void ConnectRouteToCell(Procescell cell, Route route)
        {
            OrderObservableList.AddSorted(cell.Routes, route);
            route.ProcesCell = cell;       
        }

        public void RemoveRouteFromCell(Procescell cell, Route route)
        {
            cell.Routes.Remove(route);
            route.ProcesCell = null;
        }


    }
}
