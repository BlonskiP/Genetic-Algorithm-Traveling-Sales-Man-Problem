using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP
{
    public abstract class SelectionType
    {
        public abstract List<Candidate> generateBreedingPool(List<Candidate> candList);
    }
}
