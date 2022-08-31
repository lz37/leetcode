/*
 * @lc app=leetcode.cn id=399 lang=java
 *
 * [399] 除法求值
 */
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {

  private Map<String, Map<String, Double>> graph;

  private Double findTarget(String start, String target, Set<String> visited) {
    if (start.equals(target)) {
      return 1.0;
    }
    for (var entry : graph.get(start).entrySet()) {
      if (visited.contains(entry.getKey())) {
        continue;
      }
      visited.add(entry.getKey());
      var tmp = findTarget(entry.getKey(), target, visited);
      if (tmp != -1.0) {
        return tmp * entry.getValue();
      }
    }
    return -1.0;
  }

  /**
   * 24/24 cases passed (1 ms)
   * Your runtime beats 50.99 % of java submissions
   * Your memory usage beats 5.11 % of java submissions (40.5 MB)
   * @param equations
   * @param values
   * @param queries
   * @return
   */
  public double[] calcEquation(
    List<List<String>> equations,
    double[] values,
    List<List<String>> queries
  ) {
    graph = new HashMap<>();
    var ans = new double[queries.size()];
    for (int i = 0; i < ans.length; i++) {
      ans[i] = -1.0;
    }
    for (int i = 0; i < equations.size(); i++) {
      var start = equations.get(i).get(0);
      var end = equations.get(i).get(1);
      var value = values[i];
      if (!graph.containsKey(start)) {
        graph.put(start, new HashMap<>());
      }
      if (!graph.containsKey(end)) {
        graph.put(end, new HashMap<>());
      }
      graph.get(start).put(end, value);
      graph.get(end).put(start, 1.0 / value);
    }
    for (int i = 0; i < queries.size(); i++) {
      if (
        graph.containsKey(queries.get(i).get(0)) &&
        graph.containsKey(queries.get(i).get(1))
      ) {
        ans[i] =
          findTarget(
            queries.get(i).get(0),
            queries.get(i).get(1),
            new HashSet<>()
          );
      }
    }
    return ans;
  }
}
// @lc code=end
