using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Singleton
{
    public class GlobalListManagementClass : ViewModelBase
    {
        #region Fields

        private static GlobalListManagementClass _Instance;
        private ObservableCollection<Procescell> _Procescells;
        private ObservableCollection<Bin> _Bins;
        private ObservableCollection<ParameterDefinition> _ParameterDefinitions;
        private ObservableCollection<OAUnitDefinition> _Units;
        #endregion

        private GlobalListManagementClass()
        {
            ManageFactoryConfig();
        }

        #region Properties

        public static GlobalListManagementClass Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GlobalListManagementClass();
                }
                return _Instance;
            }
        }


        public ObservableCollection<Procescell> Procescells
        {
            get { return _Procescells; }
            set { SetProperty(ref _Procescells, value); }
        }
        public ObservableCollection<Bin> Bins
        {
            get { return _Bins; }
            set { SetProperty(ref _Bins, value); }
        }
        public ObservableCollection<ParameterDefinition> ParameterDefinitions
        {
            get { return _ParameterDefinitions; }
            set { SetProperty(ref _ParameterDefinitions, value); }
        }

        public ObservableCollection<OAUnitDefinition> Units
        {
            get { return _Units; }
            set { SetProperty(ref _Units, value); }
        }

        #endregion

        #region Methods

        private void ManageFactoryConfig()
        {
            ProcessCellService service = new ProcessCellService();
            FactoryConfig factory = service.GetFactoryConfig();

            Procescells = new ObservableCollection<Procescell>(factory.Procescells);
            Bins = new ObservableCollection<Bin>(factory.Bins);
            ParameterDefinitions = new ObservableCollection<ParameterDefinition>(factory.ParameterDefinitions);
            Units = new ObservableCollection<OAUnitDefinition>(factory.OAUnitDefinitions);
        }

        #endregion



    }
}
