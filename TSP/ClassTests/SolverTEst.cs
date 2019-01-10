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
        public void solverTest()
        {
            int populationSize = 3000;
            file = root + "\\rbg403.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover();
            TournamentSelection selector = new TournamentSelection((int)(5));
            InversionMutation inv = new InversionMutation((float)0.05);

            GeneticSolver solver = new GeneticSolver(
                testMatrix, inv, crossover,selector, populationSize, 600);
            var result = solver.Solve();
        }

        
        


    }
}
