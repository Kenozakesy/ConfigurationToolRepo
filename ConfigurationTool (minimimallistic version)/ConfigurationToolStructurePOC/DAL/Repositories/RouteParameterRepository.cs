using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class RouteParameterRepository : BaseRepository<RouteParameter>, IRouteParameterRepository
    {
        public RouteParameterRepository(IConfigurationToolContext context)
        : base(context)
        {
        }

        protected override IQueryable<RouteParameter> Include(IQueryable<RouteParameter> entities)
        {
            return entities;
        }

        public override IEnumerable<RouteParameter> GetAll()
        {
            return Include(Context.RouteParameter).ToList();
        }

        public override void Add(RouteParameter entity)
        {
            Context.RouteParameter.Add(entity);
        }

        public override void Delete(RouteParameter entity)
        {
            var loadedEntity = Context.RouteParameter.Where(x => x.rop_RouteId == entity.rop_RouteId && x.rop_ParNm == entity.rop_ParNm).Single();
            Context.RouteParameter.Remove(loadedEntity);
        }
    }
}
