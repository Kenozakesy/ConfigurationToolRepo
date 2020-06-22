using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class ProcessCellService
    {

        public ProcessCellService()
        {
        }

        #region Methods

        //Gets Procescells, Units, Bins & ParameterDefinitions
        public FactoryConfig GetFactoryConfig()
        {
            using (var context = new ConfigurationToolContext())
            {
                var procescellRepository = new ProcessCellRepository(context);
                var binRepository = new BinRepository(context);
                var parameterDefinitionRepository = new ParameterDefinitionRepository(context);
                var OAUnitDefinitionRepository = new OAUnitDefinitionRepository(context);
                var factoryConfig = new FactoryConfig();

                factoryConfig.ParameterDefinitions = parameterDefinitionRepository.GetAll();
                factoryConfig.Procescells = procescellRepository.GetAll();
                factoryConfig.Bins = binRepository.GetAll();
                factoryConfig.OAUnitDefinitions = OAUnitDefinitionRepository.GetAll();

                return factoryConfig;
            }
        }

        public IEnumerable<Procescell> GetAllProcCells()
        {
            using (var context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellRepository(context);
                return repository.GetAll();
            }
        }


        public void CreateNewProcescell(Procescell procescell)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellRepository(context);
                var parameterDefinitionRepository = new ParameterDefinitionRepository(context);

                //Gets required parameters for a new procescell
                IEnumerable<ParameterDefinition> requiredParameters;
                requiredParameters = parameterDefinitionRepository.GetRequiredParameters("pca_ProcCellPars", procescell.prc_ProcescellTypeId);

                //convert parDef to proccellPars and add them to the procescell
                foreach (ParameterDefinition paf in requiredParameters)
                {                    
                    ProcessCellParameter pca = new ProcessCellParameter(procescell, paf);
                    procescell.ProcessCellParameters.Add(pca);                
                }

                //this always happens at the end of the method
                repository.Add(procescell);
                context.SaveChanges();
            }
        }

        public void DeleteProcescell(Procescell procescell)
        {
            using (ConfigurationToolContext context = new ConfigurationToolContext())
            {
                var repository = new ProcessCellRepository(context);
                repository.Delete(procescell);
                context.SaveChanges();
            }
        }

        public bool ValidateProcesCell(Procescell procescell)
        {
            return true;
        }

        public Procescell GenerateNextProcescell(ProcescellType celltype, ICollection<Procescell> Procescells)
        {
            List<int> procIds = new List<int>();
            foreach (Procescell r in Procescells)
            {
                if (celltype.ToString() == r.prc_ProcescellTypeId)
                {
                    string routeid = new string(r.prc_ProcescellId.Where(char.IsDigit).ToArray());
                    procIds.Add(Convert.ToInt32(routeid));
                }
            }
            int firstAvailable = Enumerable.Range(1, int.MaxValue).Except(procIds).FirstOrDefault();

            Procescell procescell = new Procescell(celltype, firstAvailable);

            return procescell;
        }

        #endregion
    }
}
