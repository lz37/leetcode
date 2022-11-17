/*
 * @lc app=leetcode id=223 lang=csharp
 *
 * [223] Rectangle Area
 */
namespace Leetcode.RectangleArea;
// @lc code=start
public class Solution
{
    private int getRectangleArea(int x1, int y1, int x2, int y2)
    {
        return (y2 - y1) * (x2 - x1);
    }

    /// <summary>
    /// 3080/3080 cases passed (20 ms)
    /// Your runtime beats 98.25 % of csharp submissions
    /// Your memory usage beats 21.05 % of csharp submissions (28.1 MB)
    /// </summary>
    /// <param name="ax1"></param>
    /// <param name="ay1"></param>
    /// <param name="ax2"></param>
    /// <param name="ay2"></param>
    /// <param name="bx1"></param>
    /// <param name="by1"></param>
    /// <param name="bx2"></param>
    /// <param name="by2"></param>
    /// <returns></returns>
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        var aS = getRectangleArea(ax1, ay1, ax2, ay2);
        var bS = getRectangleArea(bx1, by1, bx2, by2);
        if (ax2 <= bx1 || ax1 >= bx2 || ay1 >= by2 || ay2 <= by1)
        {
            return aS + bS;
        }
        return aS + bS - getRectangleArea(Math.Max(ax1, bx1), Math.Max(ay1, by1), Math.Min(ax2, bx2), Math.Min(ay2, by2));
    }
}
// @lc code=end

