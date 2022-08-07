/*
 * @lc app=leetcode.cn id=1408 lang=cpp
 *
 * [1408] 数组中的字符串匹配
 */
#include <string>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 就这？
   * 67/67 cases passed (4 ms)
   * Your runtime beats 83.28 % of cpp submissions
   * Your memory usage beats 85.87 % of cpp submissions (8 MB)
   * @param words
   * @return vector<string>
   */
  vector<string> stringMatching(vector<string> &words) {
    auto ans = vector<string>();
    for (int i = 0; i < words.size(); i++) {
      for (int j = 0; j < words.size(); j++) {
        if (i == j)
          continue;
        if (words[i].length() > words[j].length())
          continue;
        if (words[j].find(words[i]) != string::npos) {
          ans.push_back(words[i]);
          break;
        }
      }
    }
    return ans;
  }
};
// @lc code=end
