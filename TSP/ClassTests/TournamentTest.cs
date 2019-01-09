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
    public class TournamentTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        [TestMethod]
        public void TournamentTest1()
        {
            int populationSize = 120;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover();
            TournamentSelection selector = new TournamentSelection(10);
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(testMatrix, inv, crossover, selector, populationSize, 10);
          //  listCand = selector.generateBreedingPool(listCand);

        }
    }
}
