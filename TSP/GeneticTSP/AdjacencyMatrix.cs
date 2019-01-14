using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeneticTSP
{
   public class AdjacencyMatrix
    {
        public float[,] CostMatrix;
        public string tspFileName;
        public AdjacencyMatrix(XDocument tspFile) {
            
            tspFileName = tspFile.Descendants("name").First().Value.ToString();
            var vertexList = tspFile.Descendants("graph").Elements("vertex").ToList();
            int size = vertexList.Count();
            CostMatrix = new float[(int)size, (int)size];
            int roundNumber = Int32.Parse(tspFile.Root.Element("ignoredDigits").Value);
            int i = 0; //inumerator would be better :(
            foreach (var vertex in vertexList)
            {
                var edgeList = vertex.Elements("edge").ToList();
                foreach (var edge in edgeList)
                {
                    //Console.WriteLine((edge.Attribute("cost").Value));
                    //Console.WriteLine((edge.Value));
                    int vertexNumber = Int32.Parse(edge.Value);
                    float cost = float.Parse(edge.Attribute("cost").Value, CultureInfo.InvariantCulture);
                    System.Math.Round(cost, roundNumber);
                    CostMatrix[i, vertexNumber] = cost;


                }
                i++;
            }
        }
        public AdjacencyMatrix() { }//for test only

        public float countCost(List<int> path)
        {
            float tourCost = 0;
            tourCost += CostMatrix[0, path[0]]; //0 to first index
            for (int i = 0; i < path.Count() - 1; i++)
            {
                tourCost += CostMatrix[path[i], path[i + 1]];
            }
            tourCost += CostMatrix[path.Count, 0];//last index to 0
            return tourCost;
        }
    }
    
}
