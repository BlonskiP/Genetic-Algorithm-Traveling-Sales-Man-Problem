﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.CrossoverTypes
{
    public class PMXCrossover : CrossoverType
    {
        public PMXCrossover()
        {
            rnd = new Random();
        }
        public override List<Candidate> Crossover(Candidate parentX, Candidate parentY)
        {
            List<Candidate> childernList = new List<Candidate>();
            // int startIndex = rnd.Next(0, parentX.chromoson.Count() - 1);
            // int endIndex = rnd.Next(0, parentX.chromoson.Count() - 1); //random indexes
            int startIndex = 3;
            int endIndex = 7; //only for testing
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
            Candidate childX = new Candidate(parentX.generation, childXChromosome.ToList(), parentX.solver);
            Candidate childY = new Candidate(parentY.generation, childYChromosome.ToList(), parentY.solver);
            childernList.Add(childX);
            childernList.Add(childY);
            return childernList;
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
            int tempGen2;
            for (int i = 0; i < chromosone.Length; i++)
            {
                if (chromosone[i] == 0)
                {
                    genToMap = parent.chromoson[i];
                    tempGen = doubleMapInt(mappingArray, genToMap);
                    
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
        private int doubleMapInt(int[,] mappingArray, int x)
        {

            int temp;
            for (int i = 0; i < mappingArray.GetLength(0); i++)
            {
                if (x == mappingArray[i, 0])
                {
                    temp = mappingArray[i, 1];
                    for (int k = 0; k < mappingArray.GetLength(0); k++)
                    {
                        if(temp==mappingArray[k,0])
                        {
                            return mappingArray[k, 1];
                        }
                    }
                }
                if (x == mappingArray[i, 1])
                {
                    temp = mappingArray[i, 0];
                    for (int k = 0; k < mappingArray.GetLength(0); k++)
                    {
                        if (temp == mappingArray[k, 1])
                        {
                            return mappingArray[k, 0];
                        }
                    }
                }

            }
           
            return x;
        }

        public override List<Candidate> CrossoverPopulation(List<Candidate> population)
        {
            int parentX;
            int parentY;
            List<Candidate> newPopulation = new List<Candidate>();
            int size = population.Count / 2;
            for(int i=0; i<size;i++)
            {
                parentX =rnd.Next(0, population.Count());
                parentY =rnd.Next(0, population.Count());
                newPopulation.AddRange(Crossover(population[parentX], population[parentY]));
            }
            return newPopulation;
        }
    }
}