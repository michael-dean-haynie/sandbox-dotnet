namespace LeetCode.Problems._20_ValidParentheses;

/**
* https://leetcode.com/problems/valid-parentheses/
*/
public class Solution
{
    private readonly Dictionary<char, char> _parenMap;

    private IEnumerable<char> Openers => _parenMap.Keys;
    
    private IEnumerable<char> Closers => _parenMap.Values;

    public Solution()
    {
        _parenMap = new Dictionary<char, char>()
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' },
        };
    }
    
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (Openers.Contains(c))
            {
                stack.Push(c);
            } 
            else if (Closers.Contains(c))
            {
                if (stack.TryPop(out char opener))
                {
                    if (_parenMap.TryGetValue(opener, out char expectedCloser))
                    {
                        if (c == expectedCloser)
                        {
                            continue; // closer matched with correct opener
                        }
                        else
                        {
                            return false; // closer matched with incorrect opener
                        }
                    }
                    else
                    {
                        throw new FormatException($"The string contained unexpected character '{c}'.");
                    }
                }
                else
                {
                    return false; // closer has no matching opener (position-wise)
                }
            }
        }

        if (stack.Count != 0)
        {
            return false; // opener has no matching closer (position-wise)
        }
        else
        {
            return true; // no issues were found!
        }
    }
}