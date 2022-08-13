/*
 * @lc app=leetcode.cn id=636 lang=cpp
 *
 * [636] 函数的独占时间
 */
#include <iostream>
#include <sstream>
#include <stack>
#include <string>
#include <tuple>
#include <utility>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 120/120 cases passed (16 ms)
   * Your runtime beats 75.65 % of cpp submissions
   * Your memory usage beats 48.75 % of cpp submissions (12.9 MB)
   * 原理一样，他这个处理使用的工具更快
   * @param n
   * @param logs
   * @return vector<int>
   */
  vector<int> exclusiveTime(int n, vector<string> &logs) {
    stack<pair<int, int>> st; // {idx, 开始运行的时间}
    vector<int> res(n, 0);
    for (auto &log : logs) {
      char type[10];
      int idx, timestamp;
      sscanf(log.c_str(), "%d:%[^:]:%d", &idx, type, &timestamp);
      if (type[0] == 's') {
        if (!st.empty()) {
          res[st.top().first] += timestamp - st.top().second;
          st.top().second = timestamp;
        }
        st.emplace(idx, timestamp);
      } else {
        auto t = st.top();
        st.pop();
        res[t.first] += timestamp - t.second + 1;
        if (!st.empty()) {
          st.top().second = timestamp + 1;
        }
      }
    }
    return res;
  }
};
// @lc code=end
class MySolution {
private:
  vector<string> split(const string &s, char delim) {
    vector<string> result;
    stringstream ss(s);
    string item;
    while (getline(ss, item, delim)) {
      result.push_back(item);
    }
    return result;
  }
  inline tuple<int, bool, int> logHandler(string log) {
    auto strs = split(log, ':');
    return {stoi(strs[0]), strs[1] == "start", stoi(strs[2])};
  }

public:
  /**
   * @brief
   * 120/120 cases passed (56 ms)
   * Your runtime beats 5.67 % of cpp submissions
   * Your memory usage beats 5.55 % of cpp submissions (21.3 MB)
   * @param n
   * @param logs
   * @return vector<int>
   */
  vector<int> exclusiveTime(int n, vector<string> &logs) {
    vector<int> ans(n, 0);
    stack<pair<int, int>> stk;
    for (auto log : logs) {
      auto [functionId, isStart, time] = logHandler(log);
      if (stk.empty()) {
        stk.push({functionId, time});
        continue;
      }
      auto [fId, T] = stk.top();
      if (isStart) {
        ans[fId] += time - T;
        stk.push({functionId, time});
      } else {
        ans[functionId] += time - T + 1;
        stk.pop();
        if (!stk.empty()) {
          stk.top().second = time + 1;
        }
      }
    }
    return ans;
  }
};