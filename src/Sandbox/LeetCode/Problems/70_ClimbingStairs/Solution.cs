namespace LeetCode.Problems._70_ClimbingStairs;

/**
* https://leetcode.com/problems/climbing-stairs/
*/
public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] nextSteps = [0, 0]; // remember results for next 2 steps (working backward)
        for (int i = n; i >= 0; i--)
        {
            int options;
            if (n - i == 1)
            {
                options = 1;
            }
            else if (n - i == 2)
            {
                options = 2;
            }
            else
            {
                // you can either move 1 step or 2 steps, and your options are the sum of options from where those 2 options leave you
                options = nextSteps[0] + nextSteps[1];
            }

            nextSteps[1] = nextSteps[0];
            nextSteps[0] = options;
        }

        return nextSteps[0];
    }
}