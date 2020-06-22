using ConfigurationToolStructurePOC.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public class Sequence : ViewModelBase, IComparable
    {
        private ObservableCollection<SubroutesInRoute> _SubrouteInRoute = new ObservableCollection<SubroutesInRoute>();
        private int _Id;

        public Sequence(int Id)
        {
            _Id = Id;        
        }

        #region Propertys

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        public ObservableCollection<SubroutesInRoute> SubrouteInRoute
        {
            get { return _SubrouteInRoute; }
            set { SetProperty(ref _SubrouteInRoute, value); }
        }

        #endregion


        public int CompareTo(object obj)
        {
            Sequence seq = obj as Sequence;

            if (Id < seq.Id)
                return -1;
            else if (Id > seq.Id)
                return 1;
            return 0;


        }
    }
}
