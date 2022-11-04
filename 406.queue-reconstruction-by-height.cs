/*
 * @lc app=leetcode id=406 lang=csharp
 *
 * [406] Queue Reconstruction by Height
 */
namespace Leetcode.QueueReconstructionByHeight;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 36/36 cases passed (297 ms)
    /// Your runtime beats 37.14 % of csharp submissions
    /// Your memory usage beats 40 % of csharp submissions (45.9 MB)
    /// </summary>
    /// <param name="people"></param>
    /// <returns></returns>
    public int[][] ReconstructQueue(int[][] people)
    {
        Array.Sort(people, (p1, p2) =>
        {
            if (p1[0] == p2[0])
            {
                // if height value is the same, then sort by k in raising powers
                return p1[1] - p2[1];
            }
            return p2[0] - p1[0]; // sort by height in descending powers
        });
        var res = new LinkedList<int[]>();
        foreach (var p in people)
        {
            // 模拟java的add方法
            if (res.Count == p[1])
            {
                res.AddLast(p);
            }
            else
            {
                var node = res.First;
                for (int i = 0; i < p[1]; i++)
                {
                    node = node.Next;
                }
                res.AddBefore(node, p);
            }
        }
        return res.ToArray();
    }
}
// @lc code=end


