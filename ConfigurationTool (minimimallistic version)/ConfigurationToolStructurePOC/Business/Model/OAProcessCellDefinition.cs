using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model.DataBaseModels
{
    public class OAProcessCellDefinition
    {
        public string opc_ProcCellId { get; set; }
        public string opc_RouteId { get; set; }
        public string opc_OAProcCellPUObjectNm { get; set; }
        public string opc_OAProcCellBatchInfo { get; set; }
        public Nullable<int> opc_OAProcCellColor { get; set; }
        public string opc_BatchNm { get; set; }
        public virtual Route Route { get; set; }
    }
}
