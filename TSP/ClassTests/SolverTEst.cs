﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GeneticTSP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassTests
{
    [TestClass]
    public class SolverTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        [TestMethod]
        public void StopTest()
        {
            GeneticSolver solver = new GeneticSolver();
            solver.Solve();
        }

        [TestMethod]
        public void RandomCandidateTest()
        {
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            GeneticSolver solver = new GeneticSolver(testMatrix, null, null, 0, 0);
            Candidate cand = solver.randomCandidate();
            if (cand.chromoson.Contains(0))
                Assert.Fail();
        }
        [TestMethod]
        public void RandomPopulationTest()
        {
            int populationSize = 10000;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            GeneticSolver solver = new GeneticSolver(testMatrix, null, null, populationSize, 0);
            List<Candidate> listCand = solver.randomPopulation();
            Assert.IsTrue(listCand.Count == populationSize);
        }


    }
}
