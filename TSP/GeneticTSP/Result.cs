using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GeneticTSP
{
    public class Result
    {
        public Candidate bestResult;
        public List<Candidate> results;

        public string measureName;
        public string selectionName;
        public string mutationName;
        public string crossoverName;
        public float mutationChance;
        public string tspFileName;
        public string time;
        public Result() { }
        public Result(string mutationName, string selectionName, string crossoverName, float mutationChance,string tspFileName) {
            this.mutationName = mutationName;
            this.selectionName = selectionName;
            this.crossoverName = crossoverName;
            this.mutationChance = mutationChance;
            this.tspFileName = tspFileName;
            this.measureName = tspFileName + mutationName + mutationChance + selectionName + crossoverName;
        }
        public void ToFile()
        {
            var mutation = new XElement("MutationName", mutationName);
            var selector = new XElement("SelectorName", selectionName);
            var crossover = new XElement("CrossOverName", crossoverName);
            var mutationChance = new XElement("MutationChance", this.mutationChance.ToString());
            var tsp = new XElement("TspFile", tspFileName);
            var best = new XElement("BestSolution");
            

            XDocument fileTree = new XDocument();
            fileTree.Add(new XElement("TspResultInstance"));
            fileTree.Root.Add(mutation);
            fileTree.Root.Add(selector);
            fileTree.Root.Add(mutation);
            fileTree.Root.Add(best);

            fileTree.Elements().Elements("MutationName").First().Add(mutationChance);
            best = fileTree.Elements().Elements("BestSolution").First();
            best.Add(resultToXElement(bestResult));

            var otherSolutions = new XElement("OtherSolutionsWhereBestAtTime");
            foreach(var candidate in results)
            {
                otherSolutions.Add(resultToXElement(candidate));
            }
            fileTree.Root.Add(otherSolutions);

        }
        XElement resultToXElement(Candidate candidate)
        {
            XElement resultElement = new XElement("Result");
            var Fittnes = new XElement("Fittnes", candidate.fitness);
            var Path = new XElement("Path", Convert(candidate.chromoson));
            var Time = new XElement("Time", candidate.time);
            resultElement.Add(Fittnes);
            resultElement.Add(Path);
            resultElement.Add(Time);
            return resultElement;
        }
        public string Convert(List<int> list)
        {
            var s = new StringBuilder();
            foreach (int i in list)
                s.AppendFormat("{0} ", i);

            return s.ToString();
        }
    }
}
