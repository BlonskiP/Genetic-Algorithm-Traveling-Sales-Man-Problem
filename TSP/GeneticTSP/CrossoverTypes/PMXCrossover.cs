using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.CrossoverTypes
{
    public class PMXCrossover : CrossoverType
    {
        public PMXCrossover(float crossoverChance)
        {
            rnd = new Random();
            this.CrossoverName = "PMXCrossover";
            this.CrossoverChance = crossoverChance;
        }
        public override List<Candidate> Crossover(Candidate parentX, Candidate parentY)
        {
            List<Candidate> childrenList = new List<Candidate>();
            float chance = (float)rnd.NextDouble();
            if (chance < CrossoverChance)
            {
               
                int startIndex = rnd.Next(0, parentX.chromoson.Count() - 1);
                int endIndex = rnd.Next(0, parentX.chromoson.Count() - 1); //random indexes
                                                                           // int startIndex = 3;
                                                                           //int endIndex = 7; //only for testing
                if (startIndex > endIndex)
                {
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }
                int[,] mappingArray = createMappingArray(parentX, parentY, startIndex, endIndex);
                int[] childXChromosome = new int[parentX.chromoson.Count()];
                int[] childYChromosome = new int[parentX.chromoson.Count()];

                FillChromosone(ref childXChromosome, startIndex, mappingArray, 1);
                FillChromosone(ref childYChromosome, startIndex, mappingArray, 0);

                fillMissingGens(ref childXChromosome, parentX, startIndex, endIndex);
                fillMissingGens(ref childYChromosome, parentY, startIndex, endIndex);

                fillMappedGens(ref childXChromosome, mappingArray, parentX);
                fillDoubleMapp(ref childXChromosome, mappingArray, parentX);

                fillMappedGens(ref childYChromosome, mappingArray, parentY);
                fillDoubleMapp(ref childYChromosome, mappingArray, parentY);

                Candidate childX = new Candidate(parentX.generation, childXChromosome.ToList(), parentX.solver, parentX.solver.time.ElapsedMilliseconds.ToString());
                Candidate childY = new Candidate(parentY.generation, childYChromosome.ToList(), parentY.solver, parentY.solver.time.ElapsedMilliseconds.ToString());

                childX.generation = (parentX.generation + 1);
                childY.generation = (parentY.generation + 1);
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
        public int[,] createMappingArray(Candidate parentX, Candidate parentY, int startIndex, int endIndex)
        {




            int dif = endIndex - startIndex;
            int[,] mappingArray = new int[dif, 2];
            for (int i = startIndex; i < endIndex; i++)
            {
                mappingArray[i - startIndex, 0] = parentX.chromoson[i];
                mappingArray[i - startIndex, 1] = parentY.chromoson[i];
            }



            return mappingArray;
        }
        public void FillChromosone(ref int[] chromosone, int startIndex, int[,] mappingArray, int side)
        {
            int size = mappingArray.GetLength(0);
            for (int i = startIndex; i < size + startIndex; i++)
            {
                chromosone[i] = mappingArray[i - startIndex, side];
            }
        }
        public void fillMissingGens(ref int[] chromosone, Candidate parent, int start, int end)
        {
            for (int i = 0; i < start; i++)
            {
                if (!chromosone.Contains(parent.chromoson[i]))
                {
                    chromosone[i] = parent.chromoson[i];
                }
            }

            for (int i = end; i < parent.chromoson.Count(); i++)
            {
                if (!chromosone.Contains(parent.chromoson[i]))
                {
                    chromosone[i] = parent.chromoson[i];
                }
            }

        }

        public void fillMappedGens(ref int[] chromosone, int[,] mappingArray, Candidate parent)
        {
            int genToMap;
            int tempGen;

            for (int i = 0; i < chromosone.Length; i++)
            {
                if (chromosone[i] == 0)
                {
                    genToMap = parent.chromoson[i];
                    tempGen = mapInt(mappingArray, genToMap);
                    if (!chromosone.Contains(tempGen))
                    {
                        chromosone[i] = tempGen;
                    }
                  
                }
            }


        }

        public void fillDoubleMapp(ref int[] chromosone, int[,] mappingArray, Candidate parent)
        {
            int genToMap;
            int tempGen;
            
            bool mappingDirection = false; //false X True Y
            for (int i = 0; i < chromosone.Length; i++)
            {
                if (chromosone[i] == 0)
                {
                    genToMap = parent.chromoson[i];
                    tempGen = genToMap;
                    while (chromosone.Contains(tempGen)){
                        int mapped = directedMap(mappingArray, tempGen, mappingDirection);
                        if (tempGen==mapped)
                        {
                            mappingDirection = !mappingDirection;
                            
                        }
                        tempGen = mapped;
                            

                    }
                    if(!chromosone.Contains(tempGen))
                    {
                        chromosone[i] = tempGen;
                    }

                }
            }
        }
        private int mapInt (int[,] mappingArray, int x)
        {
            for (int i = 0; i < mappingArray.GetLength(0); i++)
            {
                if (x == mappingArray[i, 0])
                {
                    return mappingArray[i, 1];
                }
                if (x == mappingArray[i, 1])
                {
                    return mappingArray[i, 0];
                }
            }
            
                return x;
        }
        private int directedMap(int[,] mappingArray, int x, bool direction)
        {
            int mapped = x;
            if (direction)//Y to X
                mapped = mapYtoX(mappingArray, x);
            else mapped = mapXtoY(mappingArray, x);

            return mapped;
        }
        private int mapXtoY(int[,] mappingArray, int x)
        {
            int temp;
            for (int i = 0; i < mappingArray.GetLength(0); i++)
            {
                if (x == mappingArray[i, 0])
                {
                    temp = mappingArray[i, 1];
                    return temp;
                }
            }
                return x;
        }
        private int mapYtoX(int[,] mappingArray, int x)
        {
            int temp;
            for (int i = 0; i < mappingArray.GetLength(0); i++)
            {
                if (x == mappingArray[i, 1])
                {
                    temp = mappingArray[i, 0];
                    return temp;
                }
            }
                return x;
        }
        public override List<Candidate> CrossoverPopulation(List<Candidate> population, int populationSize)
        {
            int parentX;
            int parentY;
            List<Candidate> newPopulation = new List<Candidate>();
            int size = populationSize / 2;
            for(int i=0; i<size;i++)
            {
                 parentX =rnd.Next(0, population.Count());
                 parentY =rnd.Next(0, population.Count());
                //parentX = 0;
                //parentY = 1;
                newPopulation.AddRange(Crossover(population[parentX], population[parentY]));
            }
            return newPopulation;
        }
        private bool checkGens(List<Candidate> candidates) //test only
        {
            foreach (var candidate in candidates)
            {
                if (candidate.chromoson.Contains(0))
                {
                    return false;
                }
            }
            return true;
        }
    }
}