/*
 * @lc app=leetcode.cn id=739 lang=cpp
 *
 * [739] 每日温度
 */
#include <iostream>
#include <stack>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 47/47 cases passed (204 ms)
   * Your runtime beats 5.14 % of cpp submissions
   * Your memory usage beats 67.54 % of cpp submissions (86.7 MB)
   * @param temperatures
   * @return vector<int>
   */
  vector<int> dailyTemperatures(vector<int> &temperatures) {
    auto answer = vector<int>(temperatures.size(), 0);
    auto stack = std::stack<int>();
    stack.push(0);
    for (int i = 1; i < temperatures.size(); i++) {
      for (; !stack.empty() && temperatures[i] > temperatures[stack.top()];) {
        answer[stack.top()] = i - stack.top();
        stack.pop();
      }
      stack.push(i);
    }
    return answer;
  }
};
// @lc code=end
