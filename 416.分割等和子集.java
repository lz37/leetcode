/*
 * @lc app=leetcode.cn id=416 lang=java
 *
 * [416] 分割等和子集
 */
// @lc code=start
class Solution {

  /**
   * 139/139 cases passed (15 ms)
   * Your runtime beats 96.04 % of java submissions
   * Your memory usage beats 66.05 % of java submissions (41 MB)
   * @param nums
   * @return
   */
  public boolean canPartition(int[] nums) {
    var sum = 0;
    for (int n : nums) {
      sum += n;
    }
    if (sum % 2 != 0) return false; //整数相加不可能得小数
    var W = sum / 2; //相当于背包总承重
    var dp = new int[W + 1];
    dp[0] = 1;
    for (int num : nums) {
      for (int i = W; i >= num; i--) {
        dp[i] += dp[i - num];
      }
    }
    return dp[W] != 0;
  }
}
// @lc code=end
// [20,9,10,18,14,4,15,19,19]
