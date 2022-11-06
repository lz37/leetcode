/*
 * @lc app=leetcode id=739 lang=csharp
 *
 * [739] Daily Temperatures
 */
namespace Leetcode.DailyTemperatures;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 48/48 cases passed (461 ms)
    /// Your runtime beats 82.95 % of csharp submissions
    /// Your memory usage beats 5.49 % of csharp submissions (58.7 MB)
    /// </summary>
    /// <param name="temperatures"></param>
    /// <returns></returns>
    public int[] DailyTemperatures(int[] temperatures)
    {
        var ans = new int[temperatures.Length];
        var stack = new Stack<int>();
        stack.Push(0);
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count != 0 && temperatures[i] > temperatures[stack.First()])
            {
                ans[stack.First()] = i - stack.Pop();
            }
            stack.Push(i);
        }
        return ans;
    }
}
// @lc code=end
