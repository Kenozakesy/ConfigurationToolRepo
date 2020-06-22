using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class BinParameterRepository: BaseRepository<BinParameter>, IBinParameterRepository
    {
        public BinParameterRepository(IConfigurationToolContext context)
        : base(context)
        {
        }

        protected override IQueryable<BinParameter> Include(IQueryable<BinParameter> entities)
        {
            return entities;
        }

        public override IEnumerable<BinParameter> GetAll()
        {
            return Include(Context.BinParameter).ToList();
        }

        public override void Add(BinParameter entity)
        {
            Context.BinParameter.Add(entity);
        }

        public override void Delete(BinParameter entity)
        {
            var loadedEntity = Context.BinParameter.Where(x => x.bip_ParNm == entity.bip_ParNm && x.bip_BinId == entity.bip_BinId).Single();
            Context.BinParameter.Remove(loadedEntity);
        }
    }
}
