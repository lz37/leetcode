/*
 * @lc app=leetcode.cn id=461 lang=cpp
 *
 * [461] 汉明距离
 */

// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 149/149 cases passed (0 ms)
   * Your runtime beats 100 % of cpp submissions
   * Your memory usage beats 65.83 % of cpp submissions (5.8 MB)
   * @param x
   * @param y
   * @return int
   */
  int hammingDistance(int x, int y) {
    int res = x % 2 != y % 2;
    for (int i = 0; i < 31; i++)
      res += (x >>= 1) % 2 != (y >>= 1) % 2;
    return res;
  }
};
// @lc code=end
