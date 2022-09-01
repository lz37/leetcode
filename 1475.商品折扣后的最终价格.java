/*
 * @lc app=leetcode.cn id=1475 lang=java
 *
 * [1475] 商品折扣后的最终价格
 */

// @lc code=start
class Solution {

  /**
   * 103/103 cases passed (1 ms)
   * Your runtime beats 98.71 % of java submissions
   * Your memory usage beats 5.27 % of java submissions (42 MB)
   * @param prices
   * @return
   */
  public int[] finalPrices(int[] prices) {
    var res = prices;
    for (int i = 0; i < prices.length; i++) {
      for (int j = i + 1; j < prices.length; j++) {
        if (prices[j] <= res[i]) {
          res[i] -= prices[j];
          break;
        }
      }
    }
    return res;
  }
}
// @lc code=end
