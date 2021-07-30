using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.DataStructureImplementations
{
    class MyGraph
    {
        private Dictionary<int, List<int>> adjacentList;
        private int numberOfNodes;

        public MyGraph()
        {
            adjacentList = new Dictionary<int, List<int>>();
            numberOfNodes = 0;
        }

        public void AddVertex(int value)
        {
            adjacentList.Add(value, new List<int>());
            numberOfNodes++;
        }

        public void AddEdge(int value1, int value2)
        {
            adjacentList[value1].Add(value2);
            adjacentList[value2].Add(value1);
        }

        public void ShowConnections()
        {
            foreach (var item in adjacentList)
            {
                List<int> nodeConnections = adjacentList[item.Key];
                StringBuilder connections = new StringBuilder();

                foreach (var edge in nodeConnections)
                {
                    connections.Append(edge).Append(" ");
                }

                Console.WriteLine(item.Key + "-->" + connections);
            }
        }
    }
}
