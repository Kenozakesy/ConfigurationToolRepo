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
    class RouteParameterService
    {
        public IEnumerable<RouteParameter> GetAllBinParameters()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new RouteParameterRepository(context);
                return repository.GetAll();
            }
        }

        public void CreateNewBinParameter(RouteParameter routeParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new RouteParameterRepository(context);
                repository.Add(routeParameter);
                context.SaveChanges();
            }
        }

        public void DeleteBinParameter(RouteParameter routeParameter)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new RouteParameterRepository(context);
                repository.Delete(routeParameter);
                context.SaveChanges();
            }
        }
    }
}
