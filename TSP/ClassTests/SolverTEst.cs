using System;
using GeneticTSP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassTests
{
    [TestClass]
    public class SolverTest
    {
        [TestMethod]
        public void StopTest()
        {
            GeneticSolver solver = new GeneticSolver();
            solver.Solve();
        }
    }
}
