using GeneticTSP.CrossoverTypes;
using GeneticTSP.MutationTypes;
using GeneticTSP.SelectionTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeneticTSP
{
    public static class Facade
    {
        public static List<GeneticSolver> listTask;
        public static XDocument tspXmlFile;
       static Facade()
        {
            listTask = new List<GeneticSolver>();
        }
        public static void createNewSolver(int mutationIndex, int crossoverIndex, int selectorIndex, int populationSize, float mutationChance, int timeMS, int selectorSize)
        {
            MutationType mutation = null;
            CrossoverType crossover = null;
            SelectionType selection = null;
            AdjacencyMatrix matrix = new AdjacencyMatrix(tspXmlFile);
            switch (mutationIndex)
            {
                case 0:
                    {
                        
                       
                        mutation = new InversionMutation(mutationChance);
                        break;
                    }

            }

            switch (crossoverIndex)
            {
                case 0:
                    {
                        crossover = new PMXCrossover();
                        break;
                    }
            }

            switch (selectorIndex)
            {
                case 0:
                    {
                       
                        selection = new TournamentSelection(selectorSize);
                        break;
                    }
            }
            GeneticSolver solver = null;//add parameters TO DO
            if(mutation!=null && selection !=null && crossover != null)
            {
                 addNewSolver( new GeneticSolver(matrix, mutation, crossover, selection, populationSize, timeMS));
            }

           
        }
        public static void addNewSolver(GeneticSolver solver)
        {
            if (solver != null)
            {
                listTask.Add(solver);
            }
            else
                Console.WriteLine("Error. Wrong solver parameters");
        }

        public static void loadNewTspXmlFile(string path)
        {
            tspXmlFile = XDocument.Load(path);
            
        }

        public static void runSolution()
        {
            var tasks = new List<Task<Result>>();
            foreach(var solver in listTask)
                tasks.Add(Task.Factory.StartNew<Result>(() => solver.Solve()));
          
            Task.WaitAll(tasks.ToArray());
            foreach(var item in tasks)
            {
                item.Result.ToFile();
            }
            

            
        }

        internal static void removeTask(int selectedIndex)
        {
            listTask.RemoveAt(selectedIndex);
        }
    }

}
