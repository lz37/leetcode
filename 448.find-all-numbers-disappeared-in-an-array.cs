/*
 * @lc app=leetcode id=448 lang=csharp
 *
 * [448] Find All Numbers Disappeared in an Array
 */
namespace Leetcode.FindAllNumbersDisappearedInAnArray;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 33/33 cases passed (377 ms)
    /// Your runtime beats 55.46 % of csharp submissions
    /// Your memory usage beats 58.33 % of csharp submissions (49.2 MB)
    /// [4,3,2,7,8,2,3,1] : 初始数据
    /// <br/>
    /// [4,3,2,-7,8,2,3,1]
    /// 第一个数据 4 出现，将数组的第四个也就是下标 3 的数据修改为负数 -7
    /// 计算时，通过绝对值处理一下即可不影响数据的计算
    /// <code>
    /// [4,3,-2,-7,8,2,3,1]
    /// [4,-3,-2,-7,8,2,3,1]
    /// [4,-3,-2,-7,8,2,-3,1]
    /// [4,-3,-2,-7,8,2,-3,-1]
    /// [4,-3,-2,-7,8,2,-3,-1]
    /// [4,-3,-2,-7,8,2,-3,-1]
    /// [-4,-3,-2,-7,8,2,-3,-1]
    /// </code>
    /// 计算结束，数组的第五个，第六个依然为整数，证明 5,6 没有出现
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[Math.Abs(nums[i]) - 1] > 0)
            {
                nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
            }
        }
        var res = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                res.Add(i + 1);
            }
        }
        return res;
    }
}
// @lc code=end
