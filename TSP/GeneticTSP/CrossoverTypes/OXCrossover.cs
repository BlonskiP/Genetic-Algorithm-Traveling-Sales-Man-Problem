using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.CrossoverTypes
{
    public class OXCrossover : CrossoverType
    {
        public OXCrossover(float crossoverChance)
        {
            rnd = new Random();
            this.CrossoverName = "OXCrossover";
            this.CrossoverChance = crossoverChance;
        }
        public override List<Candidate> Crossover(Candidate parentX, Candidate parentY)
        {
            List<Candidate> childrenList = new List<Candidate>();
            float chance = (float)rnd.NextDouble();
            if(chance<CrossoverChance)
            {

                int startIndex = rnd.Next(0, parentX.chromoson.Count() - 1);
                int endIndex = rnd.Next(0, parentX.chromoson.Count() - 1);
               // int startIndex = 2; //debug only
               // int endIndex = 6;
                if (startIndex > endIndex)
                {
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }
                int[] childXChromosome = new int[parentX.chromoson.Count()];
                int[] childYChromosome = new int[parentX.chromoson.Count()];
                int[] parentYSection = new int[endIndex - startIndex];
                int[] parentXSection = new int[endIndex - startIndex];

                fillParentSection(ref parentXSection, parentX.chromoson, startIndex, endIndex);
                fillParentSection(ref parentYSection, parentY.chromoson, startIndex, endIndex);
                FillChromosoneWithParenScetion(ref childXChromosome, parentYSection, startIndex);
                FillChromosoneWithParenScetion(ref childYChromosome, parentXSection, startIndex);

                FillChromosoneWithMissingGens(ref childXChromosome, parentX.chromoson, endIndex);
                FillChromosoneWithMissingGens(ref childYChromosome, parentY.chromoson, endIndex);

                Candidate childX = new Candidate(parentX.generation+1, childXChromosome.ToList(), parentX.solver, parentX.solver.time.ElapsedMilliseconds.ToString());
                Candidate childY = new Candidate(parentY.generation+1, childYChromosome.ToList(), parentY.solver, parentY.solver.time.ElapsedMilliseconds.ToString());


                childrenList.Add(childX);
                childrenList.Add(childY);
                checkGens(childrenList);

            }
            else
            {
                Candidate childX = new Candidate(parentX.generation, parentX.chromoson, parentX.solver, parentX.solver.time.ElapsedMilliseconds.ToString());
                Candidate childY = new Candidate(parentY.generation, parentY.chromoson, parentY.solver, parentY.solver.time.ElapsedMilliseconds.ToString());
                childX.generation = (parentX.generation + 1);
                childY.generation = (parentY.generation + 1);
                childrenList.Add(childX);
                childrenList.Add(childY);
                checkGens(childrenList);
            }
            return childrenList;
        }

        private bool checkGens(List<Candidate> childrenList)
        {
            foreach (var candidate in childrenList)
            {
                if (candidate.chromoson.Contains(0))
                {
                    return false;
                }
            }
            return true;
        }

        private void FillChromosoneWithMissingGens(ref int[] childChromosome, List<int> chromoson, int endIndex)
        {
            int index = endIndex;
           for(int i=index; ;i++)
           {
                if (!childChromosome.Contains(0)) break;
                if (i >= chromoson.Count()) i = 0;
                if(!childChromosome.Contains(chromoson[i]) && childChromosome[index]==0)
                {
                    childChromosome[index] = chromoson[i];
                    index++;
                    if (index >= childChromosome.Length) index = 0;
                }
                
           }

        }

        private void FillChromosoneWithParenScetion(ref int[] childChromosome, int[] parentSection, int startIndex)
        {
           for(int i=startIndex;i<startIndex+parentSection.Length;i++)
            {
                childChromosome[i] = parentSection[i-startIndex];
            }
        }

        private void fillParentSection(ref int[] parentSection, List<int> chromoson, int startIndex, int endIndex)
        {
            for(int i=0;i<endIndex-startIndex;i++)
            {
                parentSection[i] = chromoson[startIndex + i];
            }
            
        }

        private void FillChromosone(ref int[] childYChromosome, int startIndex, int v)
        {
           
        }

        public override List<Candidate> CrossoverPopulation(List<Candidate> population, int populationSize)
        {
            int parentX;
            int parentY;
            List<Candidate> newPopulation = new List<Candidate>();
            int size = populationSize / 2;
            for (int i = 0; i < size; i++)
            {
                parentX = rnd.Next(0, population.Count());
                parentY = rnd.Next(0, population.Count());
                //parentX = 0;
                //parentY = 1;
                newPopulation.AddRange(Crossover(population[parentX], population[parentY]));
            }
            return newPopulation;
        }
    }
}
