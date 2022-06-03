/*
 * @lc app=leetcode.cn id=494 lang=cpp
 *
 * [494] 目标和
 */
#include <vector>
using std::vector;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 139/139 cases passed (4 ms)
   * Your runtime beats 97.46 % of cpp submissions
   * Your memory usage beats 39.23 % of cpp submissions (9.1 MB)
   * sum(P) 前面符号为+的集合；sum(N) 前面符号为减号的集合
   * 所以题目可以转化为
   * sum(P) - sum(N) = target
   * => sum(nums) + sum(P) - sum(N) = target + sum(nums)
   * => 2 * sum(P) = target + sum(nums)
   * => sum(P) = (target + sum(nums)) / 2
   * 因此题目转化为01背包，也就是能组合成容量为sum(P)的方式有多少种
   * @param nums
   * @param target
   * @return int
   */
  int findTargetSumWays(vector<int> &nums, int target) {
    int sum = 0;
    for (auto num : nums)
      sum += num;
    if (sum < target || -sum > target || (sum + target) % 2 == 1)
      return 0;
    int w = (sum + target) / 2;
    vector<int> dp(w + 1, 0);
    dp[0] = 1;
    for (auto num : nums)
      for (int j = w; j >= num; j--)
        dp[j] += dp[j - num];
    return dp[w];
  }
};
// @lc code=end
class MySolution {
private:
  int hammingDistance(int x, int y) {
    int res = x % 2 != y % 2;
    for (int i = 0; i < 31; i++)
      res += (x >>= 1) % 2 != (y >>= 1) % 2;
    return res;
  }

public:
  /**
   * @brief
   * 超时
   * @param nums
   * @param target
   * @return int
   */
  int findTargetSumWays(vector<int> &nums, int target) {
    auto possibilities = 1;
    long long max = 0;
    for (auto num : nums) {
      max += num;
      possibilities <<= 1;
    }
    vector<long long> dp(possibilities);
    dp[possibilities - 1] = max;
    int count = max == target;
    for (int i = possibilities - 2; i >= 0; i--) {
      for (int j = i + 1; j < possibilities; j++) {
        if (hammingDistance(i, j) == 1) {
          auto sub = j - i, tmp = 0;
          while (sub > 0) {
            sub >>= 1;
            tmp += 1;
          }
          dp[i] = dp[j] - 2 * (nums[nums.size() - tmp]);
          count += dp[i] == target;
          break;
        }
      }
    }
    return count;
  }
};