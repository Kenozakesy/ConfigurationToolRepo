using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class SubroutesInRouteRepository : BaseRepository<SubroutesInRoute>, ISubrouteInRouteRepository
    {
        public SubroutesInRouteRepository(IConfigurationToolContext context)
            : base(context)
        {

        }

        protected override IQueryable<SubroutesInRoute> Include(IQueryable<SubroutesInRoute> entities)
        {
            return entities;
        }

        public override IEnumerable<SubroutesInRoute> GetAll()
        {
            return Include(Context.SubrouteInRoute).ToList();
        }

        public override void Add(SubroutesInRoute entity)
        {
            Context.SubrouteInRoute.Add(entity);
        }

        public override void Delete(SubroutesInRoute entity)
        {
            var loadedEntity = Context.SubrouteInRoute.Where(x => x.sri_ProcCellId == entity.sri_ProcCellId 
                                                                && x.sri_RouteId == entity.sri_RouteId
                                                                && x.sri_SubRouteId == entity.sri_SubRouteId).FirstOrDefault();
            Context.SubrouteInRoute.Remove(loadedEntity);
        }
    }
}
