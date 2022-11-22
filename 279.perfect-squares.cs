/*
 * @lc app=leetcode id=279 lang=csharp
 *
 * [279] Perfect Squares
 */
namespace Leetcode.PerfectSquares;
// @lc code=start
public class Solution
{
    private int getSquareNumLessThan(int n)
    {
        return (int)Math.Sqrt(n);
    }
    /// <summary>
    ///588/588 cases passed (64 ms)
    ///Your runtime beats 88.69 % of csharp submissions
    ///Your memory usage beats 34.39 % of csharp submissions (31 MB)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int NumSquares(int n)
    {
        var bfs = new Queue<int>();
        var res = 1;
        bfs.Enqueue(n);
        while (bfs.Count > 0)
        {
            var size = bfs.Count;
            for (int i = 0; i < size; i++)
            {
                var first = bfs.Dequeue();
                var maxSquareNum = getSquareNumLessThan(first);
                for (int j = maxSquareNum; j >= 1; j--)
                    if (first - j * j == 0)
                        return res;
                    else
                        bfs.Enqueue(first - j * j);
            }
            res++;
        }
        return n;
    }
}
// @lc code=end

