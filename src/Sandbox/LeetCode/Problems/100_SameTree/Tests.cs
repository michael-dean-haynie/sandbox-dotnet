namespace LeetCode.Problems._100_SameTree;

public class Tests
{
    private Solution _solution;
    // private EditorialSolution _solution;

    [SetUp]
    public void Setup()
    {
        _solution = new Solution();
        // _solution = new EditorialSolution();
    }

    [Test]
    public void Test1()
    {
        int?[] p = [1, 2, 3];
        int?[] q = [1, 2, 3];

        var pTree = new TreeNode(p);
        var qTree = new TreeNode(q);

        var result = _solution.IsSameTree(pTree, qTree);
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Test2()
    {
        int?[] p = [1,2];
        int?[] q = [1,null,2];

        var pTree = new TreeNode(p);
        var qTree = new TreeNode(q);

        var result = _solution.IsSameTree(pTree, qTree);
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void Test3()
    {
        int?[] p = [1,2,1];
        int?[] q = [1,1,2];

        var pTree = new TreeNode(p);
        var qTree = new TreeNode(q);

        var result = _solution.IsSameTree(pTree, qTree);
        Assert.That(result, Is.False);
    }
}