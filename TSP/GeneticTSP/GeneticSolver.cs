using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP
{
    public class GeneticSolver
    {
        public AdjacencyMatrix matrix;
        MutationType mutation;
        SelectionType selector;
        List<Candidate> Population;
        List<Candidate> Parents;
        int maxPopulationSize;
        int MaxTime;
        Stopwatch time;
        Candidate bestCandidate;
        public GeneticSolver(AdjacencyMatrix matrix, MutationType mutation, SelectionType selectionType, int populationSize, int MaxTime)
        {
            this.matrix = matrix;
            this.mutation = mutation;
            maxPopulationSize = populationSize;
            selector = selectionType;
            
        }
        public GeneticSolver() {
            MaxTime = 10;
        }//for tests only
        public Candidate Solve()
        {
            time = Stopwatch.StartNew();
            while (time.ElapsedMilliseconds < MaxTime * 1000)
            {
                Console.Write("test");
                
            }
            time.Stop();
            return bestCandidate;
        }

    }
}
