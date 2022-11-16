/*
 * @lc app=leetcode id=374 lang=csharp
 *
 * [374] Guess Number Higher or Lower
 */
namespace Leetcode.GuessNumberHigherOrLower;
// @lc code=start
/**
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame
{
    /// <summary>
    /// 25/25 cases passed (11 ms)
    /// Your runtime beats 100 % of csharp submissions
    /// Your memory usage beats 19.49 % of csharp submissions (26.4 MB)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int GuessNumber(int n)
    {
        int guessV = n / 2;
        int guessR;
        int min = 0;
        int max = n;
        while ((guessR = guess(guessV)) != 0)
        {
            if (guessR == 1)
            {
                min = guessV;
                guessV = guessV / 2 + max / 2;
                if (guessV == min)
                {
                    guessV++;
                }
            }
            else
            {
                max = guessV;
                guessV = guessV / 2 + min / 2;
                if (guessV == max)
                {
                    guessV--;
                }
            }
        }
        return guessV;
    }
}
// @lc code=end

// 2126753390\n1702766719