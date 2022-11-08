/*
 * @lc app=leetcode id=1544 lang=csharp
 *
 * [1544] Make The String Great
 */
using System.Text;

namespace Leetcode.MakeTheStringGreat;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 334/334 cases passed (89 ms)
    /// Your runtime beats 88.5 % of csharp submissions
    /// Your memory usage beats 5.31 % of csharp submissions (40.1 MB)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string MakeGood(string s)
    {
        var st = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (st.Count > 0 && char.ToLower(st.Peek()) == char.ToLower(s[i]) && st.Peek() != s[i])
            {
                st.Pop();
            }
            else
            {
                st.Push(s[i]);
            }
        }
        var charArr = st.ToList().ToArray();
        Array.Reverse(charArr);
        return new string(charArr);
    }
}

// @lc code=end
public class MySolution
{
    /// <summary>
    /// 334/334 cases passed (148 ms)
    /// Your runtime beats 30.09 % of csharp submissions
    /// Your memory usage beats 18.58 % of csharp submissions (38.4 MB)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string MakeGood(string s)
    {
        var sb = new StringBuilder(s);
        for (int i = 0; i < sb.Length - 1; )
        {
            if (char.ToLower(sb[i]) == char.ToLower(sb[i + 1]) && sb[i] != sb[i + 1])
            {
                sb.Remove(i, 2);
                if (i != 0)
                {
                    i--;
                }
            }
            else
            {
                i++;
            }
        }
        return sb.ToString();
    }
}
