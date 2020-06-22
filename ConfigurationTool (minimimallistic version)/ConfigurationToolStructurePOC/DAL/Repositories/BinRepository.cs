using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class BinRepository : BaseRepository<Bin>, IBinRepository
    {
        public BinRepository(IConfigurationToolContext context)
            : base(context)
        {
        }

        protected override IQueryable<Bin> Include(IQueryable<Bin> entities)
        {
            return entities
                .Include(bin => bin.BinParameters)
                .Include(bin => bin.BinStock);
        }

        public override IEnumerable<Bin> GetAll()
        {
            return Include(Context.Bin).ToList();
        }

        public override void Add(Bin entity)                                                       
        {
            Context.Bin.Add(entity);
        }

        public override void Delete(Bin entity)
        {
            var loadedEntity = Context.Bin.Where(x => x.bin_BinId == entity.bin_BinId).Single();             

            Context.Bin.Remove(loadedEntity);
        }

        public IEnumerable<string> GetAllBinTypes()
        {
            IEnumerable<string> BinTypes;

            var select = (from r in Context.LocType
                          select r.lts_LocTypeId);
            BinTypes = select.ToList();

            return BinTypes;
        }
    }
}
