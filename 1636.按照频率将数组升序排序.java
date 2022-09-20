/*
 * @lc app=leetcode.cn id=1636 lang=java
 *
 * [1636] 按照频率将数组升序排序
 */
import java.util.HashMap;
import java.util.Map;
import java.util.TreeSet;

// @lc code=start
class Solution {

  /**
   * 180/180 cases passed (6 ms)
   * Your runtime beats 45.66 % of java submissions
   * Your memory usage beats 80.64 % of java submissions (41.5 MB)
   * @param nums
   * @return
   */
  public int[] frequencySort(int[] nums) {
    var hash = new HashMap<Integer, Integer>();
    for (var num : nums) {
      hash.put(num, hash.getOrDefault(num, 0) + 1);
    }
    var set = new TreeSet<Map.Entry<Integer, Integer>>(
      (o1, o2) -> {
        if (o1.getValue() != o2.getValue()) {
          return o1.getValue() - o2.getValue();
        } else {
          return o2.getKey() - o1.getKey();
        }
      }
    ) {
      {
        addAll(hash.entrySet());
      }
    };
    var res = new int[nums.length];
    var i = 0;
    for (var entry : set) {
      for (var j = 0; j < entry.getValue(); j++) {
        res[i + j] = entry.getKey();
      }
      i += entry.getValue();
    }
    return res;
  }
}
// @lc code=end
