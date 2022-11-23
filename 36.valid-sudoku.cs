/*
 * @lc app=leetcode id=36 lang=csharp
 *
 * [36] Valid Sudoku
 */
namespace Leetcode.ValidSudoku;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 507/507 cases passed (198 ms)
    /// Your runtime beats 37.95 % of csharp submissions
    /// Your memory usage beats 34.71 % of csharp submissions (41.9 MB)
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudoku(char[][] board)
    {
        var seen = new HashSet<string>();
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
            {
                char number = board[i][j];
                if (number != '.')
                    if (!seen.Add($"{number} in row {i}") ||
                        !seen.Add($"{number} in column {j}") ||
                        !seen.Add($"{number} in block {i / 3}-{j / 3}"))
                        return false;
            }
        }
        return true;
    }
}
// @lc code=end

