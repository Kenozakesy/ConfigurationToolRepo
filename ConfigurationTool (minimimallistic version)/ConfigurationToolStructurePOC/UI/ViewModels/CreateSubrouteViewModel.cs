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
    public class CreateSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
         #region Fields

        private Procescell _Procescell;
        private string _SubrouteName;

        #endregion

        private ICreateSubrouteView _View;
        public CreateSubrouteViewModel(ICreateSubrouteView view)
            : base(view)
        {
            this._View = view;
            InitializeCommand();
        }

        #region Properties

        public Procescell Procescell
        {
            get { return _Procescell; }
            set { SetProperty(ref _Procescell, value); }
        }
        public string SubrouteName
        {
            get { return _SubrouteName; }
            set { SetProperty(ref _SubrouteName, value); }
        }

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        private void CreateNewSubroute()
        {
            if (string.IsNullOrEmpty(SubrouteName))
            {
                _View.ShowMessage("Please choose a name.");
            }
            else
            {
                SubrouteService service = new SubrouteService();
                Subroute subroute = service.GenerateNewSubroute(Procescell, SubrouteName);
                service.CreateSubroute(subroute);
                service.AddSubrouteToCell(Procescell, subroute);
            }
        }

        private void DeleteClick(TreeViewObject obj)
        {
            if (_View.ConfirmMessage("delete " + obj.GetName(), "Are you sure you want to delete " + obj.GetName() + "?"))
            {
                try
                {
                    if (obj != null)
                    {
                        obj.DeleteTreeViewObject();
                    }
                }
                catch (NotImplementedException e)
                {
                    e.ToString();
                    _View.ShowMessage("This functionality has not been implemented yet.");
                }
            }
        }

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {
            CreateNewSubrouteCommand = new RelayCommand(CreateNewSubroute);
            DeleteClickCommand = new RelayCommandT1<TreeViewObject>(DeleteClick);
        }
        public ICommand CreateNewSubrouteCommand { get; set; }
        public ICommand DeleteClickCommand { get; set; }

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
