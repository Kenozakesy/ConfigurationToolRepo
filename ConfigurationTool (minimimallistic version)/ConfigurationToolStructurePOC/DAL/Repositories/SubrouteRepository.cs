using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class SubrouteRepository : BaseRepository<Subroute>, ISubrouteRepository
    {
        public SubrouteRepository(IConfigurationToolContext context) : base(context)
        {

        }

        protected override IQueryable<Subroute> Include(IQueryable<Subroute> entities)
        {
            return entities;
        }

        public override IEnumerable<Subroute> GetAll()
        {
            return Include(Context.Subroute).ToList();
        }

        public override void Add(Subroute entity)
        {
            Context.Subroute.Add(entity);
        }

        public override void Delete(Subroute entity)
        {
            var loadedEntity = Context.Subroute.Where(x => x.sur_ProcCellId == entity.sur_ProcCellId && x.sur_SubRouteId == entity.sur_SubRouteId)
                                            .Include(x => x.SubroutesInRoutes)
                                            .Include(x => x.UnitsInSubRoutes)
                                            .Include(x => x.BinsInSubRoutes).FirstOrDefault();

            Context.Subroute.Remove(loadedEntity);
        }
    }
}
