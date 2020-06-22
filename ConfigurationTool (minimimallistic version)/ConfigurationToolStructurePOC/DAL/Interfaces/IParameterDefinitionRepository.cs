using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Interfaces
{
    interface IParameterDefinitionRepository : IRepository<ParameterDefinition>
    {
        IEnumerable<ParameterDefinition> GetRequiredParameters(string patId, string procescellTypeId);
    }
}
