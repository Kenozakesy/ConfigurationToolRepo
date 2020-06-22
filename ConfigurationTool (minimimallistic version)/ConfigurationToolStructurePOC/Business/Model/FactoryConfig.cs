using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class FactoryConfig
    {
        public IEnumerable<Procescell> Procescells { get; set; }
        public IEnumerable<Bin> Bins { get; set; }
        public IEnumerable<OAUnitDefinition> OAUnitDefinitions { get; set; }
        public IEnumerable<ParameterDefinition> ParameterDefinitions { get; set; }

        public FactoryConfig()
        { 
        
        }

    
    }
}
