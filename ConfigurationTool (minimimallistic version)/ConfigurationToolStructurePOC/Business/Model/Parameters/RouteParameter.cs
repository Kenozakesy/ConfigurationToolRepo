using ConfigurationToolStructurePOC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model.Parameters
{
    public class RouteParameter : IParameterObject
    {
        public string rop_ProcCellId { get; set; }
        public string rop_RouteId { get; set; }
        public string rop_ParNm { get; set; }
        public string rop_ParDesc { get; set; }
        public string Value { get; set; }
        public string rop_ParValueUOM { get; set; }
        public string rop_DisplayToUser { get; set; }
        public virtual Route Route { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }

        public RouteParameter()
        {

        }

        public RouteParameter(Route route, ParameterDefinition paramdef, Procescell procescell)
        {
            rop_ProcCellId = procescell.prc_ProcescellId;
            rop_RouteId = route.rot_RouteId;
            rop_ParNm = paramdef.paf_ParNm;
            rop_ParDesc = paramdef.paf_ParDesc;
            Value = paramdef.paf_DefValue;
            rop_ParValueUOM = paramdef.paf_ParValueUOM;
            rop_DisplayToUser = paramdef.paf_DisplayToUser;

            Route = route;
            ParameterDefinition = paramdef;
        }
    }
}
