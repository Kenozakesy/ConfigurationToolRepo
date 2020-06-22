using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    class ProcessCellParameterRepository : BaseRepository<ProcessCellParameter>, IProcessCellParameterRepository
    {
        public ProcessCellParameterRepository(IConfigurationToolContext context)
        : base(context)
        {
        }

        protected override IQueryable<ProcessCellParameter> Include(IQueryable<ProcessCellParameter> entities)
        {
            return entities;
        }

        public override IEnumerable<ProcessCellParameter> GetAll()
        {
            return Include(Context.ProcessCellParameter).ToList();
        }

        public override void Add(ProcessCellParameter entity)                                                       
        {
            Context.ProcessCellParameter.Add(entity);
        }

        public override void Delete(ProcessCellParameter entity)
        {
            //Gets current procescell from the context
            var loadedEntity = Context.ProcessCellParameter.Where(x => x.pca_ParNm == entity.pca_ParNm && x.pca_ProcCellId == entity.pca_ProcCellId).Single();
            Context.ProcessCellParameter.Remove(loadedEntity);
        }
    }
}
