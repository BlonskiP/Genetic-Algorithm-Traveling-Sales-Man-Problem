using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP
{
    abstract public class MutationType
    {
        public float mutationChance;
        public abstract Candidate Mutate(Candidate candidate);
        public abstract List<Candidate> MutateList(List<Candidate> population);
    }
}
