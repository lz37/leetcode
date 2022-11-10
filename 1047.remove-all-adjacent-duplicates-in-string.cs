/*
 * @lc app=leetcode id=1047 lang=csharp
 *
 * [1047] Remove All Adjacent Duplicates In String
 */
namespace Leetcode.RemoveAllAdjacentDuplicatesInString;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 106/106 cases passed (152 ms)
    /// Your runtime beats 66.35 % of csharp submissions
    /// Your memory usage beats 73.93 % of csharp submissions (38.5 MB)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string RemoveDuplicates(string s)
    {
        var st = new Stack<char>();
        foreach (var ch in s)
        {
            if (st.Count > 0 && st.Peek() == ch)
            {
                st.Pop();
            }
            else
            {
                st.Push(ch);
            }
        }
        var chArr = st.ToArray();
        Array.Reverse(chArr);
        return new string(chArr);
    }
}
// @lc code=end
