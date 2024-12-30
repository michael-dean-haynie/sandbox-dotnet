
namespace LeetCode.Problems._692_TopKFrequentWords;

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
        string[] words = ["i", "love", "leetcode", "i", "love", "coding"];
        int k = 2;
        
        var result = _solution.TopKFrequent(words, k);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Exactly(k).Items);
        
        Assert.That(result[0], Is.EqualTo("i"));
        Assert.That(result[1], Is.EqualTo("love"));
    }

    [Test]
    public void Test2()
    {
        string[] words = ["the","day","is","sunny","the","the","the","sunny","is","is"];
        int k = 4;
        
        var result = _solution.TopKFrequent(words, k);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Exactly(k).Items);
        
        Assert.That(result[0], Is.EqualTo("the"));
        Assert.That(result[1], Is.EqualTo("is"));
        Assert.That(result[2], Is.EqualTo("sunny"));
        Assert.That(result[3], Is.EqualTo("day"));
    }
}