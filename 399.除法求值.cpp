/*
 * @lc app=leetcode.cn id=399 lang=cpp
 *
 * [399] 除法求值
 */
#include <iostream>
#include <map>
#include <set>
#include <string>
#include <utility>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
private:
  map<string, map<string, double>> graph;
  double findTarget(string start, string target, set<string> visited) {
    if (start == target)
      return 1.0;
    for (auto entry : graph[start]) {
      if (visited.find(entry.first) != visited.end())
        continue;
      visited.insert(entry.first);
      double tmp = findTarget(entry.first, target, visited);
      if (tmp != -1.0)
        return tmp * entry.second;
    }
    return -1.0;
  }

public:
  /**
   * @brief
   * 24/24 cases passed (4 ms)
   * Your runtime beats 46.42 % of cpp submissions
   * Your memory usage beats 5.07 % of cpp submissions (8.6 MB)
   * @param equations
   * @param values
   * @param queries
   * @return vector<double>
   */
  vector<double> calcEquation(vector<vector<string>> &equations,
                              vector<double> &values,
                              vector<vector<string>> &queries) {
    vector<double> ans(queries.size(), -1.0);
    for (int i = 0; i < equations.size(); i++) {
      graph[equations[i][0]][equations[i][1]] = values[i];
      graph[equations[i][1]][equations[i][0]] = 1 / values[i];
    }
    for (int i = 0; i < queries.size(); i++) {
      if (graph.find(queries[i][0]) != graph.end() &&
          graph.find(queries[i][1]) != graph.end()) {
        ans[i] = findTarget(queries[i][0], queries[i][1], set<string>());
      }
    }
    return ans;
  }
};
// @lc code=end