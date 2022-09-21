/*
 * @lc app=leetcode.cn id=1624 lang=java
 *
 * [1624] 两个相同字符之间的最长子字符串
 */

// @lc code=start
class Solution {

  /**
   * 54/54 cases passed (1 ms)
   * Your runtime beats 64.21 % of java submissions
   * Your memory usage beats 84.58 % of java submissions (39.1 MB)
   */
  public int maxLengthBetweenEqualCharacters(String s) {
    var firstPos = new Integer[26];
    var max = -1;
    for (int i = 0; i < s.length(); i++) {
      if (firstPos[s.charAt(i) - 'a'] == null) {
        firstPos[s.charAt(i) - 'a'] = i;
      } else {
        max = Math.max(i - firstPos[s.charAt(i) - 'a'] - 1, max);
      }
    }
    return max;
  }
}
// @lc code=end
