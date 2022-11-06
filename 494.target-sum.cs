/*
 * @lc app=leetcode id=494 lang=csharp
 *
 * [494] Target Sum
 */
namespace Leetcode.TargetSum;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 139/139 cases passed (147 ms)
    /// Your runtime beats 86.07 % of csharp submissions
    /// Your memory usage beats 98.01 % of csharp submissions (37.1 MB)
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int FindTargetSumWays(int[] nums, int target)
    {
        var sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }
        if (sum < target || -sum > target || (sum + target) % 2 == 1)
        {
            return 0;
        }
        var w = (sum + target) / 2;
        var dp = new int[w + 1];
        dp[0] = 1;
        foreach (var num in nums)
        {
            for (int j = w; j >= num; j--)
            {
                dp[j] += dp[j - num];
            }
        }
        return dp[w];
    }
}
// @lc code=end
