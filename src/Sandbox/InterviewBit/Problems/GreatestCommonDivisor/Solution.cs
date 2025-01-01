namespace InterviewBit.Problems.GreatestCommonDivisor;

/**
* https://www.interviewbit.com/problems/greatest-common-divisor/
*/
public class Solution  
{
    public int gcd(int A, int B)
    {
        if (A == 0)
        {
            return B;
        }

        if (B == 0)
        {
            return A;
        }
        
        var lesser = A < B ? A : B;

        for (int i = lesser; i > 0; i--)
        {
            if (A % i == 0 && B % i == 0)
            {
                return i;
            }
        }
        
        // should never really get here?
        return 1;
    }
}