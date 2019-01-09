using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GeneticTSP;
using GeneticTSP.CrossoverTypes;
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
            GeneticSolver solver = new GeneticSolver(testMatrix, null, null, populationSize, 0);
            List<Candidate> listCand = solver.randomPopulation();

            Candidate parentX = listCand[0];
            Candidate parentY = listCand[1];

            parentX.chromoson = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parentY.chromoson = new List<int>() { 5 ,3 ,6 ,7 ,8, 1, 2, 9, 4,};

            PMXCrossover crossover = new PMXCrossover();

            crossover.Crossover(parentX, parentY);

            

        }
    }
}
