/*
 * @lc app=leetcode.cn id=1656 lang=java
 *
 * [1656] 设计有序流
 */
import java.util.ArrayList;
import java.util.List;

// @lc code=start
/**
 * 101/101 cases passed (74 ms)
 * Your runtime beats 57.68 % of java submissions
 * Your memory usage beats 28.42 % of java submissions (42.9 MB)
 */
class OrderedStream {

  private int num;
  private int ptr = 0;
  private List<String> container;

  public OrderedStream(int n) {
    this.num = n;
    this.container = new ArrayList<>();
    for (; n-- > 0;) {
      container.add("");
    }
  }

  public List<String> insert(int idKey, String value) {
    idKey--;
    container.set(idKey, value);
    if (ptr == idKey) {
      var ans = new ArrayList<String>();
      for (; ptr < this.num && !container.get(ptr).isEmpty();) {
        ans.add(container.get(ptr));
        ptr++;
      }
      return ans;
    } else {
      return new ArrayList<String>();
    }
  }
}
/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * List<String> param_1 = obj.insert(idKey,value);
 */
// @lc code=end
