/*
 * @lc app=leetcode.cn id=621 lang=cpp
 *
 * [621] 任务调度器
 */
#include <iostream>
#include <map>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
private:
  inline char findMostChar(map<char, int> &hash) {
    auto mostChar = 'A';
    for (auto i = 'A'; i <= 'Z'; i++) {
      if (hash[i] > hash[mostChar]) {
        mostChar = i;
      }
    }
    return mostChar;
  }

public:
  /**
   * @brief
   * 71/71 cases passed (52 ms)
   * Your runtime beats 75.87 % of cpp submissions
   * Your memory usage beats 10.03 % of cpp submissions (33.7 MB)
   * @param tasks
   * @param n
   * @return int
   */
  int leastInterval(vector<char> &tasks, int n) {
    map<char, int> hash;
    for (auto task : tasks) {
      hash[task]++;
    }
    char mostChar;
    int length = 0, mostTasks = 0;
    for (; hash[mostChar = findMostChar(hash)];) {
      if (!mostTasks) {
        mostTasks = hash[mostChar];
        length = hash[mostChar] * (n + 1) - n;
      } else {
        if (hash[mostChar] == mostTasks) {
          length++;
        }
      }
      hash[mostChar] = 0;
    }
    return max(length, (int)tasks.size());
  }
};
// @lc code=end