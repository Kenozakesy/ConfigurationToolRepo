using ConfigurationToolStructurePOC.Business.Enums;
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
    public class BinsInSubrouteService
    {
        public BinsInSubrouteService()
        {

        }

        #region Methods

        public void RemoveBinInSubroute(BinsInSubRoute bir)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new BinsInSubrouteRepository(context);
                repository.Delete(bir);
                context.SaveChanges();
            }
        }

        public void CreateBinInSubroute(BinsInSubRoute bir)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new BinsInSubrouteRepository(context);
                repository.Add(bir);
                context.SaveChanges();
            }
        }

        public BinsInSubRoute GenerateBinsInSubroute(Subroute subroute, Bin bin, SourceDest sourceDest)
        {
            return new BinsInSubRoute(subroute, bin, sourceDest);
        }

        public void RemoveRelationShips(BinsInSubRoute bir)
        {
            bir.Subroute.BinsInSubRoutes.Remove(bir);
            bir.Bin.BinsInSubRoutes.Remove(bir);

            bir.Subroute = null;
            bir.Bin = null;
        }

        public void AddRelationShips(BinsInSubRoute bir, Subroute subroute, Bin bin)
        {
            //add references to BinInSubroute
            bir.Bin = bin;
            bir.Subroute = subroute;

            //Add references to Bin and subroute
            subroute.BinsInSubRoutes.Add(bir);
            bin.BinsInSubRoutes.Add(bir);
        }

        #endregion

    }
}
