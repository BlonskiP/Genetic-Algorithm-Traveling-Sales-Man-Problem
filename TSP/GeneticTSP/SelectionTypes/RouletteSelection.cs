using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.SelectionTypes
{
    public class RouletteSelection : SelectionType
    {
        List<Candidate> BreedingPool;
        Random rnd;
        public RouletteSelection(int size)
        {
            this.selectionSize = size;
            BreedingPool = new List<Candidate>();
            rnd = new Random();
            this.SelectionName = "RouletteSelection";


        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            double FittnesSum = countAllFittnes(candList);
            List<RouletteResult> results = CreateResultsList(candList, FittnesSum);
            double lastP = results[results.Count - 1].to;
            fillBreedingPool(results);
            return BreedingPool;
            
        }

        private void fillBreedingPool(List<RouletteResult> results)
        {
            double randomRouletteNumber;
            for(int i=0;i<selectionSize;i++)
            {
                randomRouletteNumber = rnd.NextDouble();
                Candidate temp = FindCandidate(results, randomRouletteNumber);
                if (temp != null)
                    BreedingPool.Add(temp);
                else
                    i--;
            }
        }
        private Candidate FindCandidate(List<RouletteResult> results, double randomNumber)
        {
            Candidate temp;
            foreach(var result in results)
            {
                if(randomNumber>result.from && randomNumber<=result.to)
                {
                    return result.cand;
                }
            }
        return null;
        }
        private List<RouletteResult> CreateResultsList(List<Candidate> candList, double fittnesSum)
        {
            List<RouletteResult> rouletteResults = new List<RouletteResult>();
            double probability = 0;
            double p2 = 0;
            foreach(var candidate in candList)
            {
                probability = (1/candidate.fitness) / fittnesSum;
                RouletteResult result = new RouletteResult(p2,probability,candidate);
                p2 += probability;
                rouletteResults.Add(result);


            }
            return rouletteResults;
        }

        private double countAllFittnes(List<Candidate> candList)
        {
            double FittnesSum = 0;
            foreach(var candidate in candList)
            {
                FittnesSum += 1/candidate.fitness;
            }
            return FittnesSum;
        }
        struct RouletteResult
        {
            public Candidate cand;
            public double from;
            public double to;
            

            public RouletteResult(double probability, double p2,Candidate cand) : this()
            {
                this.from = probability;
                this.to = probability + p2;
                this.cand = cand;
            }
        }
    
    }
}
