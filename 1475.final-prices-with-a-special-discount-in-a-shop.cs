/*
 * @lc app=leetcode id=1475 lang=csharp
 *
 * [1475] Final Prices With a Special Discount in a Shop
 */
namespace Leetcode.FinalPricesWithASpecialDiscountInAShop;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 103/103 cases passed (237 ms)
    /// Your runtime beats 44.93 % of csharp submissions
    /// Your memory usage beats 84.06 % of csharp submissions (41.8 MB)
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int[] FinalPrices(int[] prices)
    {
        var res = prices;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] <= res[i])
                {
                    res[i] -= prices[j];
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

