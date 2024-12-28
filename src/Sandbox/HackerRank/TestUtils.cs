namespace HackerRank;

public static class TestUtils
{
    public static void RunWithStdin(Action callback, string stdin)
    {
        var originalIn = Console.In;
        using (var reader = new StringReader(stdin))
        {
            Console.SetIn(reader);
            callback();
        }
        
        Console.SetIn(originalIn);
    }
}