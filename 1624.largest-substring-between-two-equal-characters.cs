/*
 * @lc app=leetcode id=1624 lang=csharp
 *
 * [1624] Largest Substring Between Two Equal Characters
 */
namespace Leetcode.LargestSubstringBetweenTwoEqualCharacters;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 54/54 cases passed (106 ms)
    /// Your runtime beats 52.94 % of csharp submissions
    /// Your memory usage beats 73.53 % of csharp submissions (34.7 MB)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var firstPos = new Nullable<int>[26];
        var max = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (firstPos[s[i] - 'a'] is null)
            {
                firstPos[s[i] - 'a'] = i;
            }
            else
            {
                max = Math.Max(i - firstPos[s[i] - 'a'].Value - 1, max);
            }
        }
        return max;
    }
}
// @lc code=end
