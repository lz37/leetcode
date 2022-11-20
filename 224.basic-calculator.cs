/*
 * @lc app=leetcode id=224 lang=csharp
 *
 * [224] Basic Calculator
 */
namespace Leetcode.BasicCalculator;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 44/44 cases passed (64 ms)
    /// Your runtime beats 97.88 % of csharp submissions
    /// Your memory usage beats 50.26 % of csharp submissions (38.6 MB)
    /// </summary>
    /// <see href="https://leetcode.com/problems/basic-calculator/discuss/62361/Iterative-Java-solution-with-stack"/>
    /// <param name="s"></param>
    /// <returns></returns>
    public int Calculate(string s)
    {
        var stack = new Stack<int>();
        var result = 0;
        var number = 0;
        var sign = 1;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsDigit(c))
            {
                number = 10 * number + (c - '0');
            }
            else if (c == '+')
            {
                result += sign * number;
                number = 0;
                sign = 1;
            }
            else if (c == '-')
            {
                result += sign * number;
                number = 0;
                sign = -1;
            }
            else if (c == '(')
            {
                //we push the result first, then sign;
                stack.Push(result);
                stack.Push(sign);
                //reset the sign and result for the value in the parenthesis
                sign = 1;
                result = 0;
            }
            else if (c == ')')
            {
                result += sign * number;
                number = 0;
                result *= stack.Pop();   //stack.pop() is the sign before the parenthesis
                result += stack.Pop();   //stack.pop() now is the result calculated before the parenthesis
            }
        }
        if (number != 0) result += sign * number;
        return result;
    }
}
// @lc code=end
