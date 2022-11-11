/*
 * @lc app=leetcode id=26 lang=csharp
 *
 * [26] Remove Duplicates from Sorted Array
 */
namespace Leetcode.RemoveDuplicatesfromSortedArray;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 361/361 cases passed (153 ms)
    /// Your runtime beats 92.33 % of csharp submissions
    /// Your memory usage beats 14.65 % of csharp submissions (46 MB)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        var i = 0;
        var now = nums[0];
        var res = 1;
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] != now)
            {
                res++;
                nums[++i] = nums[j];
                now = nums[j];
            }
        }
        return res;
    }
}
// @lc code=end
