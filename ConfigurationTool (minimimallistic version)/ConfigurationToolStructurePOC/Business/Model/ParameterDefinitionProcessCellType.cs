using ConfigurationToolStructurePOC.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class ParameterDefinitionProcessCellType
    {
        public string pac_ParNm { get; set; }
        public string pac_ProcCellTypeId { get; set; }
        public bool pac_IsRequired { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }
    }
}
