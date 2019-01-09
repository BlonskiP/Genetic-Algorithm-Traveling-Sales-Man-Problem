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
    public class MutationTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        [TestMethod]
        public void MutationTest1()
        {
            int populationSize = 120;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover();
            TournamentSelection selector = new TournamentSelection(5);
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(testMatrix, inv, crossover, selector, populationSize, 10);

            List<Candidate> listCand = solver.randomPopulation();

            Candidate parentX = listCand[0];
            Candidate parentY = listCand[1];

            parentX.chromoson = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parentY.chromoson = new List<int>() { 5, 3, 6, 7, 8, 1, 2, 9, 4, };

            
            inv.Mutate(parentX);



        }
    }
}
