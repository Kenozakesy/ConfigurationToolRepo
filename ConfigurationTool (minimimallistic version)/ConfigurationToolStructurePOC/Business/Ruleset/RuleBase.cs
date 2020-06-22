using ConfigurationToolStructurePOC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Ruleset
{
    public class RuleBase<T> : IRule<T>
    {
        public virtual bool IsCompliant(T entity)
        { 
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return true;
        }
    }
}
