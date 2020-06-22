using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class ParameterTable
    {
        public ParameterTable()
        {

        }

        public string pat_TableId { get; set; }
        public string pat_TableDesc { get; set; }
        public string pat_Priority { get; set; }
        public virtual ICollection<TableParameterMapping> TableParameterMappings { get; set; }
        public virtual ICollection<ParameterDefinition> ParameterDefinitions { get; set; }
    }
}
