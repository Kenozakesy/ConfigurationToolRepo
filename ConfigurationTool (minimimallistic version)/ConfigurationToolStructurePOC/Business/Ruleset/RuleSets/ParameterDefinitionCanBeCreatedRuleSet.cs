using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Ruleset.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Ruleset.RuleSets
{
    //A ruleset can have multiple rules that can all be checked at the same time.
    //Now you can have multiple different rulesets with rules that you don't have to write twice.
    public class ParameterDefinitionCanBeCreatedRuleSet : RuleSet<ParameterDefinition>
    {
        public ParameterDefinitionCanBeCreatedRuleSet()
        {
            AddRule(new ParameterNameIsValidRule());
            //AddRule( *place another rule here* );
        }

        public override bool IsCompliant(ParameterDefinition entity)
        {         
            return IsCompliantForAny(entity);
            // or IsCompliantForAll
        }
    }
}
