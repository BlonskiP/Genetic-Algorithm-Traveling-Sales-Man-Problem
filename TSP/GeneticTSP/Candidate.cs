using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP
{
    public class Candidate
    {
        public List<int> chromoson;
        public int generation = 0;
        public float fitness;
        GeneticSolver solver;

        Candidate(int generation, List<int> genotype)
        {
            this.generation = generation;
            chromoson = genotype;
        }
        public void CountFitness() {
            fitness = solver.matrix.countCost(chromoson);
        }

    }
}
