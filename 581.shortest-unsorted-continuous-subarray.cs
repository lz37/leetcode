/*
 * @lc app=leetcode id=581 lang=csharp
 *
 * [581] Shortest Unsorted Continuous Subarray
 */
namespace Leetcode.ShortestUnsortedContinuousSubarray;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 307/307 cases passed (133 ms)
    /// Your runtime beats 86.73 % of csharp submissions
    /// Your memory usage beats 94.9 % of csharp submissions (39.6 MB)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindUnsortedSubarray(int[] nums)
    {
        if (nums.Length < 2)
        {
            return 0;
        }
        var max = Int32.MinValue;
        var min = Int32.MaxValue;
        var R = 0;
        var L = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (max > nums[i])
            {
                R = i;
            }
            max = Math.Max(max, nums[i]);
        }
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (min < nums[i])
            {
                L = i;
            }
            min = Math.Min(min, nums[i]);
        }
        return R == L ? 0 : R - L + 1;
    }
}
// @lc code=end
