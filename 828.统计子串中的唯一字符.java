/*
 * @lc app=leetcode.cn id=828 lang=java
 *
 * [828] 统计子串中的唯一字符
 */
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

// @lc code=start
class Solution {

  /**
   * 76/76 cases passed (46 ms)
   * Your runtime beats 45.36 % of java submissions
   * Your memory usage beats 19.65 % of java submissions (49.2 MB)
   * <p>
   * {@link https://leetcode.cn/problems/count-unique-characters-of-all-substrings-of-a-given-string/solution/tong-ji-zi-chuan-zhong-de-wei-yi-zi-fu-b-h9pj/}
   * </p>
   * <p>
   * 对于下标为 i 的字符 c<sub>i</sub>，当它在某个子字符串中仅出现一次时，它会对这个子字符串统计唯一字符时有贡献。只需对每个字符，计算有多少子字符串仅包含该字符一次即可。对于 c<sub>i</sub> ， 记同字符上一次出现的位置为 c<sub>j</sub> ，下一次出现的位置为 c<sub>k</sub> ，那么这样的子字符串就一共有 (c<sub>i</sub> - c<sub>j</sub>) × (c<sub>k</sub> - c<sub>i</sub>)(c<sub>i</sub> −c<sub>j</sub> )×(c<sub>k</sub> −c<sub>i</sub> ) 种，即子字符串的起始位置有 c<sub>j</sub> （不含）到 c<sub>i</sub> （含）之间这 (c<sub>i</sub> - c<sub>j</sub>)(c<sub>i</sub> −c<sub>j</sub> ) 种可能，到结束位置有 (c<sub>k</sub> - c<sub>i</sub>)(c<sub>k</sub> −c<sub>i</sub> ) 种可能。可以预处理 s，将相同字符的下标放入数组中，方便计算。最后对所有字符进行这种计算即可。
   * </p>
   * @param s
   * @return
   */
  public int uniqueLetterString(String s) {
    var index = new HashMap<Character, List<Integer>>();
    for (var i = 0; i < s.length(); i++) {
      var c = s.charAt(i);
      if (!index.containsKey(c)) {
        index.put(c, new ArrayList<Integer>());
        index.get(c).add(-1);
      }
      index.get(c).add(i);
    }
    int res = 0;
    for (var entry : index.entrySet()) {
      var arr = entry.getValue();
      arr.add(s.length());
      for (var i = 1; i < arr.size() - 1; i++) {
        res += (arr.get(i) - arr.get(i - 1)) * (arr.get(i + 1) - arr.get(i));
      }
    }
    return res;
  }
}

// @lc code=end
class MySolution {

  /**
   * 76/76 cases passed (1864 ms)
   * Your runtime beats 5.36 % of java submissions
   * Your memory usage beats 52.86 % of java submissions (42.3 MB)
   * @param s
   * @return
   */
  public int uniqueLetterString(String s) {
    var res = 0;
    for (var i = 0; i < s.length(); i++) {
      var hash = new int[26];
      var unique = 1;
      var ge2 = 0;
      hash[s.charAt(i) - 'A'] += unique;
      res++;
      for (var j = i + 1; j < s.length(); j++) {
        if (ge2 == 26) {
          break;
        }
        var h = hash[s.charAt(j) - 'A']++;
        switch (h) {
          case 0:
            unique++;
            res += unique;
            break;
          case 1:
            unique--;
            ge2++;
            res += unique;
            break;
          default:
            res += unique;
            break;
        }
      }
    }
    return res;
  }
}
