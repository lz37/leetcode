/*
 * @lc app=leetcode id=416 lang=csharp
 *
 * [416] Partition Equal Subset Sum
 */

namespace Leetcode.PartitionEqualSubsetSum;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 140/140 cases passed (184 ms)
    /// Your runtime beats 80.21 % of csharp submissions
    /// Your memory usage beats 99.37 % of csharp submissions (39 MB)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false; //整数相加不可能得小数
        }
        var W = sum / 2; //相当于背包总承重
        var dp = new int[W + 1];
        dp[0] = 1;
        Array.ForEach(
            nums,
            num =>
            {
                for (int i = W; i >= num; i--)
                {
                    dp[i] = dp[i] + dp[i - num];
                }
            }
        );
        return dp[W] != 0;
    }
}
// @lc code=end
