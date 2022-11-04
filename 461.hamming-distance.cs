/*
 * @lc app=leetcode id=461 lang=csharp
 *
 * [461] Hamming Distance
 */
namespace Leetcode.HammingDistance;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 149/149 cases passed (47 ms)
    /// Your runtime beats 24.87 % of csharp submissions
    /// Your memory usage beats 94.42 % of csharp submissions (24.9 MB)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int HammingDistance(int x, int y)
    {
        int res = x % 2 != y % 2 ? 1 : 0;
        for (int i = 0; i < 31; i++)
        {
            res += (x >>= 1) % 2 != (y >>= 1) % 2 ? 1 : 0;
        }
        return res;
    }
}
// @lc code=end

