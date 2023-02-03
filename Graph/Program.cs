using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPoints;
            List<int> Connections = new List<int> { };
            List<Point> points = new List<Point>();
            int[] result;

            Console.WriteLine("Введите колличество точек");
            amountOfPoints = Convert.ToInt32(Console.ReadLine());
            result = new int[amountOfPoints];

            for (int i = 1; i < amountOfPoints + 1; i++)
            {
                points.Add(new Point(i));
            }

            Console.WriteLine("Введите пары");

            InputParsing(Connections);

            PairSetting(Connections, points);

            IslandsForming(points);
            
            ResultCompliting(points, result);

            int amountOfNeededConnections = result.Max() - 1;

            Console.WriteLine("Ответ: " + amountOfNeededConnections);

            Console.ReadLine();
        }

        private static void ResultCompliting(List<Point> points, int[] result)
        {
            int counter = 1;
            
            for (int i = 0; i < points.Count; i++)
            {
                if (result[i] == 0)
                {
                    List<int> currentIsland = points[i].GetNeighbours().ToList<int>();
                    for (int j = 0; j < currentIsland.Count; j++)
                    {
                        {
                            result[currentIsland[j] - 1] = counter;
                        }
                    }
                    currentIsland.Clear();
                    counter++;
                }
            }

            

            for (int i = 0; i < result.Length; i++)
            {
                int max = result.Max();
                if (result[i] == 0)
                {
                    max++;
                    result[i] = max;
                }

            }
        }

        private static void IslandsForming(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                var neighboursOfCurrent = points[i].GetNeighbours().ToList<int>();

                for (int j = 0; j < points.Count; j++)
                {
                    var neighboursOfOther = points[j].GetNeighbours().ToList<int>();

                    if (neighboursOfCurrent.Contains(points[j].GetId()) || neighboursOfOther.Contains(points[i].GetId()))
                    {
                        points[i].UnionNeighbours(points[j].GetNeighbours());
                        points[j].UnionNeighbours(points[i].GetNeighbours());

                    }
                    neighboursOfOther.Clear();
                }
                neighboursOfCurrent.Clear();
            }
        }

        private static void PairSetting(List<int> Connections, List<Point> points)
        {
            for (int i = 0; i < Connections.Count; i += 2)
            {
                Point FirstInPair = points[Connections[i] - 1];
                Point SecondInPair = points[Connections[i + 1] - 1];

                FirstInPair.AddNeighbour(SecondInPair);
                SecondInPair.AddNeighbour(FirstInPair);
            }
        }

        private static void InputParsing(List<int> Connections)
        {
            string input = Console.ReadLine();

            while (input != "")
            {
                string[] pair;
                pair = input.Split();
                Connections.Add(Convert.ToInt32(pair[0]));
                Connections.Add(Convert.ToInt32(pair[1]));

                input = Console.ReadLine();
            }
        }
    }
}
