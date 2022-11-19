/*
 * @lc app=leetcode id=587 lang=csharp
 *
 * [587] Erect the Fence
 */
namespace Leetcode.ErectTheFence;
// @lc code=start
public class Solution
{
    private int cmp(int[] p1, int[] p2, int[] p3)
    {
        return (p3[1] - p2[1]) * (p2[0] - p1[0]) - (p2[1] - p1[1]) * (p3[0] - p2[0]);
    }
    /// <summary>
    /// 88/88 cases passed (233 ms)
    /// Your runtime beats 100 % of csharp submissions
    /// Your memory usage beats 100 % of csharp submissions (45.3 MB)
    /// <see href="https://leetcode.com/problems/erect-the-fence/discuss/1442266/A-Detailed-Explanation-with-Diagrams-(Graham-Scan)"/>
    /// </summary>
    /// <param name="trees"></param>
    /// <returns></returns>
    public int[][] OuterTrees(int[][] trees)
    {
        if (trees.Length <= 3) return trees;
        Array.Sort(trees, (a, b) =>
        {
            if (a[0] == b[0])
                return a[1] - b[1];
            else
                return a[0] - b[0];
        });
        var lower = new List<int[]>(); //下半部分
        var upper = new List<int[]>(); // 上半部分
        foreach (var tree in trees)
        {
            // 检查大于180的角
            while (lower.Count >= 2 && cmp(lower[^2], lower[^1], tree) < 0)
                lower.RemoveAt(lower.Count - 1);
            while (upper.Count >= 2 && cmp(upper[^2], upper[^1], tree) > 0)
                upper.RemoveAt(upper.Count - 1);
            lower.Add(tree);
            upper.Add(tree);
        }
        var set = new HashSet<int[]>(lower.Concat(upper));
        return set.ToArray();
    }
}
// @lc code=end

