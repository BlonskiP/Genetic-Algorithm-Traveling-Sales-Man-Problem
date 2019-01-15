using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GeneticTSP;
using GeneticTSP.CrossoverTypes;
using GeneticTSP.MutationTypes;
using GeneticTSP.SelectionTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassTests
{
    [TestClass]
    public class PMXTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        [TestMethod]
        public void PMXTest1()
        {
            int populationSize = 120;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover();
            TournamentSelection selector = new TournamentSelection(5);
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(testMatrix, inv, crossover, selector, populationSize, 10);

            //Candidate parentX = listCand[0];
            //Candidate parentY = listCand[1];

            //parentX.chromoson = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //parentY.chromoson = new List<int>() { 5 ,3 ,6 ,7 ,8, 1, 2, 9, 4,};

            //PMXCrossover crossover = new PMXCrossover();

           // crossover.Crossover(parentX, parentY);

            

        }


        [TestMethod]
        public void PMXTest2()
        {
            int populationSize = 120;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover();
            TournamentSelection selector = new TournamentSelection(5);
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(testMatrix, inv, crossover, selector, populationSize, 10);
            List<Candidate> listCand = new List<Candidate>();
            List<int> GenX = new List<int>() { 5, 20, 28, 18, 14, 2, 27, 25, 8, 4, 19, 13, 12, 17, 11, 15, 16, 9, 3, 10, 22, 21, 1, 7, 24, 6, 23, 26 };
            List<int> GenY = new List<int>() { 28, 19, 11, 27, 3, 18, 17, 14, 10, 23, 8, 12, 6, 2, 22, 7, 25, 20, 4, 1, 26, 9, 5, 15, 24, 21, 16, 13 };
            Candidate parentX = new Candidate(1, GenX, solver, solver.time.ElapsedMilliseconds.ToString());
            Candidate parentY = new Candidate(1, GenY, solver, solver.time.ElapsedMilliseconds.ToString());
            listCand.Add(parentX);
            listCand.Add(parentY);
            crossover.CrossoverPopulation(listCand,10);



        }

    }
}
