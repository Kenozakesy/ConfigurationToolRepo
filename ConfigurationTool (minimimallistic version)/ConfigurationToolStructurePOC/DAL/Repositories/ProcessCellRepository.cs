using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    public class ProcessCellRepository : BaseRepository<Procescell>, IProcescellRepository
    {


        public ProcessCellRepository(IConfigurationToolContext context)
        : base(context)
        {
        }

        protected override IQueryable<Procescell> Include(IQueryable<Procescell> entities)
        {
            return entities
                .Include(prc => prc.Routes)
                .Include(prc => prc.Subroutes)
                .Include(prc => prc.Routes.Select(rot => rot.SubroutesInRoutes))
                .Include(prc => prc.Routes.Select(rot => rot.SubroutesInRoutes.Select(sub => sub.Subroute)))
                .Include(prc => prc.Routes.Select(rot => rot.SubroutesInRoutes.Select(sub => sub.Subroute.BinsInSubRoutes.Select(bin => bin.Bin))))
                .Include(par => par.ProcessCellParameters);

                //.Include(prc => prc.Routes.Select(rot => rot.SubRoutesInRoutes.Select(sri => sri.SubRouteDO.BinsInSubRoutes.Select(b => b.Bin.BinStock))))
                //.Include(prc => prc.Routes.Select(rot => rot.SubRoutesInRoutes.Select(sri => sri.SubRouteDO.BinsInSubRoutes.Select(b => b.Bin.Article))))
                //.Include(prc => prc.Routes.Select(rot => rot.RouteParameters));
        }

        public override IEnumerable<Procescell> GetAll()
        {
            return Include(Context.Procescell).ToList();
        }

        public override void Add(Procescell entity)                                                       
        {
            Context.Procescell.Add(entity);
        }

        public override void Delete(Procescell entity)
        {
            //Gets current procescell from the context
            var loadedEntity = Context.Procescell.Where(x => x.prc_ProcescellId == entity.prc_ProcescellId)
               .Include(x => x.ProcessCellParameters)
               .Include(x => x.Routes.Select(z => z.RouteParameters))
               .Include(x => x.Routes.Select(z => z.SubroutesInRoutes.Select(y => y.Subroute.BinsInSubRoutes))).Single();

            Context.Procescell.Remove(loadedEntity);
        }


    }
}
