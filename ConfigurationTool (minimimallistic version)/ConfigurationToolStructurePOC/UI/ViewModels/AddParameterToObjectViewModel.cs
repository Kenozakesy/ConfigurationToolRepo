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
    public class AddParameterToObjectViewModel : ViewModel, INotifyPropertyChanged
    {

        private IAddParameterToObjectView _IAddParameterToObjectView;
        public AddParameterToObjectViewModel(IAddParameterToObjectView view)
            : base(view)
        {
            this._IAddParameterToObjectView = view;
            InitializeCommand();
        }

        #region Properties

    

        #endregion

        #region Methods

        #endregion

        #region ItemHandlers

        #endregion

        #region Commandlogic

        private void InitializeCommand()
        {

        }

        //public ICommand RemoveParameterCommand { get; set; }


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
