/*
 * @lc app=leetcode.cn id=560 lang=java
 *
 * [560] 和为 K 的子数组
 */
import java.util.HashMap;

// @lc code=start
class Solution {

  /**
   * 92/92 cases passed (22 ms)
   * Your runtime beats 88.48 % of java submissions
   * Your memory usage beats 30.71 % of java submissions (45.8 MB)
   * @see
   * https://leetcode.cn/problems/subarray-sum-equals-k/solution/bao-li-jie-fa-qian-zhui-he-qian-zhui-he-you-hua-ja/
   * @param nums
   * @param k
   * @return
   */
  public int subarraySum(int[] nums, int k) {
    var preSumFreq = new HashMap<Integer, Integer>();
    preSumFreq.put(0, 1);
    var preSum = 0;
    var count = 0;
    for (var num : nums) {
      preSum += num;
      if (preSumFreq.containsKey(preSum - k)) {
        count += preSumFreq.get(preSum - k);
      }
      preSumFreq.put(preSum, preSumFreq.getOrDefault(preSum, 0) + 1);
    }
    return count;
  }
}
// @lc code=end
