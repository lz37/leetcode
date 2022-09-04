import java.util.Arrays;
import java.util.Comparator;

/*
 * @lc app=leetcode.cn id=646 lang=java
 *
 * [646] 最长数对链
 */

// @lc code=start
class Solution {

  /**
   * 205/205 cases passed (30 ms)
   * Your runtime beats 37.5 % of java submissions
   * Your memory usage beats 92.1 % of java submissions (41.3 MB)
   * @param pairs
   * @return
   */
  public int findLongestChain(int[][] pairs) {
    var res = 0;
    var dp = new int[pairs.length];
    Arrays.sort(
      pairs,
      new Comparator<int[]>() {
        @Override
        public int compare(int[] o1, int[] o2) {
          return o1[0] - o2[0];
        }
      }
    );
    for (int i = 1; i < pairs.length; i++) {
      for (int j = i - 1; j >= 0; j--) {
        if (pairs[i][0] > pairs[j][1]) {
          dp[i] = Math.max(dp[i], dp[j] + 1);
        }
      }
      res = Math.max(res, dp[i]);
    }
    return res + 1;
  }
}
// @lc code=end
