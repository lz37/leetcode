/*
 * @lc app=leetcode.cn id=448 lang=cpp
 *
 * [448] 找到所有数组中消失的数字
 */
#include <cmath>
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
  /**
   * @brief
   * 33/33 cases passed (36 ms)
   * Your runtime beats 93.98 % of cpp submissions
   * Your memory usage beats 67.52 % of cpp submissions (32.8 MB)
   * 举例
   * [4,3,2,7,8,2,3,1] 初始数据
   * [4,3,2,-7,8,2,3,1]
   * 第一个数据 4 出现，将数组的第四个也就是下标 3 的数据修改为负数 -7
   * 计算时，通过绝对值处理一下即可不影响数据的计算
   * [4,3,-2,-7,8,2,3,1]
   * [4,-3,-2,-7,8,2,3,1]
   * [4,-3,-2,-7,8,2,-3,1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [-4,-3,-2,-7,8,2,-3,-1]
   * 计算结束，数组的第五个，第六个依然为整数，证明 5,6 没有出现
   * @param nums
   * @return vector<int>
   */
  vector<int> findDisappearedNumbers(vector<int> &nums) {
    for (int i = 0; i < nums.size(); i++)
      if (nums[abs(nums[i]) - 1] > 0)
        nums[abs(nums[i]) - 1] = -nums[abs(nums[i]) - 1];
    vector<int> res;
    for (int i = 0; i < nums.size(); i++)
      if (nums[i] > 0)
        res.push_back(i + 1);
    return res;
  }
};
// @lc code=end
class MySolution {
public:
  /**
   * @brief
   * 33/33 cases passed (32 ms)
   * Your runtime beats 98.31 % of cpp submissions
   * Your memory usage beats 49.53 % of cpp submissions (32.9 MB)
   * @param nums
   * @return vector<int>
   */
  vector<int> findDisappearedNumbers(vector<int> &nums) {
    vector<bool> hash(nums.size() + 1, 0);
    for (auto num : nums)
      hash[num] = 1;
    vector<int> res;
    for (int i = 1; i <= nums.size(); i++)
      if (!hash[i])
        res.push_back(i);
    return res;
  }
};