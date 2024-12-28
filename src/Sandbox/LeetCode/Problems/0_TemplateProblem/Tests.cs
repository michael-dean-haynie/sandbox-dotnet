namespace LeetCode.Problems._0_TemplateProblem;

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
        var result = _solution.Implementation();
        
        Assert.That(result, Is.True);
    }
}