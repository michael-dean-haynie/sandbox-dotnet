namespace LeetCode.Problems._684_RedundantConnection;

public class Tests
{
    private Solution _solution;

    [SetUp]
    public void Setup()
    {
        _solution = new Solution();
    }

    [Test]
    public void Test1()
    {
        int[][] edges = [[1, 2], [1, 3], [2, 3]];
        int[] expected = [2, 3];
        
        var result = _solution.FindRedundantConnection(edges);

        Assert.That(result, Is.EqualTo(expected));
    }
}