/*
 * @lc app=leetcode.cn id=461 lang=java
 *
 * [461] 汉明距离
 */

// @lc code=start
class Solution {

  /**
   * 149/149 cases passed (0 ms)
   * Your runtime beats 100 % of java submissions
   * Your memory usage beats 44.28 % of java submissions (38.5 MB)
   * @param x
   * @param y
   * @return
   */
  public int hammingDistance(int x, int y) {
    int res = x % 2 != y % 2 ? 1 : 0;
    for (int i = 0; i < 31; i++) {
      res += (x >>= 1) % 2 != (y >>= 1) % 2 ? 1 : 0;
    }
    return res;
  }
}
// @lc code=end
