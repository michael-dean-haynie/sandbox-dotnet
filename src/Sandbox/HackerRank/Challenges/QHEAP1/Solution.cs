namespace HackerRank.Challenges.QHEAP1;

/**
* https://www.hackerrank.com/challenges/qheap1/problem
*/
// class Solution {
//     public static void Main(String[] args)
//     {
//         new RealSolution().Execute();
//     }
// }

class RealSolution
{
    public void Execute()
    {
        // parse query count
        var queryCountLine = Console.ReadLine();
        if (queryCountLine == null)
        {
            throw new FormatException("STDIN missing query count line.");
        }

        if (!int.TryParse(queryCountLine, out var queryCount))
        {
            throw new FormatException($"STDIN query count line could not be parsed: '{queryCountLine}'");
        }
        
        // iterate over each input query line
        var pQueue = new PriorityQueue<int, int>();
        var removedValues = new HashSet<int>();
        for (int i = 0; i < queryCount; i++)
        {
            var queryLine = Console.ReadLine();
            if (queryLine == null)
            {
                throw new FormatException($"STDIN missing query line at index: {i}");
            }

            // parse tokens from the query line
            var lineTokens = queryLine.Split(' ');
            if (lineTokens.Length < 1)
            {
                throw new FormatException($"STDIN missing query token for line at index: {i}");
            }

            if (!Enum.TryParse(lineTokens[0], out Query query))
            {
                throw new FormatException($"STDIN query line at index '{i}' contains unexpected query type: '{lineTokens[0]}'.");
            }

            if (query == Query.Print)
            {
                bool tryNextValue = true;
                while (tryNextValue)
                {
                    if (!pQueue.TryPeek(out int minValue, out int priority))
                    {
                        throw new InvalidOperationException("Query line tried to read min value from empty collection.");
                    }

                    if (removedValues.Contains(minValue))
                    {
                        removedValues.Remove(minValue);
                        pQueue.Dequeue();
                    }
                    else
                    {
                        tryNextValue = false;
                    }
                }
                
                Console.WriteLine(pQueue.Peek());
                continue; // done with this query
            }
            else
            {
                if (lineTokens.Length < 2)
                {
                    throw new FormatException($"STDIN missing value token for line at index: {i}");
                }

                if (!int.TryParse(lineTokens[1], out int value))
                {
                    throw new FormatException($"Unable to parse value token '{lineTokens[1]}' for query line at index '{i}'.");
                }

                if (query == Query.Add)
                {
                    pQueue.Enqueue(value, value);
                    removedValues.Remove(value);
                    continue; // done with this query
                }
                else if (query == Query.Delete)
                {
                    removedValues.Add(value);
                    continue; // done with this query
                }
                else
                {
                    throw new Exception($"Unexpected query: {query}.");
                }
            }
            
            // throw new Exception("$Unhandled Query enum value: {query}");
        }
    }
}

enum Query
{
    Add = 1,
    Delete = 2,
    Print = 3
}