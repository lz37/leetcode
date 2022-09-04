/*
 * @lc app=leetcode.cn id=1582 lang=java
 *
 * [1582] 二进制矩阵中的特殊位置
 */

// @lc code=start
class Solution {

  /**
   * 95/95 cases passed (1 ms)
   * Your runtime beats 100 % of java submissions
   * Your memory usage beats 70.69 % of java submissions (41.5 MB)
   * @param mat
   * @return
   */
  public int numSpecial(int[][] mat) {
    var rows = mat.length;
    var cols = mat[0].length;
    var rowNumOf1 = new int[rows];
    var colsNumOf1 = new int[cols];
    var res = 0;
    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        if (mat[i][j] == 1) {
          rowNumOf1[i]++;
          colsNumOf1[j]++;
        }
      }
    }
    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        if (mat[i][j] == 1 && rowNumOf1[i] == 1 && colsNumOf1[j] == 1) {
          res++;
        }
      }
    }
    return res;
  }
}
// @lc code=end
