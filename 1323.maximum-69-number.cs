using System.Text;

/*
 * @lc app=leetcode id=1323 lang=csharp
 *
 * [1323] Maximum 69 Number
 */
namespace Leetcode.Maximum69Number;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 153/153 cases passed (33 ms)
    /// Your runtime beats 75.74 % of csharp submissions
    /// Your memory usage beats 91.72 % of csharp submissions (25 MB)
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int Maximum69Number(int num)
    {
        var str = new StringBuilder(num.ToString());
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '6')
            {
                str[i] = '9';
                break;
            }
        }
        return int.Parse(str.ToString());
    }
}
// @lc code=end
