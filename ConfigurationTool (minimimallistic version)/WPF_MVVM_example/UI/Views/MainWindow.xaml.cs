using System;
using System.Windows;
using ConfigurationToolStructurePOC.UI.ViewModels;
using ConfigurationToolStructurePOC.UI.Interfaces;

namespace ConfigurationToolStructurePOC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICalculateView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CalculateWindowViewModel(this);
        }

        #region interface methods

        public int Calculate()
        {
            throw new NotImplementedException("show calculation here");
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show("The number is: " + text);
        }

        #endregion
    }
}
