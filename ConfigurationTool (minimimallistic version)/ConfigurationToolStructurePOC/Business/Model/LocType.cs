using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class LocType
    {
        public string lts_LocTypeId { get; set; }
        public string lts_LocTypeNm { get; set; }
        public virtual Bin Bin { get; set; }
    }
}
