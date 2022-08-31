/*
 * @lc app=leetcode.cn id=1408 lang=java
 *
 * [1408] 数组中的字符串匹配
 */
import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {

  /**
   * 67/67 cases passed (5 ms)
   * Your runtime beats 21.07 % of java submissions
   * Your memory usage beats 75.9 % of java submissions (40.1 MB)
   * @param words
   * @return
   */
  public List<String> stringMatching(String[] words) {
    var ans = new ArrayList<String>();
    for (var i = 0; i < words.length; i++) {
      for (var j = 0; j < words.length; j++) {
        if (i == j) {
          continue;
        }
        if (words[i].length() > words[j].length()) {
          continue;
        }
        if (words[j].contains(words[i])) {
          ans.add(words[i]);
          break;
        }
      }
    }
    return ans;
  }
}
// @lc code=end
