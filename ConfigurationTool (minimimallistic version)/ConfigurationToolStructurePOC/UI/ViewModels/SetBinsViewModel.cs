using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.Business.Singleton;
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
    public class SetBinsViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Bin> _Bins = new ObservableCollection<Bin>();
        private ObservableCollection<BinsInSubRoute> _DestinationBins = new ObservableCollection<BinsInSubRoute>();
        private ObservableCollection<BinsInSubRoute> _SourceBins = new ObservableCollection<BinsInSubRoute>();
        private Subroute _Subroute;

        #endregion

        private ISetBinsView _View;
        public SetBinsViewModel(ISetBinsView view) : base(view)
        {
            _View = view;
            InitializeCommand();

            _Bins = GlobalListManagementClass.Instance.Bins;

            SelectedBins = new ObservableCollection<Bin>();
            SelectedDestinationBins = new ObservableCollection<BinsInSubRoute>();
            SelectedSourceBins = new ObservableCollection<BinsInSubRoute>();
        }

        #region Properties

        public Subroute Subroute
        {
            get { return _Subroute; }
            set { SetProperty(ref _Subroute, value); }
        }

        public ObservableCollection<Bin> Bins
        {
            get { return _Bins; }
            set { SetProperty(ref _Bins, value); }
        }
        public ObservableCollection<BinsInSubRoute> DestinationBins
        {
            get { return _DestinationBins; }
            set { SetProperty(ref _DestinationBins, value); }
        }
        public ObservableCollection<BinsInSubRoute> SourceBins
        {
            get { return _SourceBins; }
            set { SetProperty(ref _SourceBins, value); }
        }

        public ObservableCollection<Bin> SelectedBins { get; set; }
        public ObservableCollection<BinsInSubRoute> SelectedDestinationBins { get; set; }
        public ObservableCollection<BinsInSubRoute> SelectedSourceBins { get; set; }

        #endregion


        #region Methods

        public void GetSourceDestinationLists()
        {
            SubrouteService service = new SubrouteService();
            SourceBins = new ObservableCollection<BinsInSubRoute>(service.GetAllSourcebins(Subroute));
            DestinationBins = new ObservableCollection<BinsInSubRoute>(service.GetAllDestinationBins(Subroute));           
        }

        #endregion


        #region ItemHandlers

        private void RemoveSourceBin()
        {
            BinsInSubrouteService service = new BinsInSubrouteService();

            foreach (BinsInSubRoute bir in SelectedSourceBins)
            {
                //remove from database
                service.RemoveBinInSubroute(bir);

                //remove relationships
                service.RemoveRelationShips(bir);
            }

            GetSourceDestinationLists();
        }

        private void RemoveDestinationBin()
        {
            BinsInSubrouteService service = new BinsInSubrouteService();

            foreach (BinsInSubRoute bir in SelectedDestinationBins)
            {
                //remove from database
                service.RemoveBinInSubroute(bir);

                //remove relationships
                service.RemoveRelationShips(bir);
            }
            GetSourceDestinationLists();
        }

        private void AddSourceBin()
        {
            BinsInSubrouteService service = new BinsInSubrouteService();
            
            foreach (Bin B in SelectedBins)
            {
                //generate new binsinsubroute
                BinsInSubRoute bir = service.GenerateBinsInSubroute(Subroute, B, SourceDest.S);

                //if it already exists continue
                if(SourceBins.Any(item => item.bir_BinId == bir.bir_BinId))
                {
                   continue;
                }

                //create new database entry
                service.CreateBinInSubroute(bir);

                //connect relationships
                service.AddRelationShips(bir, Subroute, B);
            }
            GetSourceDestinationLists();
        }

        private void AddDestinationBin()
        {
            BinsInSubrouteService service = new BinsInSubrouteService();

            foreach (Bin B in SelectedBins)
            {
                //generate new binsinsubroute
                BinsInSubRoute bir = service.GenerateBinsInSubroute(Subroute, B, SourceDest.D);

                //if it already exists continue
                if (DestinationBins.Any(item => item.bir_BinId == bir.bir_BinId))
                {
                    continue;
                }

                //create new database entry
                service.CreateBinInSubroute(bir);

                //connect relationships
                service.AddRelationShips(bir, Subroute, B);

            }
            GetSourceDestinationLists();
        }

        #endregion


        #region Commandlogic

        private void InitializeCommand()
        {
            RemoveSourceBinCommand = new RelayCommand(RemoveSourceBin);
            AddSourceBinCommand = new RelayCommand(AddSourceBin);
            RemoveDestinationBinCommand = new RelayCommand(RemoveDestinationBin);
            AddDestinationBinCommand = new RelayCommand(AddDestinationBin);
        }

        public ICommand RemoveSourceBinCommand { get; set; }
        public ICommand AddSourceBinCommand { get; set; }
        public ICommand RemoveDestinationBinCommand { get; set; }
        public ICommand AddDestinationBinCommand { get; set; }

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
