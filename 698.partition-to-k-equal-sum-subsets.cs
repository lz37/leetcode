/*
 * @lc app=leetcode id=698 lang=csharp
 *
 * [698] Partition to K Equal Sum Subsets
 */
namespace Leetcode.Partition2KEqualSumSubsets;

// @lc code=start
public class Solution
{
    private int[] nums;

    /// <summary>
    /// 表示当前每个子集的和
    /// </summary>
    private int[] cur;
    private int sum;

    /// <summary>
    /// 从最后一个元素开始，依次尝试将其加入到 cur 的每个子集中。这里如果将 nums[i] 加入某个子集 cur[j] 后，子集的和超过 sum，说明无法放入，可以直接跳过；另外，如果 cur[j] 与 cur[j - 1] 相等，意味着我们在 cur[j - 1] 的时候已经完成了搜索，也可以跳过当前的搜索
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private bool dfs(int i)
    {
        if (i < 0)
        {
            return true;
        }
        for (int j = 0; j < cur.Length; ++j)
        {
            // 这一步为了剪枝
            if (j > 0 && cur[j] == cur[j - 1])
            {
                continue;
            }
            cur[j] += nums[i];
            if (cur[j] <= sum && dfs(i - 1))
            {
                return true;
            }
            cur[j] -= nums[i];
        }
        return false;
    }

    /// <summary>
    /// 162/162 cases passed (173 ms)
    /// Your runtime beats 98.59 % of csharp submissions
    /// Your memory usage beats 95.77 % of csharp submissions (38.9 MB)
    /// </summary>
    /// <param name="nums"/></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        sum = nums.Sum();
        if (sum % k != 0)
        {
            return false;
        }
        sum /= k;
        cur = new int[k];
        Array.Sort(nums);
        this.nums = nums;
        return dfs(nums.Length - 1);
    }
}
// @lc code=end
