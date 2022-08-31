/*
 * @lc app=leetcode.cn id=406 lang=java
 *
 * [406] 根据身高重建队列
 */
import java.util.Arrays;
import java.util.LinkedList;

// @lc code=start
class Solution {

  /**
   * 36/36 cases passed (7 ms)
   * Your runtime beats 65.3 % of java submissions
   * Your memory usage beats 77.21 % of java submissions (42.1 MB)
   * @param people
   * @return
   */
  public int[][] reconstructQueue(int[][] people) {
    Arrays.sort(
      people,
      (a, b) -> {
        if (a[0] == b[0]) {
          // if height value is the same, then sort by k in raising powers
          return a[1] - b[1];
        }
        return b[0] - a[0]; // sort by height in descending powers
      }
    );
    var res = new LinkedList<int[]>();
    for (var x : people) {
      res.add(x[1], x);
    }
    return res.toArray(new int[people.length][]);
  }
}
// @lc code=end
