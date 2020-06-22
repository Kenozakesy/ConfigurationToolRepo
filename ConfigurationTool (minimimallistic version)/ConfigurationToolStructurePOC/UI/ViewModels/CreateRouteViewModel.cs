using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.UI.Interfaces;
using ConfigurationToolStructurePOC.UI.Commands;
using ConfigurationToolStructurePOC.Business.Services;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    public class CreateRouteViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Route _Route;

        #endregion

        private ICreateRouteView _View;

        public CreateRouteViewModel(ICreateRouteView view) : base(view)
        {
            _View = view;
            InitializeCommand();
        }

        #region Properties

        public Route Route
        {
            get { return _Route; }
            set { SetProperty(ref _Route, value); }
        }
        public Procescell Procescell { get; set; }

        #endregion

        #region Methods

        public void GenerateRoute()
        {
            RouteService service = new RouteService();
            Route = service.GenerateNewRoute(Procescell);
        }

        #endregion

        #region ItemHandlers

        private void CreateRoute()
        {
            RouteService service = new RouteService();
            service.CreateNewRoute(Route, Procescell);
            service.ConnectRouteToCell(Procescell, Route);
            _View.CloseWindow();
        }

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {
            CreateRouteCommand = new RelayCommand(CreateRoute);
        }

        public ICommand CreateRouteCommand { get; set; }


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
