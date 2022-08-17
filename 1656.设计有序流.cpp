/*
 * @lc app=leetcode.cn id=1656 lang=cpp
 *
 * [1656] 设计有序流
 */
#include <iostream>
#include <string>
#include <vector>
using namespace std;
// @lc code=start
/**
 * @brief
 * 101/101 cases passed (68 ms)
 * Your runtime beats 100 % of cpp submissions
 * Your memory usage beats 48.34 % of cpp submissions (81.7 MB)
 */
class OrderedStream {
private:
  int num;
  int ptr = 0;
  vector<string> container;

public:
  OrderedStream(int n) {
    this->num = n;
    vector<string>(n).swap(container);
  }

  vector<string> insert(int idKey, string value) {
    idKey--;
    container[idKey] = value;
    if (ptr == idKey) {
      vector<string> ans;
      for (; ptr < this->num && !container[ptr].empty();) {
        ans.push_back(container[ptr]);
        ptr++;
      }
      return ans;
    } else {
      return {};
    }
  }
};

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream* obj = new OrderedStream(n);
 * vector<string> param_1 = obj->insert(idKey,value);
 */
// @lc code=end