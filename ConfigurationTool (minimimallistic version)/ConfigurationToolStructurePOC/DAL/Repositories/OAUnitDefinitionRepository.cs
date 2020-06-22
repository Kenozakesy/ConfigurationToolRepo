using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class OAUnitDefinitionRepository : BaseRepository<OAUnitDefinition>, IOAUnitDefinitionRepository
    {
        public OAUnitDefinitionRepository(IConfigurationToolContext context) : base(context)
        {

        }

        protected override IQueryable<OAUnitDefinition> Include(IQueryable<OAUnitDefinition> entities)
        {
            return entities
                .Include(oud => oud.Bins);
        }

        public override IEnumerable<OAUnitDefinition> GetAll()
        {
            return Include(Context.Unit).ToList();
        }

        public override void Add(OAUnitDefinition entity)
        {
            Context.Unit.Add(entity);
        }
    }
}
