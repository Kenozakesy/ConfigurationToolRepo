using ConfigurationToolStructurePOC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Ruleset
{
    public abstract class RuleSet<T> : IRuleSet<T>
    {
        private List<IRule<T>> _rules;
        public RuleSet()
        {
            _rules = new List<IRule<T>>();
        }
        protected void AddRule(IRule<T> rule)
        {
            _rules.Add(rule);
        }

        public abstract bool IsCompliant(T entity);

        protected bool IsCompliantForAll(T entity)
        {
            foreach (var rule in _rules)
            {
                if (!rule.IsCompliant(entity))
                    return false;
            }
            return true;
        }

        protected bool IsCompliantForAny(T entity)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsCompliant(entity))
                    return true;
            }
            return false;
        }
    }
}
