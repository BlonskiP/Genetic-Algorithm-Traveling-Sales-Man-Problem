using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.MutationTypes
{
    public class InversionMutation : MutationType
    {
       
        public InversionMutation(float mutationChance)
        {
            this.mutationChance = mutationChance;
            this.MutationName = "InversionMutation";
            rnd = new Random();
        }
        public override Candidate Mutate(Candidate candidate)
        {
            double chance = rnd.NextDouble();
            //if(chance<mutationChance)
            {
                int endIndex;
                int startIndex = rnd.Next(0, candidate.chromoson.Count());
                do
                {
                    endIndex = rnd.Next(0, candidate.chromoson.Count());
                } while (startIndex == endIndex);
                if(startIndex>endIndex)
                {
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }


                candidate.chromoson.Reverse(startIndex, endIndex - startIndex);
            }
            candidate.CountFitness();
            return candidate;
        }

        public override List<Candidate> MutateList(List<Candidate> population)
        {
            foreach(var candidate in population)
            {
                Mutate(candidate);
            }
            return population;
        }
    }
}
