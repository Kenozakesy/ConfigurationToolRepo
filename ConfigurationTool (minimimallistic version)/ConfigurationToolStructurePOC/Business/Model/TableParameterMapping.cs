using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class TableParameterMapping
    {
        public TableParameterMapping()
        {

        }

        public string tpm_ParNm { get; set; }
        public string tpm_TableId { get; set; }
        public bool tpm_MappingIsEnabled { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }
        public virtual ParameterTable ParameterTable { get; set; }
    }
}
