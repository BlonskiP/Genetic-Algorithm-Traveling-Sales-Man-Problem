//https://www.iwr.uni-heidelberg.de/groups/comopt/software/TSPLIB95/STSP.html
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
        Random rnd;
        public AdjacencyMatrix matrix;
        MutationType mutation;
        SelectionType selector;
        CrossoverType crossover;
        List<Candidate> population;
        

        int maxPopulationSize;
        int MaxTime;
        Stopwatch time;
        Candidate bestCandidate;
        List<float> results;
        public GeneticSolver(AdjacencyMatrix matrix, MutationType mutation, CrossoverType crossover, SelectionType selectionType, int populationSize, int MaxTime)
        {
            this.crossover = crossover;
            this.matrix = matrix;
            this.mutation = mutation;
            maxPopulationSize = populationSize;
            selector = selectionType;
            rnd = new Random();
            this.MaxTime = MaxTime;
            results = new List<float>();

        }
        public GeneticSolver() {
            MaxTime = 10;
        }//for tests only
        public Candidate Solve()
        {
            List<Candidate> breedingPool;
            List<Candidate> newPopulation;
            List<Candidate> mutants = new List<Candidate>();
            population = randomPopulation(); //create random population
            //checkGens(population);  //DEBUG ONLY
            bestCandidate = population[0];
            time = Stopwatch.StartNew();
            while (time.ElapsedMilliseconds < MaxTime * 1000)
            {
                
                breedingPool = selector.generateBreedingPool(population);
               // checkGens(breedingPool); //DEBUG ONLY
                newPopulation = crossover.CrossoverPopulation(breedingPool,maxPopulationSize);
                // checkGens(newPopulation);  //DEBUG ONLY
                mutants = mutation.MutateList(newPopulation);
              //  checkGens(mutants); //DEBUG ONLY
                findBest(population);
                population = mutants;
                findBest(population);
            }
            
            time.Stop();

            return bestCandidate;
        }

        public Candidate randomCandidate() //only 1st generation
        {
            
            List<int> chromosone = new List<int>();
            List<int> verticles = new List<int>();
            for(int i=1;i<matrix.CostMatrix.GetLength(0);i++)
            {
                verticles.Add(i);
            }
            while(verticles.Count!=0)
            {
               
                int verticle = rnd.Next()%verticles.Count();//random verticle
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

        public Candidate findBest(List<Candidate> population)
        {
            Candidate best = population[0];
            float bestScore = float.MaxValue;
            foreach(var candidate in population)
            {
                if(bestScore>candidate.fitness)
                {
                    bestScore = candidate.fitness;
                    best = candidate;
                }
            }
            if(best.fitness<bestCandidate.fitness)
            {
                bestCandidate = best;
                time.Stop();
                results.Add(findBest(population).fitness);
                time.Start();
            }
            return best;
        }
        private bool checkGens(List<Candidate> candidates)
        {
            foreach(var candidate in candidates)
            {
                if(candidate.chromoson.Contains(0))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
