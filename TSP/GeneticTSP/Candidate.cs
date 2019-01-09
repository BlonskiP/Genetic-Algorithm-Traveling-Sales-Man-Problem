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
        public GeneticSolver solver;

        public Candidate(int generation, List<int> genotype, GeneticSolver solver)
        {
            this.generation = generation;
            this.solver = solver;
            chromoson = genotype;
            CountFitness();
        }
        public void CountFitness() {
            fitness = solver.matrix.countCost(chromoson);
        }

    }
}
