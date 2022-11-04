/*
 * @lc app=leetcode id=345 lang=csharp
 *
 * [345] Reverse Vowels of a String
 */
using System.Text;

namespace Leetcode.ReverseVowelsOfAString;
// @lc code=start
public class Solution
{

    private static readonly ISet<char> vowels = new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });
    /// <summary>
    /// 480/480 cases passed (141 ms)
    /// Your runtime beats 64.34 % of csharp submissions
    /// Your memory usage beats 82.17 % of csharp submissions (39 MB)
    /// <see href="https://leetcode.com/problems/reverse-vowels-of-a-string/discuss/81225/Java-Standard-Two-Pointer-Solution"/>
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseVowels(string s)
    {
        var chars = s.ToCharArray();
        var start = 0;
        var end = s.Length - 1;
        while (end > start)
        {
            while (start < end && !vowels.Contains(chars[start]))
            {
                start++;
            }
            while (start < end && !vowels.Contains(chars[end]))
            {
                end--;
            }
            (chars[start], chars[end]) = (chars[end], chars[start]);
            start++;
            end--;
        }
        return new string(chars);
    }
}
// @lc code=end
public class MySolution
{
    /// <summary>
    /// 480/480 cases passed (231 ms)
    /// Your runtime beats 18.22 % of csharp submissions
    /// Your memory usage beats 24.81 % of csharp submissions (41.1 MB)
    /// </summary>
    /// <value></value>
    private static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
    private bool isOfVowels(char ch)
    {
        var res = false;
        vowels.ToList().ForEach((c) =>
        {
            if (char.ToLower(ch) == c)
            {
                res = true;
            }
        });
        return res;
    }
    public string ReverseVowels(string s)
    {
        var vowelsPoses = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (isOfVowels(s[i]))
            {
                vowelsPoses.Add(i);
            }
        }
        var sBuilder = new StringBuilder(s);
        for (int i = 0; i < vowelsPoses.Count / 2; i++)
        {
            (sBuilder[vowelsPoses[i]], sBuilder[vowelsPoses[vowelsPoses.Count - 1 - i]]) = (sBuilder[vowelsPoses[vowelsPoses.Count - 1 - i]], sBuilder[vowelsPoses[i]]);
        }
        return sBuilder.ToString();
    }
}
