using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Documents;
using ConfigurationToolStructurePOC.Business.Statics;
using ConfigurationToolStructurePOC.Business.Singleton;

namespace ConfigurationToolStructurePOC.Business.Services
{
    class ParameterDefinitionService
    {
        public IEnumerable<ParameterDefinition> GetAllParamaterDefinitions()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new ParameterDefinitionRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateNewParameterDefinition(ParameterDefinition parameterDefinition)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ParameterDefinitionRepository(context);
                repository.Add(parameterDefinition);
                context.SaveChanges();
            }
            OrderObservableList.AddSorted(GlobalListManagementClass.Instance.ParameterDefinitions, parameterDefinition);
        }

        public void DeleteParameterDefinition(ParameterDefinition parameterDefinition)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ParameterDefinitionRepository(context);
                repository.Delete(parameterDefinition);
                context.SaveChanges();
            }
        }

        public ParameterDefinition GenerateNewParameterDefinition(string name, string description, int beforesep, int afterSep, ParameterType type, Alignment alignm,
                                                                  int editable, int displayToUser)
        {
            //ruleset need to be used here

            ParameterDefinition paf = new ParameterDefinition()
            {
                paf_ParNm = name,
                paf_ParDesc = description,
                paf_BeforeSep = beforesep,
                paf_AfterSep = afterSep,
                paf_Type = type,
                paf_Alignm = alignm,
                paf_Editable = editable,
                paf_DisplayToUser = displayToUser.ToString()      
            };

            return paf;
      
        }


    }
}
