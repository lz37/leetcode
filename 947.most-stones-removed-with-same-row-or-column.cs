/*
 * @lc app=leetcode id=947 lang=csharp
 *
 * [947] Most Stones Removed with Same Row or Column
 */
namespace Leetcode.MostStonesRemovedWithSameRowOrColumn;
/*
并查集在底层实现可以是数组，也可以是散列表，不管使用什么底层实现，关键在于能表示一个对应关系，即：key 或下标表示了节点本身，而 value 表示顶点的父亲节点，初始化时指向自己。

并查集两个基本操作：合并 & 查询

合并操作 合并操作就是将一个节点的的父节点指向另一个的根节点
查询操作 查询操作就是查询节点的根节点，如果两个节点的根节点相同，那么表示在一个集合中（相连）。
*/
// @lc code=start
public class Solution
{
    private IDictionary<int, int> f = new Dictionary<int, int>();
    // 剩下的数量
    private int islands = 0;

    /// <summary>
    /// 68/68 cases passed (223 ms)
    /// Your runtime beats 56.98 % of csharp submissions
    /// Your memory usage beats 89.53 % of csharp submissions (39.7 MB)
    /// <see href="https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/discuss/197668/Count-the-Number-of-Islands-O(N)"/>
    /// </summary>
    /// <param name="stones"></param>
    /// <returns></returns>
    public int RemoveStones(int[][] stones)
    {
        for (int i = 0; i < stones.Length; ++i)
            // stones[i][1] 按位取反，
            // 目的是为了不和stones[i][0]有交集，
            // 实际上10000+stones[i][1]也行
            union(stones[i][0], ~stones[i][1]);
        // 只要知道剩下的单独单元的个数，就能算出操作的次数
        return stones.Length - islands;
    }

    private int find(int x)
    {
        // 若不存在则让f[x]=x，表示新增一（行，列）
        if (!f.ContainsKey(x) && (f[x] = x) == x)
            islands++;
        // 一直找 找到根父节点
        if (x != f[x])
            f[x] = find(f[x]);
        return f[x];
    }

    private void union(int x, int y)
    {
        x = find(x);
        y = find(y);
        if (x != y)
        {
            f[x] = y;
            // X!=Y时表示在这一步前不连通，也就是之前没有搜到这个点（搜到的都联通了）
            // 那么上面的find x find y 就多了一个islands，于是减去
            // 到最后所有应该连通的不连通坐标都连通（因为把stones遍历了一遍）了，剩下的island就是最后剩余的孤立点
            islands--;
        }
    }
}
// @lc code=end
