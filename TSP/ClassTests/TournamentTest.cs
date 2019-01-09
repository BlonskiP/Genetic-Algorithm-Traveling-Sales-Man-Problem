using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GeneticTSP;
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
            GeneticSolver solver = new GeneticSolver(testMatrix, null, null, populationSize, 0);
            List<Candidate> listCand = solver.randomPopulation();


            TournamentSelection selector = new TournamentSelection(2);
            listCand = selector.generateBreedingPool(listCand);

        }
    }
}
