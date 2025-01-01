namespace LeetCode.Problems._70_ClimbingStairs;

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
        var n = 2;
        var expected = 2;

        var result = _solution.ClimbStairs(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}