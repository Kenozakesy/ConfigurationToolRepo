using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Interfaces;
using ConfigurationToolStructurePOC.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConfigurationToolStructurePOC.Business.Model
{
    public abstract class TreeViewObject : ViewModelBase, ITreeViewObject
    {
        private Brush _Colour;
        private Validation _Valid;

        public TreeViewObject()
        {
            Valid = Validation.Valid;
            Colour = Brushes.LightGreen;
        }

        #region Properties

        [NotMapped]
        public virtual Brush Colour
        {
            get { return _Colour; }
            set { SetProperty(ref _Colour, value); } 
        }

        [NotMapped]
        public Validation Valid
        {
            get { return _Valid; }
            set { SetProperty(ref _Valid, value); }
        }

        #endregion 

        #region Methods

        public abstract void DeleteTreeViewObject();
        public abstract string GetName();
        public abstract int CompareTo(object obj);

        #endregion





    }
}
