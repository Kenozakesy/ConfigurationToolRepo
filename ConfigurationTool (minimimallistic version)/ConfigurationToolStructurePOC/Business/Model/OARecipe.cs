using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class OARecipe
    {
        public string oar_ProcedureId { get; set; }
        public string oar_OAStateId { get; set; }
        public string oar_OARcpNM { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
