using ConfigurationToolStructurePOC.Business.Interfaces;

namespace ConfigurationToolStructurePOC.Business.Model.Parameters
{
    public class BinParameter : IParameterObject
    {
        public string bip_BinId { get; set; }
        public string bip_ParNm { get; set; }
        public string bip_ParDesc { get; set; }
        public string Value { get; set; }
        public string bip_ParValueUOM { get; set; }
        public string bip_DisplayToUser { get; set; }
        public virtual Bin Bin { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }

        public BinParameter()
        {

        }

        public BinParameter(Bin bin, ParameterDefinition paramdef)
        {
            bip_BinId = bin.bin_BinId;
            bip_ParNm = paramdef.paf_ParNm;
            bip_ParDesc = paramdef.paf_ParDesc;
            Value = paramdef.paf_DefValue;
            bip_ParValueUOM = paramdef.paf_ParValueUOM;
            bip_DisplayToUser = paramdef.paf_DisplayToUser;
            Bin = bin;
            ParameterDefinition = paramdef;
        }
    }

    
}
