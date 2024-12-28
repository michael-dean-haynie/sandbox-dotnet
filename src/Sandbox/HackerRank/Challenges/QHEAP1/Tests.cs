namespace HackerRank.Challenges.QHEAP1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        string stdin = 
        """
        5
        1 4
        1 9
        3
        2 4
        3
        """;
        var realSolution = new RealSolution();
        TestUtils.RunWithStdin(realSolution.Execute, stdin);
    }
}