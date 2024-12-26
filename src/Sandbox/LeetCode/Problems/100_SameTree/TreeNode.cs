namespace LeetCode.Problems._100_SameTree;

// ReSharper disable once ClassNeverInstantiated.Global
public class TreeNode {

    // ReSharper disable All
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    
    public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
    // ReSharper restore All


    /**
     * https://support.leetcode.com/hc/en-us/articles/32442719377939-How-to-create-test-cases-on-LeetCode
     */
    public TreeNode(int?[] serialized) : this(serialized[0] ?? 0)
    {
        int i = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            
            // left child
            i++;
            if (i < serialized.Length)
            {
                var currentVal = serialized[i];
                if (currentVal != null)
                {
                    var child = new TreeNode(currentVal.Value);
                    currentNode.left = child;
                    queue.Enqueue(child);
                }
            }
            
            // right child
            i++;
            if (i < serialized.Length)
            {
                var currentVal = serialized[i];
                if (currentVal != null)
                {
                    var child = new TreeNode(currentVal.Value);
                    currentNode.right = child;
                    queue.Enqueue(child);
                }
            }
        }
    }
}
