/*
 * @lc app=leetcode id=263 lang=csharp
 *
 * [263] Ugly Number
 */
namespace Leetcode.UglyNumber;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 1013/1013 cases passed (45 ms)
    /// Your runtime beats 82.54 % of csharp submissions
    /// Your memory usage beats 13.49 % of csharp submissions (28.3 MB)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsUgly(int n)
    {
        if (n == 0)
            return false;
        while (n % 2 == 0)
        {
            n /= 2;
        }
        while (n % 3 == 0)
        {
            n /= 3;
        }
        while (n % 5 == 0)
        {
            n /= 5;
        }
        if (n == 1)
            return true;
        return false;
    }
}
// @lc code=end

