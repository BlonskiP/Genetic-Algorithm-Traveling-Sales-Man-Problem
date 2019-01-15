﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GeneticTSP
{
    public class Result
    {
        public Candidate bestResult;
        public List<Candidate> results;
        public List<Candidate> TimeResults;
       
        public string measureName;
        public string selectionName;
        public string mutationName;
        public string crossoverName;
        public float mutationChance;
        public string tspFileName;
        public string time;
        public Result() { }
        public Result(GeneticSolver solver) {
            mutationName = solver.mutation.MutationName;
            selectionName = solver.selector.SelectionName;
            crossoverName = solver.crossover.CrossoverName;
            mutationChance = solver.mutation.mutationChance;
            tspFileName = solver.matrix.tspFileName;
            measureName = tspFileName + mutationName + mutationChance + selectionName + crossoverName;
            time = solver.time.ElapsedMilliseconds.ToString();
            bestResult = solver.bestCandidate;
            results = solver.results;
            TimeResults = solver.bestPerTwoMinutes;
        }
        public XDocument resultToXML()
        {
            results.Reverse();
            var mutation = new XElement("MutationName", mutationName);
            var selector = new XElement("SelectorName", selectionName);
            var crossover = new XElement("CrossOverName", crossoverName);
            var mutationChance = new XElement("MutationChance", this.mutationChance.ToString());
            var tsp = new XElement("TspFile", tspFileName);
            var best = new XElement("BestSolution");
            var timeElement = new XElement("Time", time);

            XDocument fileTree = new XDocument();
            fileTree.Add(new XElement("TspResultInstance"));
            fileTree.Root.Add(timeElement);
            fileTree.Root.Add(mutation);
            fileTree.Root.Add(selector);
            fileTree.Root.Add(crossover);
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
            var timedSolutions = new XElement("TimedSolutioinsPer2minutes");

            foreach(var candidate in TimeResults )
            {
                timedSolutions.Add(resultToXElement(candidate));
            };
            

            return fileTree;
        }
        XElement resultToXElement(Candidate candidate)
        {
            XElement resultElement = new XElement("Result");
            var Generation = new XElement("Generation", candidate.generation);
            var Fittnes = new XElement("Fittnes", candidate.fitness);
            var Path = new XElement("Path", Convert(candidate.chromoson));
            var Time = new XElement("Time", candidate.time);

            resultElement.Add(Fittnes);
            resultElement.Add(Generation);
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

        public void ToFile()
        {
            string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string path = root + "\\results";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
               
            }
            var doc = resultToXML();
            path = path + "\\" +this.measureName+".xml";
            using (FileStream fs = File.Create(path))
            {
                doc.Save(fs);
            }

        }
    }
}
