/*
 * @lc app=leetcode.cn id=560 lang=cpp
 *
 * [560] 和为 K 的子数组
 */
#include <map>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 92/92 cases passed (120 ms)
   * Your runtime beats 5.86 % of cpp submissions
   * Your memory usage beats 22.15 % of cpp submissions (42.7 MB)
   * @ref
   * https://leetcode.cn/problems/subarray-sum-equals-k/solution/bao-li-jie-fa-qian-zhui-he-qian-zhui-he-you-hua-ja/
   * @param nums
   * @param k
   * @return int
   */
  int subarraySum(vector<int> &nums, int k) {
    map<int, int> preSumFreq;
    preSumFreq[0] = 1;
    int preSum = 0;
    int count = 0;
    for (auto num : nums) {
      preSum += num;
      if (preSumFreq.find(preSum - k) != preSumFreq.end())
        count += preSumFreq[preSum - k];
      preSumFreq[preSum] = preSumFreq[preSum] + 1;
    }
    return count;
  }
};
// @lc code=end
