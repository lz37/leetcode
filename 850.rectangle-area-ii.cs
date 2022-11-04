/*
 * @lc app=leetcode id=850 lang=csharp
 *
 * [850] Rectangle Area II
 */
namespace Leetcode.RectangleAreaII;
// @lc code=start
public class Solution
{
    private const int Mod = 1000000007;
    /// <summary>
    /// 78/78 cases passed (84 ms)
    /// Your runtime beats 100 % of csharp submissions
    /// Your memory usage beats 100 % of csharp submissions (38.9 MB)
    /// <see href="https://leetcode.cn/problems/rectangle-area-ii/solution/ju-xing-mian-ji-ii-by-leetcode-solution-ulqz/"/>
    /// </summary>
    /// <param name="rectangles"></param>
    /// <returns></returns>
    public int RectangleArea(int[][] rectangles)
    {
        var n = rectangles.Length;
        // 去掉纵坐标重复
        var set = new HashSet<int>();
        foreach (var rect in rectangles)
        {
            // 下边界
            set.Add(rect[1]);
            // 上边界
            set.Add(rect[3]);
        }
        var hbound = new List<int>(set);
        hbound.Sort();
        // 「思路与算法部分」的 length 数组并不需要显式地存储下来
        // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        // seg[i]表示第 i 个线段被矩形覆盖的次数
        var seg = new int[hbound.Count - 1];
        var sweep = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            // 左边界
            sweep.Add(new int[] { rectangles[i][0], i, 1 });
            // 右边界
            sweep.Add(new int[] { rectangles[i][2], i, -1 });
        }
        sweep.Sort((a, b) =>
        {
            if (a[0] != b[0])
            {
                return a[0] - b[0];
            }
            else if (a[1] != b[1])
            {
                return a[1] - b[1];
            }
            else
            {
                return a[2] - b[2];
            }
        });
        var ans = 0L;
        for (var i = 0; i < sweep.Count; ++i)
        {
            // 一次性地处理掉一批横坐标相同的左右边界
            var j = i;
            while (j + 1 < sweep.Count && sweep[i][0] == sweep[j + 1][0])
            {
                ++j;
            }
            if (j + 1 == sweep.Count)
            {
                break;
            }
            for (var k = i; k <= j; ++k)
            {
                var arr = sweep[k];
                var idx = arr[1];
                var dif = arr[2];
                var btm = rectangles[idx][1];
                var hig = rectangles[idx][3];
                for (var x = 0; x < hbound.Count - 1; ++x)
                {
                    if (btm <= hbound[x] && hbound[x + 1] <= hig)
                    {
                        seg[x] += dif;
                    }
                }
            }
            var cover = 0;
            for (var k = 0; k < hbound.Count - 1; ++k)
            {
                if (seg[k] > 0)
                {
                    cover += hbound[k + 1] - hbound[k];
                }
            }
            ans += (long)cover * (sweep[j + 1][0] - sweep[j][0]);
            i = j;
        }
        return (int)(ans % Mod);
    }
}
// @lc code=end

