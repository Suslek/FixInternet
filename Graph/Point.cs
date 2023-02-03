using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Point
    {
        int id;
        List<int> neighbours = new List<int> { };

        public int GetId()
        {
            return id;
        }
        
        public void SetId(int newId)
        {
            id = newId;
        }

        public void AddNeighbour(Point other)
        {
            int otherId = other.GetId();
            if (!neighbours.Contains(otherId))
            {
                neighbours.Add(otherId);
            }
        }

        public void UnionNeighbours(List<int> neighboursOfOther)
        {
            var tmp = neighbours.Union(neighboursOfOther);
            neighbours = tmp.ToList<int>();
        }

        public List<int> GetNeighbours()
        {
            return neighbours;
        }

        public Point(int Id)
        {
            id = Id;
            neighbours = new List<int>();
            neighbours.Add(id);
        }
    }
}
