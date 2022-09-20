/*
 * @lc app=leetcode.cn id=698 lang=java
 *
 * [698] 划分为k个相等的子集
 */
import java.util.Arrays;

// @lc code=start
class Solution {

  private int[] nums;
  /**
   * 表示当前每个子集的和
   */
  private int[] cur;
  private int sum;

  /**
   * 从最后一个元素开始，依次尝试将其加入到 cur 的每个子集中。这里如果将 nums[i] 加入某个子集 cur[j] 后，子集的和超过 sum，说明无法放入，可以直接跳过；另外，如果 cur[j] 与 cur[j - 1] 相等，意味着我们在 cur[j - 1] 的时候已经完成了搜索，也可以跳过当前的搜索。
   * @param i
   * @return
   */
  private boolean dfs(int i) {
    if (i < 0) {
      return true;
    }
    for (int j = 0; j < cur.length; ++j) {
      // 这一步为了剪枝
      if (j > 0 && cur[j] == cur[j - 1]) {
        continue;
      }
      cur[j] += nums[i];
      if (cur[j] <= sum && dfs(i - 1)) {
        return true;
      }
      cur[j] -= nums[i];
    }
    return false;
  }

  /**
   * 162/162 cases passed (3 ms)
   * Your runtime beats 81.6 % of java submissions
   * Your memory usage beats 64.06 % of java submissions (39.2 MB)
   * @param nums
   * @param k
   * @return
   */
  public boolean canPartitionKSubsets(int[] nums, int k) {
    sum = Arrays.stream(nums).sum();
    if (sum % k != 0) {
      return false;
    }
    sum /= k;
    cur = new int[k];
    Arrays.sort(nums);
    this.nums = nums;
    return dfs(nums.length - 1);
  }
}
// @lc code=end
/*
[3522,181,521,515,304,123,2512,312,922,407,146,1932,4037,2646,3871,269]\n5

[4,5,9,3,10,2,10,7,10,8,5,9,4,6,4,9]\n5



 */
