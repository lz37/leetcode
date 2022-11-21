/*
 * @lc app=leetcode id=1926 lang=csharp
 *
 * [1926] Nearest Exit from Entrance in Maze
 */
namespace Leetcode.NearestExitFromEntranceInMaze;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 194/194 cases passed (420 ms)
    /// Your runtime beats 62.3 % of csharp submissions
    /// Your memory usage beats 86.89 % of csharp submissions (40.5 MB)
    /// </summary>
    /// <value></value>
    private static readonly int[][] direct = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
    public int NearestExit(char[][] maze, int[] entrance)
    {
        var rows = maze.Length;
        var cols = maze[0].Length;
        var bfs = new Queue<int[]>();
        var res = 1;
        bfs.Enqueue(entrance);
        maze[entrance[0]][entrance[1]] = '+';
        while (bfs.Count > 0)
        {
            var size = bfs.Count;
            for (int i = 0; i < size; i++)
            {
                var item = bfs.Dequeue();
                for (int j = 0; j < 4; j++)
                {
                    var newX = item[0] + direct[j][0];
                    var newY = item[1] + direct[j][1];
                    if (newX < 0 || newY < 0 || newX >= rows || newY >= cols || maze[newX][newY] == '+')
                        continue;
                    else if (newX == 0 || newX == rows - 1 || newY == 0 || newY == cols - 1)
                        return res;
                    else
                    {
                        bfs.Enqueue(new int[] { newX, newY });
                        maze[newX][newY] = '+';
                    }
                }
            }
            res++;
        }
        return -1;
    }
}
// @lc code=end

/*
[["+","+","+"],[".",".","."],["+","+","+"]]\n[1,0]
[[".","+"]]\n[0,0]
[["+",".","+","+","+","+","+"],["+",".","+",".",".",".","+"],["+",".","+",".","+",".","+"],["+",".",".",".","+",".","+"],["+","+","+","+","+",".","+"]]\n[3,2]

+ . + + + + +
+ . + . . . +
+ . + . + . +
+ . . . + . +
+ + + + + . +
*/