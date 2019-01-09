using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP.SelectionTypes
{
    public class TournamentSelection : SelectionType
    {
        public int TournamentSize;
        List<Candidate> BreedingPool;
        public TournamentSelection(int size)
        {
            TournamentSize = size;
            BreedingPool = new List<Candidate>();
        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            while(BreedingPool.Count() !=candList.Count())
            {
                List<Candidate> participants = getRandomCandidates(candList);
                Candidate winner = Tournament(participants);
                BreedingPool.Add(winner);
            }
            return BreedingPool;
        }
        private List<Candidate> getRandomCandidates(List<Candidate> candList)
        {
           
            List<Candidate> participants = new List<Candidate>();
            for(int i=0;i<TournamentSize;i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, candList.Count()-1);
                participants.Add(candList[index]);
            }
            return participants;
        }
        private Candidate Tournament(List<Candidate> participants)
        {
            Candidate winner = participants[0];
            float maxScore = float.MaxValue;
            for(int i=0;i<participants.Count();i++)
            {
                if(maxScore>participants[i].fitness)
                {
                    winner = participants[i];
                    maxScore = participants[i].fitness;
                }
            }
            return winner;
        }
    }
}
