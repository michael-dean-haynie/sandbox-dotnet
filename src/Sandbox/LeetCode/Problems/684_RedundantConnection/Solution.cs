namespace LeetCode.Problems._684_RedundantConnection;

/**
* https://leetcode.com/problems/redundant-connection/
*/
public class Solution  
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        // group edges into adjacency lists by nodes
        List<int>?[] adjNodes = new List<int>[edges.Length + 1];
        foreach (var edge in edges)
        {
            var v1 = edge[0];
            var v2 = edge[1];

            var v1Adj = adjNodes[v1] ??= [];
            v1Adj.Add(v2);
            adjNodes[v1] = v1Adj;

            var v2Adj = adjNodes[v2] ??= [];
            v2Adj.Add(v1);
            adjNodes[v2] = v2Adj;
        }

        var cycle = new List<int>();
        var visited = new bool[edges.Length + 1];
        var stack = new Stack<int>();
        stack.Push(1);
        while (cycle.Count == 0) // while cycle has not been found
        {
            // get current node, and the previous node from the stack
            var node = stack.Pop();
            var prevNode = 0;
            if (stack.Any())
            {
                prevNode = stack.Peek();
            }
            stack.Push(node);
            
            bool visitedAllAdj = true;
            foreach (var adjNode in adjNodes[node] ?? [])
            {
                if (adjNode == prevNode)
                {
                    continue; // ignore back-tracking edges
                }
                
                // check for cycle
                if (stack.Contains(adjNode))
                {
                    var path = stack.Reverse().ToList();
                    var cycleStart = path.IndexOf(adjNode);
                    cycle.AddRange(path[cycleStart..]);
                    break;
                }
                
                // skip if already visited
                if (visited[adjNode])
                {
                    continue;
                }

                // dive deeper
                visitedAllAdj = false;
                stack.Push(adjNode);
                break;
            }

            // back track
            if (visitedAllAdj)
            {
                visited[node] = true;
                stack.Pop();
            }
        }

        int[,] cycleEdges = new int[cycle.Count, 2];
        for (int i = 0; i < cycle.Count; i++)
        {
            cycleEdges[i, 0] = cycle[i];
            int secondNode = i + 1;
            if (secondNode >= cycle.Count)
            {
                secondNode = 0;
            }
            cycleEdges[i, 1] = cycle[secondNode];
        }

        for (int i = edges.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < cycleEdges.GetLength(0); j++)
            {
                var edge = edges[i];
                int[] cycleEdge = [cycleEdges[j, 0], cycleEdges[j, 1]];

                if ((edge[0] == cycleEdge[0] && edge[1] == cycleEdge[1]) ||
                    (edge[0] == cycleEdge[1] && edge[1] == cycleEdge[0]))
                {
                    return edge;
                }
            }
        }
        
        // should never get here
        return [0, 0];
    }
}