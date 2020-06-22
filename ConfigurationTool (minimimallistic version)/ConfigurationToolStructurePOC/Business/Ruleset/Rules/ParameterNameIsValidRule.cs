using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Ruleset.Rules
{
    //A simpel rule that checks if the name is empty or not.
    public class ParameterNameIsValidRule : RuleBase<ParameterDefinition>
    {
        public override bool IsCompliant(ParameterDefinition entity)
        {
            if (entity.paf_ParNm != "")
                return true;

            return false;
        }
    }
}
