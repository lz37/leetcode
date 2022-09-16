/*
 * @lc app=leetcode.cn id=850 lang=java
 *
 * [850] 矩形面积 II
 */
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;

// @lc code=start
class Solution {

  private final int MOD = 1000000007;

  /**
   * <p>
   * 78/78 cases passed (11 ms)
   * Your runtime beats 19.74 % of java submissions
   * Your memory usage beats 95.39 % of java submissions (40.6 MB)
   * </p>
   * {@link https://leetcode.cn/problems/rectangle-area-ii/solution/ju-xing-mian-ji-ii-by-leetcode-solution-ulqz/}
   * @param rectangles
   * @return
   */
  public int rectangleArea(int[][] rectangles) {
    var n = rectangles.length;
    // 去掉纵坐标重复
    var set = new HashSet<Integer>();
    for (int[] rect : rectangles) {
      // 下边界
      set.add(rect[1]);
      // 上边界
      set.add(rect[3]);
    }
    var hbound = new ArrayList<Integer>(set);
    Collections.sort(hbound);
    // 「思路与算法部分」的 length 数组并不需要显式地存储下来
    // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
    // seg[i]表示第 i 个线段被矩形覆盖的次数
    var seg = new int[hbound.size() - 1];

    var sweep = new ArrayList<int[]>();
    for (var i = 0; i < n; ++i) {
      // 左边界
      sweep.add(new int[] { rectangles[i][0], i, 1 });
      // 右边界
      sweep.add(new int[] { rectangles[i][2], i, -1 });
    }
    Collections.sort(
      sweep,
      (a, b) -> {
        if (a[0] != b[0]) {
          return a[0] - b[0];
        } else if (a[1] != b[1]) {
          return a[1] - b[1];
        } else {
          return a[2] - b[2];
        }
      }
    );

    var ans = 0L;
    for (var i = 0; i < sweep.size(); ++i) {
      // 一次性地处理掉一批横坐标相同的左右边界
      var j = i;
      while (j + 1 < sweep.size() && sweep.get(i)[0] == sweep.get(j + 1)[0]) {
        ++j;
      }
      if (j + 1 == sweep.size()) {
        break;
      }
      for (var k = i; k <= j; ++k) {
        var arr = sweep.get(k);
        var idx = arr[1];
        var dif = arr[2];
        var btm = rectangles[idx][1];
        var hig = rectangles[idx][3];
        for (var x = 0; x < hbound.size() - 1; ++x) {
          if (btm <= hbound.get(x) && hbound.get(x + 1) <= hig) {
            seg[x] += dif;
          }
        }
      }
      var cover = 0;
      for (var k = 0; k < hbound.size() - 1; ++k) {
        if (seg[k] > 0) {
          cover += (hbound.get(k + 1) - hbound.get(k));
        }
      }
      ans += (long) cover * (sweep.get(j + 1)[0] - sweep.get(j)[0]);
      i = j;
    }
    return (int) (ans % MOD);
  }
}
// @lc code=end
