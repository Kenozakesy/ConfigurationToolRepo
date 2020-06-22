using ConfigurationToolStructurePOC.Business.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.UI.Interfaces
{
    public interface IMainView : IView
    {
        void OpenCreateProcescellView(Procescell procescell);
        void OpenCreateParameterDefinitionWindow();
        void OpenSetBinsWindow(Subroute subroute);
        void OpenEditSubrouteWindow(Route route);
        void OpenCreateRouteWindow(Procescell procescell);
        void OpenCreateSubrouteWindow(Procescell procescell);
        void OpenCreateBinWindow();
        //void OpenAddParameterToObjectWindow();

    }
}
