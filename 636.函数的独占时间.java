/*
 * @lc app=leetcode.cn id=636 lang=java
 *
 * [636] 函数的独占时间
 */
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Stack;

// @lc code=start
class Solution {

  /**
   * 120/120 cases passed (16 ms)
   * Your runtime beats 6.34 % of java submissions
   * Your memory usage beats 91.31 % of java submissions (41.7 MB)
   * @param n
   * @param logs
   * @return
   */
  public int[] exclusiveTime(int n, List<String> logs) {
    var st = new Stack<Map.Entry<Integer, Integer>>();
    var res = new int[n];
    for (var log : logs) {
      var type = new char[10];
      int idx, timestamp;
      var logstrs = log.split(":");
      idx = Integer.parseInt(logstrs[0]);
      type = logstrs[1].toCharArray();
      timestamp = Integer.parseInt(logstrs[2]);
      if (type[0] == 's') {
        if (!st.empty()) {
          res[st.lastElement().getKey()] +=
            timestamp - st.lastElement().getValue();
          st.lastElement().setValue(timestamp);
        }
        st.add(new HashMap.SimpleEntry<>(idx, timestamp));
      } else {
        var t = st.lastElement();
        st.pop();
        res[t.getKey()] += timestamp - t.getValue() + 1;
        if (!st.empty()) {
          st.lastElement().setValue(timestamp + 1);
        }
      }
    }
    return res;
  }
}
// @lc code=end
