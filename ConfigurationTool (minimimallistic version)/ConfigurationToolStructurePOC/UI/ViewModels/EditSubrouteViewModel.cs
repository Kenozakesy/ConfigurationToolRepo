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
    public class EditSubrouteViewModel : ViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Sequence> _Sequences = new ObservableCollection<Sequence>();
        private ObservableCollection<Subroute> _SubroutesNotinRoute = new ObservableCollection<Subroute>();
        private ObservableCollection<Subroute> _SelectedSubroutes = new ObservableCollection<Subroute>();
        private Route _Route;

        private IEditSubrouteView _View;
        public EditSubrouteViewModel(IEditSubrouteView view) : base(view)
        {
            _View = view;
            InitializeCommand();
        }

        #region Properties

        public ObservableCollection<Sequence> Sequences
        {
            get { return _Sequences; }
            set { SetProperty(ref _Sequences, value); }
        }
        public ObservableCollection<Subroute> SubroutesNotinRoute
        {
            get { return _SubroutesNotinRoute; }
            set { SetProperty(ref _SubroutesNotinRoute, value); }
        }
        public ObservableCollection<Subroute> SelectedSubroutes
        {
            get { return _SelectedSubroutes; }
            set { SetProperty(ref _SelectedSubroutes, value); }
        }
        public Route Route
        {
            get { return _Route; }
            set { SetProperty(ref _Route, value); }
        }


        #endregion

        #region Methods

        //refreshes the entire screen
        public void ArrangeSequences()
        {
            //arrange subroutes not in route
            SubrouteService subService = new SubrouteService();
            SubroutesNotinRoute = new ObservableCollection<Subroute>(subService.GetSubroutesNotInRoute(Route));

            //generate sequences here (sequence service + getlist sequences)
            SequenceService seqService = new SequenceService();
            Sequences = new ObservableCollection<Sequence>(seqService.GetSequences(Route));            
        }

        #endregion

        #region ItemHandlers

        private void AddSequence()
        {
            SequenceService service = new SequenceService();
            Sequence sequence = service.GenerateNextSequence(Sequences);
            OrderObservableList.AddSorted(Sequences, sequence);
        }

        private void RemoveSubrouteFromRoute(SubroutesInRoute subrouteInRoute)
        { 
            //remove from database
            SubrouteInRouteService service = new SubrouteInRouteService();
            service.DeleteSubrouteInRoute(subrouteInRoute);

            //remove from overall structure
            service.RemoveRelationShips(subrouteInRoute);

            ArrangeSequences();
        }

        private void AddSubroutesToSequence(Sequence sequence)
        {
            if (SelectedSubroutes.Count == 0)
            {
                _View.ShowMessage("Select one or multiple routes to add");
                return;
            }


            foreach (Subroute S in SelectedSubroutes)
            {
                //Add to database
                SubrouteInRouteService service = new SubrouteInRouteService();
                SubroutesInRoute subrouteInRoute = service.GenerateNewSubrouteInRoute(S, Route, sequence.Id);
                service.CreateSubrouteInRoute(subrouteInRoute);

                //add to overall structure
                service.AddRelationShips(subrouteInRoute, S, Route); 
            }
     
            ArrangeSequences();
        }

        #endregion

        #region commandlogic

        private void InitializeCommand()
        {
            AddSequenceCommand = new RelayCommand(AddSequence);
            RemoveSubrouteFromRouteCommand = new RelayCommandT1<SubroutesInRoute>(RemoveSubrouteFromRoute);
            AddSubroutesToSequenceCommand = new RelayCommandT1<Sequence>(AddSubroutesToSequence);
        }

        public ICommand AddSequenceCommand { get; set; }
        public ICommand RemoveSubrouteFromRouteCommand { get; set; }
        public ICommand AddSubroutesToSequenceCommand { get; set; }
                                     
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
