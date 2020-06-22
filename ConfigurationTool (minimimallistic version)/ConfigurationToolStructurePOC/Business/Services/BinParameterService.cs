using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class BinParameterService
    {
        public IEnumerable<BinParameter> GetAllBinParameters()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new BinParameterRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateNewBinParameter(BinParameter binParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new BinParameterRepository(context);
                repository.Add(binParameter);
                context.SaveChanges();
            }
        }

        public void DeleteBinParameter(BinParameter binParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new BinParameterRepository(context);
                repository.Delete(binParameter);
                context.SaveChanges();
            }
        }
    }
}
