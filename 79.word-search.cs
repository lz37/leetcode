/*
 * @lc app=leetcode id=79 lang=csharp
 *
 * [79] Word Search
 */
namespace Leetcode.WordSearch;
// @lc code=start
public class Solution
{
    private static readonly int[][] direct = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
    private string word;
    private bool bfs(char[][] board, int x, int y, int index)
    {
        if (index == word.Length - 1)
        {
            return true;
        }
        var ch = board[x][y];
        board[x][y] = ' ';
        index++;
        for (int i = 0; i < direct.Length; i++)
        {
            var newX = x + direct[i][0];
            var newY = y + direct[i][1];
            if (newX < 0 || newY < 0 || newX >= board.Length || newY >= board[0].Length)
                continue;
            if (board[newX][newY] == word[index])
            {
                if (bfs(board, newX, newY, index))
                {
                    return true;
                }
            }
        }
        board[x][y] = ch;
        return false;
    }
    /// <summary>
    /// 84/84 cases passed (310 ms)
    /// Your runtime beats 85.78 % of csharp submissions
    /// Your memory usage beats 98.22 % of csharp submissions (39.2 MB)
    /// </summary>
    /// <param name="board"></param>
    /// <param name="word"></param>
    /// <returns></returns>
    public bool Exist(char[][] board, string word)
    {
        this.word = word;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (bfs(board, i, j, 0))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
// @lc code=end

