using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Singleton;
using ConfigurationToolStructurePOC.Business.Statics;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class BinService
    {
        public BinService()
        {

        }

        #region Methods

        public void CreateNewBin(Bin bin)
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new BinRepository(context);
                repository.Add(bin);
                context.SaveChanges();
            }
            OrderObservableList.AddSorted(GlobalListManagementClass.Instance.Bins, bin);          
        }

        public void DeleteBin(Bin bin)
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new BinRepository(context);
                repository.Delete(bin);
                context.SaveChanges();

                GlobalListManagementClass.Instance.Bins.Remove(bin);
            }
        }

        public IEnumerable<Bin> GetAllBins()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new BinRepository(context);
                return repository.GetAll();
            }
        }

        public IEnumerable<string> GetAllBinTypes()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new BinRepository(context);
                return repository.GetAllBinTypes();
            }
        }

        public void RemoveRelationShips(Bin bin)
        {
            foreach (BinsInSubRoute bir in bin.BinsInSubRoutes)
            {
                bir.Bin.BinsInSubRoutes.Remove(bir);
                bir.Subroute.BinsInSubRoutes.Remove(bir);
            }       
        }


        //combine these methods together?
        public bool CheckParameters(string numberOfBins, string startingNumber)
        {
           //check number of bins
           int n;
           bool isNumberOfNumeric = int.TryParse(numberOfBins, out n);

           //check stating number
           int t;
           bool isStartNumeric = int.TryParse(numberOfBins, out t);

           if (isNumberOfNumeric && isStartNumeric)
           {  
                return true;
           }
           return false;
        }

        public List<Bin> GetAddAbleBinList(string prefix, string numberOfBins, string startingNumber, string binType)
        {
            //number of bins to create
            int totalbinsToCreate = Convert.ToInt32(numberOfBins);
            int startnumber = Convert.ToInt32(startingNumber);

            //Create pre-zeros
            int count = startingNumber.TakeWhile(x => x == '0').Count();
            string preZeros = "";
            for (int i = 0; i < count; i++)
            {
                preZeros += "0";
            }

            //Create Bins
            List<Bin> binList = new List<Bin>();
            for (int i = 0; i < totalbinsToCreate; i++)
            {
                string binid = prefix + (preZeros + (startnumber + i).ToString());
                Bin bin = new Bin(binid, binType);
                binList.Add(bin);
            }

            //exclude already existing bins
            List<Bin> ExistingBins = binList.Where(x => GlobalListManagementClass.Instance.Bins.Any(y => y.bin_BinId == x.bin_BinId)).ToList();
            foreach (Bin B in ExistingBins)
            {
                binList.Remove(B);
            }       
            return binList;        
        }

        #endregion 
    }
}
