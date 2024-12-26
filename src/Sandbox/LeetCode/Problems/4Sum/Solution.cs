namespace LeetCode.Problems._4Sum;

// https://leetcode.com/problems/4sum/description/
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        
        // preserve (at most) 4 duplicates of any input value
        var numBuffer = new Dictionary<int, int>();
        var dedupedNums = new List<int>();
        foreach (int num in nums)
        {
            // skip any nums that have already been processed 4 times
            if (numBuffer.GetValueOrDefault(num, 0) >= 4)
            {
                continue;
            }

            // add the kvp for num to the buffer, or increment existing kvp
            if (!numBuffer.TryAdd(num, 1))
            {
                numBuffer[num]++;
            }
            
            dedupedNums.Add(num);
        }
        
        var comparer = new IntSetEqualityComparer();
        var resultSet = new HashSet<int[]>(comparer);
        
        for (int a = 0; a < dedupedNums.Count; a++)
        {
            for (int b = a + 1; b < dedupedNums.Count; b++)
            {
                for (int c = b + 1; c < dedupedNums.Count; c++)
                {
                    for (int d = c + 1; d < dedupedNums.Count; d++)
                    {
                        long sum = 0;
                        sum += dedupedNums[a];
                        sum += dedupedNums[b];
                        sum += dedupedNums[c];
                        sum += dedupedNums[d];
                        if (sum == target)
                        {
                            int[] quadruplet =
                            [
                                dedupedNums[a],
                                dedupedNums[b],
                                dedupedNums[c],
                                dedupedNums[d]
                            ];
                            resultSet.Add(quadruplet);
                        }
                    }
                }
            }
        }

        return resultSet.Select(arr => (IList<int>)arr.ToList()).ToList();
    }

}

public class IntSetEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[]? xArr, int[]? yArr)
    {
        if (xArr == null && yArr == null)
        {
            return true;
        }

        if (xArr == null || yArr == null)
        {
            return false;
        }
        
        if (xArr.Length != yArr.Length)
        {
            return false;
        }
        
        // side effect: sorting in place - probably fine for this use case - saves some memory
        Array.Sort(xArr);
        Array.Sort(yArr);
        
        for (var i = 0; i < xArr.Length; i++)
        {
            if (xArr[i] != yArr[i])
            {
                return false;
            }
        }

        return true;
    }

    public int GetHashCode(int[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        
        unchecked // integer overflow is normal/expected for hashing algorithms
        {
            // sort the values
            // side effect: sorting in place - probably fine for this use case - saves some memory
            Array.Sort(values);
            
            // combine values in a standard way
            int hash = 17;
            foreach (int v in values)
            {
                // Multiply by a prime, add the element's hash
                hash = hash * 31 + v.GetHashCode();
            }
            return hash;
        }
    }
}