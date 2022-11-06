/*
 * @lc app=leetcode id=899 lang=csharp
 *
 * [899] Orderly Queue
 */
using System.Text;

namespace Leetcode.OrderlyQueue;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 111/111 cases passed (128 ms)
    /// Your runtime beats 42.86 % of csharp submissions
    /// Your memory usage beats 14.29 % of csharp submissions (38.8 MB)
    /// <see href="https://leetcode.com/problems/orderly-queue/discuss/165878/C%2B%2BJavaPython-Sort-String-or-Rotate-String"/>
    /// 我是万万没想到啊，k >= 2 时任意的两个元素都可以交换，那就类似冒泡排序，
    /// 直接排序就可以了，原理如下：
    /// <br/>
    /// Assume that we want to swap S[i] and S[i+1], we can first pop
    /// first i-1 characters to the end, then pop i+1 and i, finally pop i+2~end.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public string OrderlyQueue(string s, int k)
    {
        if (k > 1)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        string res = s;
        for (int i = 1; i < s.Length; i++)
        {
            string tmp = string.Concat(s.AsSpan(i), s.AsSpan(0, i));
            if (res.CompareTo(tmp) > 0)
                res = tmp;
        }
        return res;
    }
}

// @lc code=end
public class MySolution
{
    private ISet<string> list = new SortedSet<string>();

    private void dfs(StringBuilder sb, int i, ref int k)
    {
        sb.Append(sb[i]);
        sb.Remove(i, 1);
        if (list.Contains(sb.ToString()))
        {
            return;
        }
        list.Add(sb.ToString());
        for (int j = 0; j < k; j++)
        {
            dfs(new StringBuilder(sb.ToString()), j, ref k);
        }
    }

    public string OrderlyQueue(string s, int k)
    {
        list.Add(s);
        for (int i = 0; i < k; i++)
        {
            dfs(new StringBuilder(s), i, ref k);
        }
        return list.First();
    }
}
