/*
 * @lc app=leetcode id=646 lang=csharp
 *
 * [646] Maximum Length of Pair Chain
 */
namespace Leetcode.MaximumLengthOfPairChain;

// @lc code=start
public class Solution
{
    public int FindLongestChain(int[][] pairs)
    {
        var res = 0;
        var dp = new int[pairs.Length];
        Array.Sort(pairs, (a, b) => a[0] - b[0]);
        for (int i = 1; i < pairs.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (pairs[i][0] > pairs[j][1])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            res = Math.Max(res, dp[i]);
        }
        return res + 1;
    }
}
// @lc code=end
