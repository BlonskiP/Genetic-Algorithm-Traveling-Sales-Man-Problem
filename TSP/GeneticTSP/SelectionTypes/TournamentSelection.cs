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
        Random rnd;
        List<Candidate> BreedingPool;

        public TournamentSelection(int size)
        {
            TournamentSize = size;
            BreedingPool = new List<Candidate>();
            rnd = new Random();
            this.SelectionName = "TournamentSelection";
        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            BreedingPool = new List<Candidate>();
            Candidate winner;
            List<Candidate> winnerList = new List<Candidate>();
            int size = (int)(candList.Count() * 0.3);
            while (BreedingPool.Count() <size)
            {
                
                while (winnerList.Count() <= TournamentSize)
                {
                    List<Candidate> participants = getRandomCandidates(candList);
                    winner = Tournament(participants);
                    winnerList.Add(winner);
                }
                winner = Tournament(winnerList);
                winnerList = new List<Candidate>();
                BreedingPool.Add(winner);
            }
            BreedingPool.OrderBy(o => o.fitness);
            return BreedingPool;
        }
        private List<Candidate> getRandomCandidates(List<Candidate> candList)
        {
            
            List<Candidate> participants = new List<Candidate>();
            for(int i=0;i<TournamentSize;i++)
            {
               
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
                if(participants[i].fitness<maxScore)
                {
                    winner = participants[i];
                    maxScore = participants[i].fitness;
                }
            }
            return winner;
        }
    }
}
