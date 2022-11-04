/*
 * @lc app=leetcode id=1656 lang=csharp
 *
 * [1656] Design an Ordered Stream
 */
namespace Leetcode.DesignAnOrderedStream;
// @lc code=start
/// <summary>
/// 101/101 cases passed (631 ms)
/// Your runtime beats 49.18 % of csharp submissions
/// Your memory usage beats 44.26 % of csharp submissions (50.4 MB)
/// </summary>
public class OrderedStream
{
    #region private
    private int num;
    private int ptr = 0;
    private IList<string> container;
    #endregion

    public OrderedStream(int n)
    {
        num = n;
        container = new List<string>();
        while (n-- > 0)
        {
            container.Add("");
        }
    }

    public IList<string> Insert(int idKey, string value)
    {
        idKey--;
        container[idKey] = value;
        if (ptr == idKey)
        {
            var ans = new List<string>();
            while (ptr < num && container[ptr].Length != 0)
            {
                ans.Add(container[ptr]);
                ptr++;
            }
            return ans;
        }
        else
        {
            return new List<string>();
        }
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(idKey,value);
 */
// @lc code=end

