/*
 * @lc app=leetcode.cn id=1592 lang=java
 *
 * [1592] 重新排列单词间的空格
 */
import java.util.ArrayList;
import java.util.function.Function;

// @lc code=start
class Solution {

  /**
   * 89/89 cases passed (2 ms)
   * Your runtime beats 38.41 % of java submissions
   * Your memory usage beats 91.43 % of java submissions (39.3 MB)
   * @param text
   * @return
   */
  public String reorderSpaces(String text) {
    var beginAndEnd = new ArrayList<int[]>();
    var spacesNum = 0;
    var start = 0;
    for (int i = 0; i < text.length(); i++) {
      if (text.charAt(i) == ' ') {
        spacesNum++;
        if (i != 0 && text.charAt(i - 1) != ' ') {
          beginAndEnd.add(new int[] { start, i });
        }
      }
      if (text.charAt(i) != ' ' && (i == 0 || text.charAt(i - 1) == ' ')) {
        start = i;
      }
    }
    if (!text.endsWith(" ")) {
      beginAndEnd.add(new int[] { start, text.length() });
    }
    var wordsNum = beginAndEnd.size();
    Function<Integer, String> makeSpaces = num -> {
      var res = "";
      for (int i = 0; i < num; i++) {
        res += " ";
      }
      return res;
    };
    if (wordsNum == 1) {
      var word = beginAndEnd.get(0);
      return (
        text.substring(word[0], word[1]) +
        makeSpaces.apply(text.length() - (word[1] - word[0]))
      );
    }
    var gapSpaces = makeSpaces.apply(spacesNum / (wordsNum - 1));
    var lastSpaces = makeSpaces.apply(
      spacesNum - gapSpaces.length() * (wordsNum - 1)
    );
    var res = "";
    for (var i = 0; i < wordsNum; i++) {
      var bAndE = beginAndEnd.get(i);
      res += text.substring(bAndE[0], bAndE[1]);
      if (i == wordsNum - 1) {
        res += lastSpaces;
      } else {
        res += gapSpaces;
      }
    }
    return res;
  }
}
// @lc code=end
