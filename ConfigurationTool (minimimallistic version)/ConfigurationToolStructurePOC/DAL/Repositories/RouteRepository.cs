using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(IConfigurationToolContext context)
            : base(context)
        {
        }

        protected override IQueryable<Route> Include(IQueryable<Route> entities)
        {
            return entities
                .Include(rot => rot.RouteParameters);
        }

        public override IEnumerable<Route> GetAll()
        {
            return Include(Context.Route).ToList();
        }

        public override void Add(Route entity)
        {
            Context.Route.Add(entity);
        }

        public override void Delete(Route entity)
        {
            var loadedEntity = Context.Route.Where(x => x.rot_RouteId == entity.rot_RouteId && x.ProcesCell.prc_ProcescellId == entity.ProcesCell.prc_ProcescellId)
                .Include(x => x.RouteParameters)
                .Include(x => x.SubroutesInRoutes.Select(z => z.Subroute.BinsInSubRoutes)).Single();
    
            Context.Route.Remove(loadedEntity);
        }
    }
}
