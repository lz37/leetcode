/*
 * @lc app=leetcode id=1408 lang=csharp
 *
 * [1408] String Matching in an Array
 */
namespace Leetcode.StringMatchingInAnArray;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 67/67 cases passed (240 ms)
    /// Your runtime beats 78.08 % of csharp submissions
    /// Your memory usage beats 79.45 % of csharp submissions (42.7 MB)
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public IList<string> StringMatching(string[] words)
    {
        var ans = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (words[i].Length > words[j].Length)
                {
                    continue;
                }
                if (words[j].Contains(words[i]))
                {
                    ans.Add(words[i]);
                    break;
                }
            }
        }
        return ans;
    }
}
// @lc code=end
