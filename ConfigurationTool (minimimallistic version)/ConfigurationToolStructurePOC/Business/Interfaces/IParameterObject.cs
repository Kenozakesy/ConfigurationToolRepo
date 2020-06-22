using ConfigurationToolStructurePOC.Business.Model;

namespace ConfigurationToolStructurePOC.Business.Interfaces
{
    public interface IParameterObject
    {
        string Value { get; set; }
        ParameterDefinition ParameterDefinition { get; set; }
    }
}
