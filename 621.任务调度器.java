/*
 * @lc app=leetcode.cn id=621 lang=java
 *
 * [621] 任务调度器
 */
import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {

  private char findMostChar(Map<Character, Integer> hash) {
    var mostChar = 'A';
    for (var i = 'A'; i <= 'Z'; i++) {
      if (hash.getOrDefault(i, 0) > hash.getOrDefault(mostChar, 0)) {
        mostChar = i;
      }
    }
    return mostChar;
  }

  /**
   * 71/71 cases passed (14 ms)
   * Your runtime beats 38.26 % of java submissions
   * Your memory usage beats 91.65 % of java submissions (42 MB)
   * @param tasks
   * @param n
   * @return
   */
  public int leastInterval(char[] tasks, int n) {
    var hash = new HashMap<Character, Integer>();
    for (var task : tasks) {
      hash.put(task, hash.getOrDefault(task, 0) + 1);
    }
    char mostChar;
    int length = 0, mostTasks = 0;
    for (; hash.get(mostChar = findMostChar(hash)) != 0;) {
      if (mostTasks == 0) {
        mostTasks = hash.get(mostChar);
        length = hash.get(mostChar) * (n + 1) - n;
      } else {
        if (hash.get(mostChar) == mostTasks) {
          length++;
        }
      }
      hash.put(mostChar, 0);
    }
    return Math.max(length, tasks.length);
  }
}
// @lc code=end
