using System.ComponentModel;
using ConfigurationToolStructurePOC.UI.Interfaces;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    class ViewModel
    {
  
        public IView View { get; private set; }
        public ViewModel(IView view)
        {
            View = view;
        }

    }
}
