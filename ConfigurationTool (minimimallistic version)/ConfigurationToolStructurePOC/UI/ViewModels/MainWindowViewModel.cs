using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ConfigurationToolStructurePOC.UI.Commands;
using ConfigurationToolStructurePOC.UI.Interfaces;
using ConfigurationToolStructurePOC.UI.ViewModels;
using ConfigurationToolStructurePOC.DAL.Repositories;
using ConfigurationToolStructurePOC.DAL.Context;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Singleton;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    public class MainWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Procescell> _Procescells = new ObservableCollection<Procescell>();
        private ObservableCollection<Bin> _Bins = new ObservableCollection<Bin>();
        private ObservableCollection<ParameterDefinition> _ParametersDefinitions = new ObservableCollection<ParameterDefinition>();
        private ObservableCollection<OAUnitDefinition> _Units = new ObservableCollection<OAUnitDefinition>();
     

        private IMainView _MainView;
        public MainWindowViewModel(IMainView view) : base(view)
        {
            _MainView = view;
            InitializeCommand();

            //GlobalListManagementClass.Instance.LoadDataFromDB();
            _Procescells = GlobalListManagementClass.Instance.Procescells;
            _Bins = GlobalListManagementClass.Instance.Bins;
            _ParametersDefinitions = GlobalListManagementClass.Instance.ParameterDefinitions;
            _Units = GlobalListManagementClass.Instance.Units;
        }

        #region Properties

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
        public ObservableCollection<ParameterDefinition> ParametersDefinitions
        {
            get { return _ParametersDefinitions; }
            set { SetProperty(ref _ParametersDefinitions, value); }
        }
        public ObservableCollection<OAUnitDefinition> Units
        {
            get { return _Units; }
            set { SetProperty(ref _Units, value); }
        }


        public List<ProcescellType> ProcesCellTypes
        {
            get
            {
                return Enum.GetValues(typeof(ProcescellType)).Cast<ProcescellType>().ToList();
            }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void OpenCreateProcescellWindow(ProcescellType celltype)
        {
            ProcessCellService service = new ProcessCellService();
            Procescell procescell = service.GenerateNextProcescell(celltype, Procescells);
            _MainView.OpenCreateProcescellView(procescell);
        }

        private void OpenCreateParameterDefinitionWindow()
        {
            _MainView.OpenCreateParameterDefinitionWindow();
        }

        private void OpenSetBinsWindow(SubroutesInRoute subrouteInRoute)
        {
            _MainView.OpenSetBinsWindow(subrouteInRoute.Subroute);
        }

        private void DeleteObject(TreeViewObject treeViewObject)
        {
            if (_MainView.ConfirmMessage("delete " + treeViewObject.GetName(), "Are you sure you want to delete " + treeViewObject.GetName() + "?"))
            {
                treeViewObject.DeleteTreeViewObject();
                if (treeViewObject is Procescell)
                {
                    Procescell cell = treeViewObject as Procescell;
                    Procescells.Remove(cell);
                }
            }
        }

        private void OpenCreateRouteWindow(Procescell procescell)
        {
            _MainView.OpenCreateRouteWindow(procescell);
        }

        private void OpenEditSubrouteWindow(Route route)
        {
            _MainView.OpenEditSubrouteWindow(route);
        }

        private void OpenCreateSubrouteWindow(Procescell procescell)
        {
            _MainView.OpenCreateSubrouteWindow(procescell);
        }

        private void OpenCreateBinWindow()
        {
            _MainView.OpenCreateBinWindow();
        }

        #endregion

        #region commandlogic

        private void InitializeCommand()
        {
            OpenCreateProcescellWindowCommand = new RelayCommandT1<ProcescellType>(OpenCreateProcescellWindow);
            OpenCreateParameterDefinitionWindowCommand = new RelayCommand(OpenCreateParameterDefinitionWindow);
            OpenSetBinsWindowCommand = new RelayCommandT1<SubroutesInRoute>(OpenSetBinsWindow);
            DeleteObjectCommand = new RelayCommandT1<TreeViewObject>(DeleteObject);
            OpenEditSubrouteWindowCommand = new RelayCommandT1<Route>(OpenEditSubrouteWindow);
            OpenCreateRouteWindowCommand = new RelayCommandT1<Procescell>(OpenCreateRouteWindow);
            OpenCreateSubrouteWindowCommand = new RelayCommandT1<Procescell>(OpenCreateSubrouteWindow);
            OpenCreateBinWindowCommand = new RelayCommand(OpenCreateBinWindow);
        }

        public ICommand OpenCreateParameterDefinitionWindowCommand { get; set; }
        public ICommand OpenCreateProcescellWindowCommand { get; set; }
        public ICommand OpenEditSubrouteWindowCommand { get; set; }
        public ICommand OpenSetBinsWindowCommand { get; set; }
        public ICommand DeleteObjectCommand { get; set; }
        public ICommand OpenCreateRouteWindowCommand { get; set; }
        public ICommand OpenCreateSubrouteWindowCommand { get; set; }
        public ICommand OpenCreateBinWindowCommand { get; set; }
        
                               

        #endregion

        #region property change logic

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));	
        }

        #endregion
    }
}
