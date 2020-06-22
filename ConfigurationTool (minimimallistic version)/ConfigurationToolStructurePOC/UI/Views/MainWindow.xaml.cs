using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.UI.Interfaces;
using ConfigurationToolStructurePOC.UI.ViewModels;
using ConfigurationToolStructurePOC.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ConfigurationToolStructurePOC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public bool ConfirmMessage(string title, string text)
        {
            if (MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void OpenCreateProcescellView(Procescell procescell)
        {
            CreateProcesCellWindow window = new CreateProcesCellWindow();
            ((CreateProcescellViewModel)window.DataContext).Procescell = procescell;
            window.ShowDialog();
        }

        public void OpenCreateParameterDefinitionWindow()
        {
            CreateParameterDefinitionWindow window = new CreateParameterDefinitionWindow();
            window.ShowDialog();
        }

        public void OpenSetBinsWindow(Subroute subroute)
        {
            SetBinsWindow window = new SetBinsWindow();
            ((SetBinsViewModel)window.DataContext).Subroute = subroute;
            ((SetBinsViewModel)window.DataContext).GetSourceDestinationLists();
            window.ShowDialog();
        }

        public void OpenEditSubrouteWindow(Route route)
        {
            EditSubrouteWindow window = new EditSubrouteWindow();
            ((EditSubrouteViewModel)window.DataContext).Route = route;
            ((EditSubrouteViewModel)window.DataContext).ArrangeSequences();
            window.ShowDialog();
        }

        public void OpenCreateRouteWindow(Procescell cell)
        {
            CreateRouteWindow window = new CreateRouteWindow();
            ((CreateRouteViewModel)window.DataContext).Procescell = cell;
            ((CreateRouteViewModel)window.DataContext).GenerateRoute();
            window.ShowDialog();
        }

        public void OpenCreateSubrouteWindow(Procescell procescell)
        {
            CreateSubrouteWindow window = new CreateSubrouteWindow();
            ((CreateSubrouteViewModel)window.DataContext).Procescell = procescell;
            window.ShowDialog();
        }

        public void OpenCreateBinWindow()
        {
            CreateBinWindow window = new CreateBinWindow();
            window.ShowDialog();
        }
    }
}
