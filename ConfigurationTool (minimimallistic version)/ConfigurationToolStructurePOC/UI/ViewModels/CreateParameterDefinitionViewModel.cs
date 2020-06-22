using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Services;
using ConfigurationToolStructurePOC.UI.Commands;
using ConfigurationToolStructurePOC.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    public class CreateParameterDefinitionViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private List<ParameterType> _TypeValuesList = new List<ParameterType>();
        private List<Alignment> _AlignmentValuesList = new List<Alignment>();

        //required
        private string _ParNm;
        private string _ParDesc;
        private int _BeforeSep;
        private int _AfterSep;
        private ParameterType _Type;
        private Alignment _Alignm;
        private int _Editable;
        private int _DisplayToUser;

        //not required (implement later)

        #endregion
                          
        private ICreateParameterDefinitionView _View;
        public CreateParameterDefinitionViewModel(ICreateParameterDefinitionView view) : base(view)
        {
            this._View = view;
            InitializeCommand();
        }

        #region Properties

        public List<ParameterType> TypeValuesList
        {
            get
            {
                return Enum.GetValues(typeof(ParameterType)).Cast<ParameterType>().ToList();
            }
            set { SetProperty(ref _TypeValuesList, value); }
        }
        public List<Alignment> AlignmentValuesList
        {
            get
            {
                return Enum.GetValues(typeof(Alignment)).Cast<Alignment>().ToList();
            }
            set { SetProperty(ref _AlignmentValuesList, value); }
        }

        //required
        public string ParNm
        {
            get { return _ParNm; }
            set { SetProperty(ref _ParNm, value); }
        }
        public string ParDesc
        {
            get { return _ParDesc; }
            set { SetProperty(ref _ParDesc, value); }
        }
        public int BeforeSep
        {
            get { return _BeforeSep; }
            set { SetProperty(ref _BeforeSep, value); }
        }
        public int AfterSep
        {
            get { return _AfterSep; }
            set { SetProperty(ref _AfterSep, value); }
        }
        public ParameterType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }
        public Alignment Alignm
        {
            get { return _Alignm; }
            set { SetProperty(ref _Alignm, value); }
        }
        public int Editable
        {
            get { return _Editable; }
            set { SetProperty(ref _Editable, value); }
        }
        public int DisplayToUser
        {
            get { return _DisplayToUser; }
            set { SetProperty(ref _DisplayToUser, value); }
        }


        #endregion

        #region Methods

        private void ClearWindow()
        {
            ParNm = "";
            ParDesc = "";
            BeforeSep = 0;
            AfterSep = 0;           
        }

        #endregion

        #region ItemHandlers

        private void CreateCustomParameter()
        {
            ParameterDefinitionService service = new ParameterDefinitionService();
            ParameterDefinition paf = service.GenerateNewParameterDefinition(_ParNm, _ParDesc, _BeforeSep, _AfterSep, _Type, _Alignm, _Editable, _DisplayToUser);
            if (paf == null)
            {
                _View.ShowMessage("One or more attributes are incorrect. Creation has been cancelled");
            }
            else 
            {
                service.CreateNewParameterDefinition(paf);
                _View.ShowMessage("New ParameterDefinition has been created");
                ClearWindow();
            }
        }    

        #endregion

        #region Commandlogic
        private void InitializeCommand()
        {
            CreateCustomParameterCommand = new RelayCommand(CreateCustomParameter);
        }

        public ICommand CreateCustomParameterCommand { get; set; }


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
