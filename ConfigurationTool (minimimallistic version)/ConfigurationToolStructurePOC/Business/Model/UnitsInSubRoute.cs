
namespace ConfigurationToolStructurePOC.Business.Model.DataBaseModels
{
    public class UnitsInSubRoute
    {
        public string uis_ProcCellId { get; set; }
        public string uis_SubRouteId { get; set; }
        public string uis_OAUnitId { get; set; }
        public int uis_SeqNr { get; set; }
        public int uis_IsTransporthandlerUnit { get; set; }
        public virtual Subroute SubRoute { get; set; }
        public virtual OAUnitDefinition Unit{ get; set; }
    }
}
