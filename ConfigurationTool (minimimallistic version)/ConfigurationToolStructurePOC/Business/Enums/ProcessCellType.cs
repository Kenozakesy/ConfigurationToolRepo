using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Enums
{
    public enum ProcescellType
    {
        [Description("TransportLine")]
        TL,
        [Description("BlendingLine")]
        BL,
        [Description("IntakeLine")]
        IL,
        [Description("OutloadingLine")]
        OL,
        [Description("PressLine")]
        PL,
        [Description("RoutingLine")]
        RL,
        [Description("PackagingLine")]
        SL,
        [Description("Contraset")]
        CS
    }
}

  