namespace connected_components_count
{
    public class Program
    {
        public static int connectedComponentsCount(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            int count = 0;

            // start iterating through ever node of the graph
            foreach (int node in graph.Keys)
            {
                if(traverseComponentBfs(graph, node, visited))
                {
                    count++;
                }

            }
            return count;
        }

        public static Boolean traverseComponentBfs(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
        {
            Queue<int> queue = new Queue<int>();
            if (visited.Contains(node)) return false;
            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count != 0) 
            { 
                int currentNode = queue.Dequeue();
                foreach(int neighbour in graph.GetValueOrDefault(currentNode))
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }
                   
                }
            }

            return true; // indicates we have traversed through all the neighbours
        }

        public static Boolean traverseComponent(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
        {
            if (visited.Contains(node)) return false; // dont want to double count and get stuck in an infinite look
            visited.Add(node);


            foreach (int neighbour in graph.GetValueOrDefault(node)) // gets neighbours of current node
            {
                traverseComponent(graph, neighbour, visited); // recursive call
            }

            return true; // returns true because it is the first time traversing this part of the graph and signals we should increment the count
        }
        public static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>> {
                {0,new List<int>{8,1,5} },
                {1,new List<int>{0} },
                {5,new List<int>{0,8} },
                {8,new List<int>{0, 5} },
                {2,new List<int>{3, 4} },
                {3,new List<int>{2, 4} },
                {4,new List<int>{3,2} }


            };
            Console.WriteLine(connectedComponentsCount(graph));
           
        }
    }
}
