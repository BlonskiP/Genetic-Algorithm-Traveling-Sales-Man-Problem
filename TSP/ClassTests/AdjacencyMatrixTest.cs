using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GeneticTSP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassTests
{
    [TestClass]
    public class AdjacencyMatrixTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        [TestMethod]
        public void LoadFromFileTest()
        {
            file = root + "\\bays29.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
        }
        [TestMethod]
        public void countTest()
        {
            List<int> examplePath = new List<int>(new int[]{ 1, 2 }); 
            AdjacencyMatrix testMatrix = new AdjacencyMatrix();
            testMatrix.CostMatrix = new float[,]
                {
                { 0,3,2},
                { 7,0,4},
                { 6,5,0}
            };
            var cost = testMatrix.countCost(examplePath);
            // 0 to 1 = 3
            // 1 to 2 = 4
            // 2 to 0 = 6
            //path cost=13
            Assert.AreEqual(13, cost);
        }
    }
}
