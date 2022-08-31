/*
 * @lc app=leetcode.cn id=448 lang=java
 *
 * [448] 找到所有数组中消失的数字
 */
import java.lang.Math;
import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {

  /**
   * 33/33 cases passed (6 ms)
   * Your runtime beats 40.15 % of java submissions
   * Your memory usage beats 85.1 % of java submissions (49.1 MB)
   * <p>
   * [4,3,2,7,8,2,3,1] 初始数据
   * </p>
   * <p>
   * [4,3,2,-7,8,2,3,1]
   * 第一个数据 4 出现，将数组的第四个也就是下标 3 的数据修改为负数 -7
   * 计算时，通过绝对值处理一下即可不影响数据的计算
   * </p>
   * <code>
   * [4,3,-2,-7,8,2,3,1]
   * [4,-3,-2,-7,8,2,3,1]
   * [4,-3,-2,-7,8,2,-3,1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [4,-3,-2,-7,8,2,-3,-1]
   * [-4,-3,-2,-7,8,2,-3,-1]
   * </code>
   * <p>
   * 计算结束，数组的第五个，第六个依然为整数，证明 5,6 没有出现
   * </p>
   * @param nums
   * @return
   */
  public List<Integer> findDisappearedNumbers(int[] nums) {
    for (int i = 0; i < nums.length; i++) {
      if (nums[Math.abs(nums[i]) - 1] > 0) {
        nums[Math.abs(nums[i]) - 1] = -nums[Math.abs(nums[i]) - 1];
      }
    }
    var res = new ArrayList<Integer>();
    for (int i = 0; i < nums.length; i++) {
      if (nums[i] > 0) {
        res.add(i + 1);
      }
    }
    return res;
  }
}
// @lc code=end
