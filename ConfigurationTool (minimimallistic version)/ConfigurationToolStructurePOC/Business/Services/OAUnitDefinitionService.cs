using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class OAUnitDefinitionService
    {
        public IEnumerable<OAUnitDefinition> GetAllUnits()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new OAUnitDefinitionRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateUnit(OAUnitDefinition unit)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new OAUnitDefinitionRepository(context);
                repository.Add(unit);
                context.SaveChanges();
            }
        }

        //Cannot delete children yet
        public void DeleteUnit(OAUnitDefinition unit)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new OAUnitDefinitionRepository(context);
                repository.Delete(unit);
                context.SaveChanges();
            }
        }
    }
}
