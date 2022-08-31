/*
 * @lc app=leetcode.cn id=739 lang=java
 *
 * [739] 每日温度
 */
import java.util.Stack;

// @lc code=start
class Solution {

  /**
   * 47/47 cases passed (120 ms)
   * Your runtime beats 54.87 % of java submissions
   * Your memory usage beats 60.76 % of java submissions (53.1 MB)
   * @param temperatures
   * @return
   */
  public int[] dailyTemperatures(int[] temperatures) {
    var ans = new int[temperatures.length];
    var stack = new Stack<Integer>();
    stack.push(0);
    for (int i = 0; i < temperatures.length; i++) {
      for (
        ;
        !stack.empty() && temperatures[i] > temperatures[stack.lastElement()];
      ) {
        ans[stack.lastElement()] = i - stack.pop();
      }
      stack.push(i);
    }
    return ans;
  }
}
// @lc code=end
