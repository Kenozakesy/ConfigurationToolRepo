using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConfigurationToolStructurePOC.DAL.Repositories
{
    class ParameterDefinitionRepository : BaseRepository<ParameterDefinition>, IParameterDefinitionRepository
    {
        public ParameterDefinitionRepository(IConfigurationToolContext context)
        : base(context)
        {
        }

        protected override IQueryable<ParameterDefinition> Include(IQueryable<ParameterDefinition> entities)
        {
            return entities
                .Include(paf => paf.TableParameterMappings.Select(pat => pat.ParameterTable))
                .Include(paf => paf.ParameterDefinitionProcessCellTypes);
        }

        public override IEnumerable<ParameterDefinition> GetAll()
        {
            return Include(Context.ParameterDefinition).ToList();
        }

        public override void Add(ParameterDefinition entity)
        {
            Context.ParameterDefinition.Add(entity);
        }

        public override void Delete(ParameterDefinition entity)
        {
            //Gets current procescell from the context
            var loadedEntity = Context.ParameterDefinition.Where(x => x.paf_ParNm == entity.paf_ParNm).Single();
            Context.ParameterDefinition.Remove(loadedEntity);
        }


        public IEnumerable<ParameterDefinition> GetRequiredParameters(string patId, string procescellTypeId)
        {
            IEnumerable<ParameterDefinition> parameterDefinitions;

            var select = (from r in Context.ParameterDefinition
                              join x in Context.TableParameterMapping on r.paf_ParNm equals x.tpm_ParNm
                              join a in Context.ParameterDefinitionProcessCellType on r.paf_ParNm equals a.pac_ParNm
                              where a.pac_ProcCellTypeId == procescellTypeId
                            && x.tpm_TableId == patId
                            && a.pac_IsRequired == true
                            select r);
            parameterDefinitions = select.ToList();
           
            return parameterDefinitions;
        }
    }
}
