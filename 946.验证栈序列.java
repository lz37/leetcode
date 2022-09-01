/*
 * @lc app=leetcode.cn id=946 lang=java
 *
 * [946] 验证栈序列
 */
import java.util.ArrayList;

// @lc code=start
class Solution {

  /**
   * 151/151 cases passed (2 ms)
   * Your runtime beats 57.83 % of java submissions
   * Your memory usage beats 71.84 % of java submissions (41 MB)
   * @param pushed
   * @param popped
   * @return
   */
  public boolean validateStackSequences(int[] pushed, int[] popped) {
    var pushedList = new ArrayList<Integer>() {
      {
        for (var p : pushed) {
          add(p);
        }
      }
    };
    var pushedPtr = 0;
    var poppedPtr = 0;
    for (;;) {
      if (pushedList.get(pushedPtr) == popped[poppedPtr]) {
        pushedList.remove(pushedPtr);
        pushedPtr = pushedPtr > 0 ? pushedPtr - 1 : 0;
        poppedPtr++;
      } else {
        pushedPtr++;
      }
      if (poppedPtr >= popped.length) {
        return pushedList.size() == 0;
      }
      if (pushedPtr >= pushedList.size()) {
        return false;
      }
    }
  }
}
// @lc code=end
