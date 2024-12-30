namespace LeetCode.Problems._692_TopKFrequentWords;

/**
* https://leetcode.com/problems/top-k-frequent-words/
*/
public class Solution {
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var heap = new IndexedHeap();
        foreach (var word in words)
        {
            heap.Increment(word);
        }

        var result = new List<string>();
        for (var i = 0; i < k; i++)
        {
            result.Add(heap.ExtractMax());
        }

        return result;
    }
}

/**
 * Combines properties MaxHeap/PriorityQueue and a HashMap.
 *
 * MaxHeap/PriorityQueue
 *      - insert = O(log(n))
 *      - find-max = O(1)
 * 
 * HashMap
 *      - insert = O(1)
 *      - get/set = 0(1)
 */
internal interface IIndexedHeap
{
    
    /**
     * Increments the priority of a particular value, or initializes it to 1 if new.
     */
    void Increment(string value);

    /**
     * Removes and returns the value with max priority.
     */
    string ExtractMax();

}

internal class IndexedHeap : IIndexedHeap
{
    private readonly List<Node> _nodeList;
    private readonly Dictionary<string, int> _valueIndexMap;
    
    public IndexedHeap()
    {
        _nodeList = new List<Node>();
        _valueIndexMap = new Dictionary<string, int>();
    }

    public void Increment(string value)
    {
        if (_valueIndexMap.TryGetValue(value, out int index))
        {
            _nodeList[index].Priority++;
            SiftUp(index);
        }
        else
        {
            Insert(value);
        }
    }
    
    public string ExtractMax()
    {
        var result = _nodeList[0].Value;
        
        Swap(0, _nodeList.Count - 1);
        _nodeList.RemoveAt(_nodeList.Count - 1);
        if (_nodeList.Count > 0)
        {
            SiftDown(0);
        }
        
        return result;
    }

    private void Insert(string value)
    {
        _nodeList.Add(new Node(value));
        int nodeIndex = _nodeList.Count - 1;
        _valueIndexMap[value] = nodeIndex;
        SiftUp(nodeIndex);
    }

    private void SiftUp(int index)
    {
        if (index == 0)
        {
            return;
        }
        
        var child = _nodeList[index];
        
        var parentIndex = ParentIndex(index);
        var parent = _nodeList[parentIndex];

        if (child.CompareTo(parent) < 0)
        {
            Swap(index, parentIndex);
            SiftUp(parentIndex);
        }
    }

    private void SiftDown(int index)
    {
        var parent = _nodeList[index];
        
        var leftIndex = LeftChildIndex(index);
        if (leftIndex > _nodeList.Count - 1)
        {
            return; // no left child exists (meaning no right child exists either)
        }
        var left = _nodeList[leftIndex];
        
        // default to swapping left child
        var child = left;
        var childIndex = leftIndex;
        
        // swap right child if it should come before left child
        var rightIndex = RightChildIndex(index);
        if (rightIndex <= _nodeList.Count - 1)
        {
            var right = _nodeList[rightIndex];
            if (left.CompareTo(right) > 0)
            {
                child = right;
                childIndex = rightIndex;
            }
        }

        // actually swap if child should come before parent
        if (child.CompareTo(parent) < 0)
        {
            Swap(childIndex, index);
            SiftDown(childIndex);
        }
    }

    private int LeftChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }
    
    private int RightChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }

    private int ParentIndex(int childIndex)
    {
        return (int)Math.Floor((double)(childIndex - 1) / 2);
    }

    private void Swap(int indexA, int indexB)
    {
        // swap values in the backing list
        var temp = _nodeList[indexA];
        _nodeList[indexA] = _nodeList[indexB];
        _nodeList[indexB] = temp;

        // also update the value-to-index map
        _valueIndexMap[_nodeList[indexA].Value] = indexA;
        _valueIndexMap[_nodeList[indexB].Value] = indexB;
    }
}

internal class Node : IComparable<Node>
{
    public string Value { get; }
    public int Priority { get; set; }

    public Node(string value, int priority = 1)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
        Priority = priority;
    }

    public int CompareTo(Node? other)
    {
        ArgumentNullException.ThrowIfNull(other, nameof(other));

        var priorityDiff = other.Priority - this.Priority;
        if (priorityDiff == 0)
        {
            // use lexicographical order if priorities are the same
            return String.Compare(this.Value, other.Value, StringComparison.Ordinal);
        }
        else
        {
            return priorityDiff;
        }
    }
}