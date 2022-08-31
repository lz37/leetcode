/*
 * @lc app=leetcode.cn id=494 lang=java
 *
 * [494] 目标和
 */

// @lc code=start
class Solution {

  /**
   * 139/139 cases passed (2 ms)
   * Your runtime beats 94.33 % of java submissions
   * Your memory usage beats 83.36 % of java submissions (39 MB)
   * <p>
   * sum(P) 前面符号为+的集合；sum(N) 前面符号为减号的集合
   * 所以题目可以转化为
   * </p>
   * <code>
   * sum(P) - sum(N) = target
   * => sum(nums) + sum(P) - sum(N) = target + sum(nums)
   * => 2 * sum(P) = target + sum(nums)
   * => sum(P) = (target + sum(nums)) / 2
   * </code>
   * <p>
   * 因此题目转化为01背包，也就是能组合成容量为sum(P)的方式有多少种
   * </p>
   * @param nums
   * @param target
   * @return
   */
  public int findTargetSumWays(int[] nums, int target) {
    var sum = 0;
    for (var num : nums) {
      sum += num;
    }
    if (sum < target || -sum > target || (sum + target) % 2 == 1) {
      return 0;
    }
    var w = (sum + target) / 2;
    var dp = new int[w + 1];
    dp[0] = 1;
    for (var num : nums) {
      for (int j = w; j >= num; j--) {
        dp[j] += dp[j - num];
      }
    }
    return dp[w];
  }
}
// @lc code=end
