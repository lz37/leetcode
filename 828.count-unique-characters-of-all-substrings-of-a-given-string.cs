/*
 * @lc app=leetcode id=828 lang=csharp
 *
 * [828] Count Unique Characters of All Substrings of a Given String
 */
namespace Leetcode.CountUniqueCharactersOfAllSubstringsOfAGivenString;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 76/76 cases passed (168 ms)
    /// Your runtime beats 21.43 % of csharp submissions
    /// Your memory usage beats 60 % of csharp submissions (40.5 MB)
    /// <br/>
    /// 对于下标为 i 的字符 c<sub>i</sub>，当它在某个子字符串中仅出现一次时，它会对这个子字符串统计唯一字符时有贡献。只需对每个字符，计算有多少子字符串仅包含该字符一次即可。对于 c<sub>i</sub> ， 记同字符上一次出现的位置为 c<sub>j</sub> ，下一次出现的位置为 c<sub>k</sub> ，那么这样的子字符串就一共有 (c<sub>i</sub> - c<sub>j</sub>) × (c<sub>k</sub> - c<sub>i</sub>)(c<sub>i</sub> −c<sub>j</sub> )×(c<sub>k</sub> −c<sub>i</sub> ) 种，即子字符串的起始位置有 c<sub>j</sub> （不含）到 c<sub>i</sub> （含）之间这 (c<sub>i</sub> - c<sub>j</sub>)(c<sub>i</sub> −c<sub>j</sub> ) 种可能，到结束位置有 (c<sub>k</sub> - c<sub>i</sub>)(c<sub>k</sub> −c<sub>i</sub> ) 种可能。可以预处理 s，将相同字符的下标放入数组中，方便计算。最后对所有字符进行这种计算即可。
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int UniqueLetterString(string s)
    {
        var index = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (!index.ContainsKey(c))
            {
                index[c] = new List<int>();
                index[c].Add(-1);
            }
            index[c].Add(i);
        }
        var res = 0;
        foreach (var pair in index)
        {
            var arr = pair.Value;
            arr.Add(s.Length);
            for (var i = 1; i < arr.Count - 1; i++)
            {
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
            }
        }
        return res;
    }
}
// @lc code=end

