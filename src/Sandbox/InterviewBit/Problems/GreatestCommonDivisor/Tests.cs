namespace InterviewBit.Problems.GreatestCommonDivisor;

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
        var a = 6;
        var b = 9;
        var expected = 3;
        
        var result = _solution.gcd(a, b);
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Test2()
    {
        var a = 2;
        var b = 0;
        var expected = 2;
        
        var result = _solution.gcd(a, b);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}