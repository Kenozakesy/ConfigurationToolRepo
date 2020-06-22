using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class BinStock
    {
        public string bis_BinId { get; set; }
        public double bis_Stock { get; set; }
        public virtual Bin Bin { get; set; }
    }
}
