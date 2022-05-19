/*
 * @lc app=leetcode.cn id=406 lang=cpp
 *
 * [406] 根据身高重建队列
 */
#include <algorithm>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
  static bool cmp(vector<int> &a, vector<int> &b) {
    if (a[0] == b[0]) {
      // if height value is the same, then sort by k in raising powers
      return a[1] < b[1];
    } else {
      return a[0] > b[0]; // sort by height in descending powers
    }
  }

public:
  vector<vector<int>> reconstructQueue(vector<vector<int>> &people) {
    sort(people.begin(), people.end(), cmp);
    // after sort the example we get this vector:
    // [[7,0],[7,1],[6,1],[5,0],[5,2],[4,4]]
    vector<vector<int>> res;
    for (auto x : people) {
      // insert the biggest height people first and insert in the k-th position
      res.insert(res.begin() + x[1], x); // insert method: (position, value)
    }
    return res;
  }
  // 36/36 cases passed (148 ms)
  // Your runtime beats 34.16 % of cpp submissions
  // Your memory usage beats 41.15 % of cpp submissions (12.3 MB)
};
// @lc code=end
class MySolution {
private:
  void forward(int pos, vector<vector<int>> &people, vector<int> &biggers) {
    biggers[pos - 1] += people[pos - 1][0] <= people[pos][0];
    biggers[pos] -= people[pos - 1][0] >= people[pos][0];
    swap(biggers[pos], biggers[pos - 1]);
    swap(people[pos], people[pos - 1]);
  }
  void backward(int pos, vector<vector<int>> &people, vector<int> &biggers) {
    biggers[pos] += people[pos + 1][0] >= people[pos][0];
    biggers[pos + 1] -= people[pos + 1][0] <= people[pos][0];
    swap(biggers[pos], biggers[pos + 1]);
    swap(people[pos], people[pos + 1]);
  }

public:
  vector<vector<int>> reconstructQueue(vector<vector<int>> &people) {
    vector<int> biggers(people.size());
    for (int i = 0; i < people.size(); i++) {
      int bigger = 0;
      for (int j = i - 1; j >= 0; j--) {
        bigger += people[j][0] >= people[i][0];
      }
      biggers[i] = bigger;
    }
    bool correct = 0;
    while (!correct) {
      correct = 1;
      for (int i = 1; i < people.size(); i++)
        if (biggers[i] > people[i][1]) {
          correct = 0;
          forward(i, people, biggers);
        }
      for (int i = people.size() - 2; i >= 0; i--)
        if (biggers[i] < people[i][1]) {
          correct = 0;
          backward(i, people, biggers);
        }
    }
    return people;
  }
  // 36/36 cases passed (528 ms)
  // Your runtime beats 5.11 % of cpp submissions
  // Your memory usage beats 89.94 % of cpp submissions (11.5 MB)
};