namespace LeetCode.Problems._210_CourseScheduleII;

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
        int numCourses = 2;
        int[][] prerequisites = [[1, 0]];
        int[] expected = [0, 1];
        
        var result = _solution.FindOrder(numCourses, prerequisites);

        Assert.That(result, Is.EqualTo(expected));
        
    }

    [Test]
    public void Test2()
    {
        int numCourses = 2;
        int[][] prerequisites = [[0,1],[1,0]];
        int[] expected = [];
        
        var result = _solution.FindOrder(numCourses, prerequisites);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}