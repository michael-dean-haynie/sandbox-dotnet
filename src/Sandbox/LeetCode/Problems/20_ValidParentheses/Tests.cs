namespace LeetCode.Problems._20_ValidParentheses;

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
        string input = "([])";
        
        var result = _solution.IsValid(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Test2()
    {
        string input = "(){}}{";
        
        var result = _solution.IsValid(input);
        
        Assert.That(result, Is.False);
    }
}