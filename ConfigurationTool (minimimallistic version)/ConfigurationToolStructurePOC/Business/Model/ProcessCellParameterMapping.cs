using System;

namespace ConfigurationToolStructurePOC.Business.Model.DataBaseModels
{
    public class ProcessCellParameterMapping
    {
        public string ppr_ProcCellId { get; set; }
        public string ppr_RouteId { get; set; }
        public string ppr_ParNm { get; set; }
        public int ppr_UniqueId { get; set; }
        public string ppr_ParType { get; set; }
        public string ppr_HeaderPropDest { get; set; }
        public string ppr_ParScope { get; set; }
        public string ppr_OAUnitId { get; set; }
        public string ppr_MapToParNm { get; set; }
        public Nullable<int> ppr_MustBeFilled { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }
        public virtual Route Route { get; set; }
    }
}
