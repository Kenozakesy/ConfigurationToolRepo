using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class OAUnitDefinition : TreeViewObject
    {
     
        #region Properties
        public string oud_OAUnitId { get; set; }
        public string oud_OAUnitPUObjectNm { get; set; }
        public string oud_OAOperPUObjectNm { get; set; }
        public string oud_OAUnitAllocNm { get; set; }
        public string oud_OAUnitCntObjectNm { get; set; }
        public string oud_OAPropEMObjectNm { get; set; }
        public string oud_OAIndObjectNm { get; set; }
        public string oud_ImplementedIFs { get; set; }
        public string oud_UnitNm { get; set; }
        public string oud_UnitRoles { get; set; }
        public string oud_BatchRegTypeId { get; set; }
        public Nullable<bool> oud_IsUnit { get; set; }
        public Nullable<bool> oud_IsTransportHandler { get; set; }
        public Nullable<bool> oud_OAUnitInTransportHandler { get; set; }
        //public virtual ICollection<epc_EditPropConfigs> epc_EditPropConfigs { get; set; }
        //public virtual ICollection<epc_EditPropConfigs> epc_EditPropConfigs1 { get; set; }
        //public virtual ICollection<ooi_OAOperInterfDefs> ooi_OAOperInterfDefs { get; set; }
        public virtual ICollection<Bin> Bins { get; set; }
        public virtual ICollection<UnitsInSubRoute> UnitsInSubroute { get; set; }
        #endregion

       #region Override
        public override void DeleteTreeViewObject()
        {
            OAUnitDefinitionService service = new OAUnitDefinitionService();
            service.DeleteUnit(this);
        }

        public override int CompareTo(object obj)
        {
            OAUnitDefinition unit = obj as OAUnitDefinition;
            return string.Compare(this.oud_OAUnitId, unit.oud_OAUnitId);
        }

        public override string GetName()
        {
            return oud_UnitNm;
        }
        #endregion
    }
}
