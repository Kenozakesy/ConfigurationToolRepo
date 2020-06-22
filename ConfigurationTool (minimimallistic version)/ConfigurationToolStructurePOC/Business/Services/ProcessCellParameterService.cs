
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System.Collections.Generic;
namespace ConfigurationToolStructurePOC.Business.Services
{
    public class ProcessCellParameterService
    {
        public IEnumerable<ProcessCellParameter> GetAllProcessCellParameters()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellParameterRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateNewProcessCellParameter(ProcessCellParameter processCellParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellParameterRepository(context);
                repository.Add(processCellParameter);
                context.SaveChanges();
            }
        }

        public void DeleteProcessCellParameter(ProcessCellParameter processCellParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellParameterRepository(context);
                repository.Delete(processCellParameter);
                context.SaveChanges();
            }
        }
    }
}
