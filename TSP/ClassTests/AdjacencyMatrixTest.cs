using System;
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
    }
}
