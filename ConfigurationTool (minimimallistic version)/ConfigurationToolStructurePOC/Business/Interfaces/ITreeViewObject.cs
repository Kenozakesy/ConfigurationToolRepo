using ConfigurationToolStructurePOC.Business.Enums;
using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConfigurationToolStructurePOC.Business.Interfaces
{
    public interface ITreeViewObject : IComparable
    {
        Brush Colour { get; set; }
        Validation Valid { get; set; }

        void DeleteTreeViewObject();
    }
}
