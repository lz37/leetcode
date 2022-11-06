/*
 * @lc app=leetcode id=1582 lang=csharp
 *
 * [1582] Special Positions in a Binary Matrix
 */
namespace Leetcode.SpecialPositionsInABinaryMatrix;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 95/95 cases passed (192 ms)
    /// Your runtime beats 55 % of csharp submissions
    /// Your memory usage beats 80 % of csharp submissions (39.3 MB)
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public int NumSpecial(int[][] mat)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;
        var rowNumOf1 = new int[rows];
        var colNumOf1 = new int[cols];
        var res = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1)
                {
                    rowNumOf1[i]++;
                    colNumOf1[j]++;
                }
            }
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1 && rowNumOf1[i] == 1 && colNumOf1[j] == 1)
                {
                    res++;
                }
            }
        }
        return res;
    }
}
// @lc code=end
