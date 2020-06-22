using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Services;
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
    public class CreateBinViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<string> _Bintypes = new ObservableCollection<string>();

        private string _Prefix;
        private string _NumberOfBins;
        private string _StartingNumber;
        private string _BinType;

        #endregion

        private ICreateBinView _view;
        public CreateBinViewModel(ICreateBinView view) : base(view)
        {
            this._view = view;
            InitializeCommand();

            BinService service = new BinService();
            _Bintypes = new ObservableCollection<string>(service.GetAllBinTypes());
            _BinType = _Bintypes.First();
        }

        #region Properties

        public ObservableCollection<string> Bintypes
        {
            get { return _Bintypes; }
            set { SetProperty(ref _Bintypes, value); }
        }

        public string Prefix
        {
            get { return _Prefix; }
            set { SetProperty(ref _Prefix, value); }
        }
        public string NumberOfBins
        {
            get { return _NumberOfBins; }
            set { SetProperty(ref _NumberOfBins, value); }
        }
        public string StartingNumber
        {
            get { return _StartingNumber; }
            set { SetProperty(ref _StartingNumber, value); }
        }
        public string BinType
        {
            get { return _BinType; }
            set { SetProperty(ref _BinType, value); }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void CreateBin()
        {
            BinService service = new BinService();

            //check if parameters are correct
            bool ParametersCorrect = service.CheckParameters(NumberOfBins, StartingNumber);
            if (!ParametersCorrect)
            {
                _view.ShowMessage("one or more parameters are incorrect. Creation has been cancelled.");
               return;
            }
            //exclude the same bins
            List<Bin> binList = service.GetAddAbleBinList(Prefix, NumberOfBins, StartingNumber, BinType);
            //create bin
            foreach (var B in binList)
            {
                service.CreateNewBin(B);
            }
            _view.ShowMessage("New bins have been created");

            //reset the screen (or make it close later)
            Prefix = "";
            NumberOfBins = "";
            StartingNumber = "";
            BinType = _Bintypes.First();
        }
    
        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            CreateBinCommand = new RelayCommand(CreateBin);
        }

        public ICommand CreateBinCommand { get; set; }


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
