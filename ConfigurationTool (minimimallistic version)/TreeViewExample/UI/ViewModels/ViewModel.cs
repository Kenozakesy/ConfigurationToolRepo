using System.ComponentModel;
using ConfigurationToolStructurePOC.UI.Interfaces;

namespace ConfigurationToolStructurePOC.UI.ViewModels
{
    public class ViewModel
    {
        public IView View { get; private set; }
        public ViewModel(IView view)
        {
            View = view;
        }

    }
}
