using GeneticTSP.CrossoverTypes;
using GeneticTSP.MutationTypes;
using GeneticTSP.SelectionTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static void createNewSolver(int mutationIndex, int crossoverIndex, int selectorIndex, int populationSize, float mutationChance, int timeMS, int selectorSize, float crossoverChance)
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
                case 1:
                    {
                        mutation = new TranspositionMutation(mutationChance);
                        break;
                    }

            }

            switch (crossoverIndex)
            {
                case 0:
                    {
                        crossover = new PMXCrossover(crossoverChance);
                        break;
                    }
                case 1:
                    {
                        crossover = new OXCrossover(crossoverChance);
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
                    case 1:
                    {
                        selection = new RouletteSelection(selectorSize);
                        break;
                    }
            }
            GeneticSolver solver = null;//add parameters TO DO
            if (mutation != null && selection != null && crossover != null)
            {
                addNewSolver(new GeneticSolver(matrix, mutation, crossover, selection, populationSize, timeMS));
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

            foreach (var solver in listTask)
                tasks.Add(Task.Factory.StartNew<Result>(() => solver.Solve()));

            ClockDefender(tasks);
          
            
          
            foreach (var item in tasks)
            {
                item.Result.ToFile();
            }
            listTask.Clear();
            



        }

        static private void ClockDefender(Object data)
        {
            List<Task<Result>> taskList = (List<Task<Result>>)data;
            while (CheckTasks(taskList)) { 

              
               for(int i=0;i<taskList.Count;i++)
               {
                    if(listTask[i].time.IsRunning && (taskList[i].Status== TaskStatus.WaitingForActivation || taskList[i].Status== TaskStatus.WaitingToRun))
                    {
                        listTask[i].time.Stop();
                    }
               }
                
            }

        }

        private static bool CheckTasks(List<Task<Result>> taskList)
        {
           foreach(var task in taskList)
            {
                if (task.Status == TaskStatus.WaitingForActivation || task.Status==TaskStatus.WaitingToRun)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void removeTask(int selectedIndex)
        {
            listTask.RemoveAt(selectedIndex);
        }
    }

}
