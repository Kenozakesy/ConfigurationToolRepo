using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.Business.Services
{
    public class SequenceService
    {
        public List<Sequence> GetSequences(Route route)
        { 
            List<Sequence> sequences = new List<Sequence>();
            List<SubroutesInRoute> subrouteinRoute = new List<SubroutesInRoute>(route.SubroutesInRoutes);

            IEnumerable<int> uniqueNumbers = subrouteinRoute.Select(x => x.sri_SeqNr).Distinct();            
                                                        
            foreach (int I in uniqueNumbers)
            {
                sequences.Add(new Sequence(I));
            }
            sequences.Sort((x, r) => x.Id.CompareTo(r.Id));

            //hier vullen sequences
            foreach (Sequence S in sequences)
            {
                foreach (SubroutesInRoute sri in subrouteinRoute)
                {
                    if(sri.sri_SeqNr == S.Id)
                    {
                        S.SubrouteInRoute.Add(sri);
                    }
                }
            }

            return sequences;        
        }

        public Sequence GenerateNextSequence(ICollection<Sequence> sequences)
        {
            List<int> Ids = new List<int>();
            foreach (Sequence r in sequences)
            {
                Ids.Add(r.Id);
            }
            int firstAvailable = Enumerable.Range(1, int.MaxValue).Except(Ids).FirstOrDefault();

            Sequence sequence = new Sequence(firstAvailable);
            return sequence;
        }
    }
}
