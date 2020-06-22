using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Interfaces
{
    public interface IRule<T>
    {
        bool IsCompliant(T entity);
    }
}
