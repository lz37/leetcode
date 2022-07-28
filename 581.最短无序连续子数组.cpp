/*
 * @lc app=leetcode.cn id=581 lang=cpp
 *
 * [581] 最短无序连续子数组
 */
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 307/307 cases passed (36 ms)
   * Your runtime beats 16.41 % of cpp submissions
   * Your memory usage beats 97.24 % of cpp submissions (25.7 MB)
   * @ref
   * https://leetcode.cn/problems/shortest-unsorted-continuous-subarray/comments/
   * @author chengeyouyou
   * @param nums
   * @return int
   */
  int findUnsortedSubarray(vector<int> &nums) {
    if (nums.size() < 2)
      return 0;
    int Max = INT_MIN;
    int Min = INT_MAX;
    int R = 0;
    int L = 0;
    for (int i = 0; i < nums.size(); i++) {
      if (Max > nums[i])
        R = i;
      Max = max(Max, nums[i]);
    }
    for (int i = nums.size() - 1; i >= 0; i--) {
      if (Min < nums[i])
        L = i;
      Min = min(Min, nums[i]);
    }
    return R == L ? 0 : R - L + 1;
  }
};
// @lc code=end

/**
 * 2   6   4   8   10  9   15
 * 4   4   8   9   9   15  Max
 * Min 2   6   6   8   10  10
 *
 *
 * 1   2   3   4
 * 2   3   4   Max
 * Min 1   2   3
 */