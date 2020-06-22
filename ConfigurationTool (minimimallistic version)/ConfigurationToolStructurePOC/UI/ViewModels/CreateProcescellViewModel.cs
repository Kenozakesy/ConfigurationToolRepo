using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.Business.Singleton;
using ConfigurationToolStructurePOC.Business.Statics;
using ConfigurationToolStructurePOC.UI.Commands;
using ConfigurationToolStructurePOC.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    public class CreateProcescellViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Procescell> _Procescells = GlobalListManagementClass.Instance.Procescells;

        private ICreateProcescellView _View;
        public CreateProcescellViewModel(ICreateProcescellView view) : base(view)
        {
            _View = view;
            InitializeCommand();
        }

        #region Properties

        public Procescell Procescell { get; set; }
        public ObservableCollection<Procescell> Procescells
        {
            get { return _Procescells; }
            set { SetProperty(ref _Procescells, value); }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void CreateProcescell()
        {
            ProcessCellService service = new ProcessCellService();
            service.CreateNewProcescell(Procescell);

            OrderObservableList.AddSorted(Procescells, Procescell);
            _View.CloseWindow();
        }

        #endregion

        #region commandlogic

        private void InitializeCommand()
        {
            CreateProcescellCommand = new RelayCommand(CreateProcescell);
        }

        public ICommand CreateProcescellCommand { get; set; }


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
