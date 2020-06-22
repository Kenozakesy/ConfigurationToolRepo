using ConfigurationToolStructurePOC.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class BinsInSubRoute : TreeViewObject
    {

        public BinsInSubRoute()
        { 
        
        }

        public BinsInSubRoute(Subroute subroute, Bin bin, SourceDest sourcedest)
        {
            bir_ProcCellId = subroute.Procescell.prc_ProcescellId;
            bir_SubRouteId = subroute.sur_SubRouteId;
            bir_SourceDest = sourcedest.ToString();
            bir_BinId = bin.bin_BinId;
        }

        public string bir_ProcCellId { get; set; }
        public string bir_SubRouteId { get; set; }
        public string bir_SourceDest { get; set; }
        public string bir_BinId { get; set; }
        public virtual Bin Bin { get; set; }
        public virtual Subroute Subroute { get; set; }


        public override void DeleteTreeViewObject()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(object obj)
        {
            BinsInSubRoute bir = obj as BinsInSubRoute;
            return string.Compare(this.bir_BinId, bir.bir_BinId);
        }
    }
}
