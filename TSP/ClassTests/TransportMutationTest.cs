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
    public class TransportMutationTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        [TestMethod]
        public void TransportMutationTest1()
        {
            int populationSize = 2000;
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            PMXCrossover crossover = new PMXCrossover((float)(0.80));
            TournamentSelection selector = new TournamentSelection((int)populationSize/2);
            TranspositionMutation mutation = new TranspositionMutation((float)1);

            GeneticSolver solver = new GeneticSolver(testMatrix, mutation, crossover, selector, populationSize, 10);

            List<Candidate> listCand = solver.randomPopulation();

            Candidate parentX = listCand[0];
            Candidate parentY = listCand[1];

            parentX.chromoson = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parentY.chromoson = new List<int>() { 5, 3, 6, 7, 8, 1, 2, 9, 4, };

            
            mutation.Mutate(parentX);



        }
    }
}
