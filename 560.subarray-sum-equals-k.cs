/*
 * @lc app=leetcode id=560 lang=csharp
 *
 * [560] Subarray Sum Equals K
 */
namespace Leetcode.SubarraySumEqualsK;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 92/92 cases passed (247 ms)
    /// Your runtime beats 67.56 % of csharp submissions
    /// Your memory usage beats 44.67 % of csharp submissions (43.1 MB)
    /// <see href="https://leetcode.cn/problems/subarray-sum-equals-k/solution/bao-li-jie-fa-qian-zhui-he-qian-zhui-he-you-hua-ja/"/>
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int SubarraySum(int[] nums, int k)
    {
        var preSumFreq = new Dictionary<int, int>();
        preSumFreq[0] = 1;
        var preSum = 0;
        var count = 0;
        foreach (var num in nums)
        {
            preSum += num;
            if (preSumFreq.ContainsKey(preSum - k))
            {
                count += preSumFreq[preSum - k];
            }
            preSumFreq[preSum] = preSumFreq.TryGetValue(preSum, out var freq) ? freq + 1 : 1;
        }
        return count;
    }
}
// @lc code=end
