/*
 * @lc app=leetcode.cn id=416 lang=cpp
 *
 * [416] 分割等和子集
 */
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  bool canPartition(vector<int> &nums) {
    int sum = 0;
    for (auto num : nums)
      sum += num;
    if (sum / 2 != (sum + 1) / 2)
      return false;
    else {
      int target = sum / 2;
      vector<vector<int>> dp(nums.size(), vector<int>(nums.size(), 0));
      for (int i = nums.size() - 1; i >= 0; i--) {
        for (int j = i; j < nums.size(); j++) {
          if (j == i) {
            if (nums[i] <= target)
              dp[i][j] = nums[i];
          } else {
            for (int k = i; k < j; k++) {
              int tmp = max(dp[i][j], nums[j] + dp[i][k]);
              dp[i][j] = tmp > target ? dp[i][j] : tmp;
            }
            for (int k = nums.size() - 1 - i; k > j; k--) {
              int tmp = max(dp[i][j], nums[i] + dp[k][j]);
              dp[i][j] = tmp > target ? dp[i][j] : tmp;
            }
          }
          if (dp[i][j] == target)
            return true;
        }
      }
      return false;
    }
  }
  // 117/117 cases passed (124 ms)
  // Your runtime beats 82.51 % of cpp submissions
  // Your memory usage beats 36.1 % of cpp submissions (12.1 MB)
};
// @lc code=end