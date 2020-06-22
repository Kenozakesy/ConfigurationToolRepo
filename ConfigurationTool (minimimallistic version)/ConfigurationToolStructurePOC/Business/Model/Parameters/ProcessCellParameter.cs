using ConfigurationToolStructurePOC.Business.Interfaces;

namespace ConfigurationToolStructurePOC.Business.Model.Parameters
{
    public class ProcessCellParameter : IParameterObject
    {
        public string pca_ProcCellId { get; set; }
        public string pca_ParNm { get; set; }
        public string pca_ParDesc { get; set; }
        public string Value { get; set; }
        public string pca_ParValueUOM { get; set; }
        public string pca_DisplayToUser { get; set; }
        public virtual Procescell ProcessCell { get; set; }
        public virtual ParameterDefinition ParameterDefinition { get; set; }

        public ProcessCellParameter()
        {

        }

        public ProcessCellParameter(Procescell cell, ParameterDefinition param)
        {
            pca_ProcCellId = cell.prc_ProcescellId;
            pca_ParNm = param.paf_ParNm;
            pca_ParDesc = param.paf_ParDesc;
            Value = param.paf_DefValue;
            pca_ParValueUOM = param.paf_ParValueUOM;
            pca_DisplayToUser = param.paf_DisplayToUser;

            ProcessCell = cell;
            ParameterDefinition = param;
        }
    }
}
