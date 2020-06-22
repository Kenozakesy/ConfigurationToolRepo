using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.UI.ViewModels;
using TreeViewExample.UI.Views;
using ConfigurationToolStructurePOC.UI.Interfaces;

namespace TreeViewExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITreeView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
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

        public void OpenCreateParameterWindow()
        {
            CreateParameterWindow window = new CreateParameterWindow();
            window.ShowDialog();
        }

        public void OpenEditSubrouteWindow(Route route)
        {
            EditSubrouteWindow window = new EditSubrouteWindow();
            ((EditSubrouteViewModel)window.DataContext).Route = route;
            ((EditSubrouteViewModel)window.DataContext).ManageLists();
            window.ShowDialog();
        }

        public void OpenParameterSheetWindow()
        {
            ParameterSheetWindow window = new ParameterSheetWindow();
            window.ShowDialog();
        }

        public void OpenCreateSubrouteWindow(ProcessCel processcel)
        {
            CreateSubrouteWindow window = new CreateSubrouteWindow();
            ((CreateSubrouteViewModel)window.DataContext).ProcesCell = processcel;
            window.ShowDialog();
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void OpenAddParameterToObjectWindow(IObjectWithParameters obj)
        {
            AddParameterToObjectWindow window = new AddParameterToObjectWindow();
            ((AddParameterToObjectViewModel)window.DataContext).ParameterObject = obj;
            ((AddParameterToObjectViewModel)window.DataContext).InitializeParameters();
            window.ShowDialog();
        }

        public void OpenCreateProcesCellWindow(ProcessCel cell)
        {
            CreateProcesCellWindow window = new CreateProcesCellWindow();
            ((CreateProcesCellViewModel)window.DataContext).ProcesCell = cell;
            window.ShowDialog();
        }

        public void OpenCreateRouteWindow(ProcessCel cell)
        {
            CreateRouteWindow window = new CreateRouteWindow();
            ((CreateRouteViewModel)window.DataContext).Procescell = cell;
            ((CreateRouteViewModel)window.DataContext).GenerateRoute();
            window.ShowDialog();
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void OpenSetBinsWindow(SubRoute subroute)
        {
            SetBinsWindow window = new SetBinsWindow();
            ((SetBinsViewModel)window.DataContext).Subroute = subroute;
            ((SetBinsViewModel)window.DataContext).GetSourceDestinationLists();
            window.ShowDialog();
        }




        public void OpenCreateRouteWindow(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
