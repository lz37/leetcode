/*
 * @lc app=leetcode id=901 lang=csharp
 *
 * [901] Online Stock Span
 */
namespace Leetcode.OnlineStockSpan;

// @lc code=start
/// <summary>
/// 99/99 cases passed (637 ms)
/// Your runtime beats 77.78 % of csharp submissions
/// Your memory usage beats 53.7 % of csharp submissions (66.5 MB)
/// </summary>
public class StockSpanner
{
    private Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();

    public StockSpanner() { }

    /// <summary>
    /// 对于[100,80,60,70,60,75,85]，stack 变化为
    /// <code>
    /// 100 1
    ///
    /// 100 1 | 80 1
    ///
    /// 100 1 | 80 1 | 60 1
    ///
    /// 100 1 | 80 1 | 70 2
    ///
    /// 100 1 | 80 1 | 70 2 | 60 1
    ///
    /// 100 1 | 80 1 | 75 4
    ///
    /// 100 1 | 85 6
    ///
    /// </code>
    /// <see href="https://leetcode.com/problems/online-stock-span/discuss/168311/C%2B%2BJavaPython-O(1)"/>
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    public int Next(int price)
    {
        int res = 1;
        while (stack.Count > 0 && stack.Peek().Key <= price)
        {
            res += stack.Pop().Value;
        }
        stack.Push(new KeyValuePair<int, int>(price, res));
        return res;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
// @lc code=end
/// <summary>
/// 99/99 cases passed (1428 ms)
/// Your runtime beats 5.56 % of csharp submissions
/// Your memory usage beats 5.56 % of csharp submissions (77.9 MB)
/// </summary>
public class SimpleStockSpanner
{
    private IList<int> prices = new List<int>();

    public SimpleStockSpanner() { }

    public int Next(int price)
    {
        var res = 1;
        for (int i = prices.Count - 1; i >= 0; i--)
        {
            if (price >= prices[i])
            {
                res++;
            }
            else
            {
                break;
            }
        }
        prices.Add(price);
        return res;
    }
}
