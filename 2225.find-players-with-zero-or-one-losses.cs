/*
 * @lc app=leetcode id=2225 lang=csharp
 *
 * [2225] Find Players With Zero or One Losses
 */
namespace Leetcode.FindPlayersWithZeroOrOneLosses;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 127/127 cases passed (653 ms)
    /// Your runtime beats 96.43 % of csharp submissions
    /// Your memory usage beats 22.32 % of csharp submissions (74.3 MB)
    /// </summary>
    /// <param name="matches"></param>
    /// <returns></returns>
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var lost = new Dictionary<int, int>();
        Array.ForEach(matches, match =>
            {
                if (lost.ContainsKey(match[1]))
                    lost[match[1]]++;
                else
                    lost[match[1]] = 1;
                if (!lost.ContainsKey(match[0]))
                    lost[match[0]] = 0;
            }
        );
        var lost0 = new List<int>();
        var lost1 = new List<int>();
        foreach (var kv in lost)
        {
            switch (kv.Value)
            {
                case 0: lost0.Add(kv.Key); break;
                case 1: lost1.Add(kv.Key); break;
                default: continue;
            }
        }
        lost0.Sort();
        lost1.Sort();
        return new List<IList<int>>
        {
            lost0,
            lost1
        };
    }
}
// @lc code=end

