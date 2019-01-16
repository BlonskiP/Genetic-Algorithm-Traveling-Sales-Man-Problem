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
    public class RouletteTests
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        [TestMethod]
        public void RouletteTests1()
        {
            int populationSize = 1000;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover((float)(0.80));
            RouletteSelection selector = new RouletteSelection(100);
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(testMatrix, inv, crossover, selector, populationSize, 10);
            List<Candidate> listCand = solver.randomPopulation();
         
            listCand = selector.generateBreedingPool(listCand);

        }
    }
}
