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
    public class BinsInSubrouteRepository : BaseRepository<BinsInSubRoute>, IBinsinSubrouteRepository
    {
        public BinsInSubrouteRepository(IConfigurationToolContext context)
            : base(context)
        {

        }

        protected override IQueryable<BinsInSubRoute> Include(IQueryable<BinsInSubRoute> entities)
        {
            return entities;
        }

        public override IEnumerable<BinsInSubRoute> GetAll()
        {
            return Include(Context.BinsInSubRoute).ToList();
        }

        public override void Add(BinsInSubRoute entity)
        {
            Context.BinsInSubRoute.Add(entity);
        }

        public override void Delete(BinsInSubRoute entity)
        {
            var loadedEntity = Context.BinsInSubRoute.Where(x => x.bir_BinId == entity.bir_BinId 
                                                         && x.bir_SubRouteId == entity.bir_SubRouteId).FirstOrDefault();
            Context.BinsInSubRoute.Remove(loadedEntity);
        }
    }
}
