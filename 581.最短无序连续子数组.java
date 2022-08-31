/*
 * @lc app=leetcode.cn id=581 lang=java
 *
 * [581] 最短无序连续子数组
 */

// @lc code=start
class Solution {

  /**
   * 307/307 cases passed (1 ms)
   * Your runtime beats 91.54 % of java submissions
   * Your memory usage beats 72.37 % of java submissions (41.9 MB)
   * @see
   * https://leetcode.cn/problems/shortest-unsorted-continuous-subarray/comments/
   * @param nums
   * @return
   */
  public int findUnsortedSubarray(int[] nums) {
    if (nums.length < 2) {
      return 0;
    }
    var max = Integer.MIN_VALUE;
    var min = Integer.MAX_VALUE;
    var R = 0;
    var L = 0;
    for (int i = 0; i < nums.length; i++) {
      if (max > nums[i]) {
        R = i;
      }
      max = Math.max(max, nums[i]);
    }
    for (int i = nums.length - 1; i >= 0; i--) {
      if (min < nums[i]) {
        L = i;
      }
      min = Math.min(min, nums[i]);
    }
    return R == L ? 0 : R - L + 1;
  }
}
// @lc code=end
