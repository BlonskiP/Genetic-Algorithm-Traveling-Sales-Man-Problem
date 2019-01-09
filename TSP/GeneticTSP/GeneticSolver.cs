
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
        CrossoverType cosseover;
        List<Candidate> population;
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
            population = randomPopulation(); //create random population
            time = Stopwatch.StartNew();
            while (time.ElapsedMilliseconds < MaxTime * 1000)
            {
                // Select Breeding pool

                //Crossover

                //Mutation
                
            }
            time.Stop();
            
            return bestCandidate;
        }

        public Candidate randomCandidate() //only 1st generation
        {
            Random rnd = new Random();
            List<int> chromosone = new List<int>();
            List<int> verticles = new List<int>();
            for(int i=1;i<matrix.CostMatrix.GetLength(0);i++)
            {
                verticles.Add(i);
            }
            while(verticles.Count!=0)
            {
               int verticle = rnd.Next(0, verticles.Count());//random verticle
                chromosone.Add(verticles[verticle]);
                verticles.RemoveAt(verticle);
            }
            Candidate newCandidate = new Candidate(1,chromosone, this);
            return newCandidate;
        }
        public List<Candidate> randomPopulation()
        {
            List<Candidate> population = new List<Candidate>();
            for(int i=0;i<maxPopulationSize;i++)
            {
                population.Add(randomCandidate());
            }
            return population;
        }

    }
}
