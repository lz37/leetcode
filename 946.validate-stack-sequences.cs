/*
 * @lc app=leetcode id=946 lang=csharp
 *
 * [946] Validate Stack Sequences
 */
namespace Leetcode.ValidateStackSequences;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 151/151 cases passed (110 ms)
    /// Your runtime beats 84.62 % of csharp submissions
    /// Your memory usage beats 13.46 % of csharp submissions (42.3 MB)
    /// </summary>
    /// <param name="pushed"></param>
    /// <param name="popped"></param>
    /// <returns></returns>
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var pushedList = new List<int>(pushed);
        var pushedPtr = 0;
        var poppedPtr = 0;
        while (true)
        {
            if (pushedList[pushedPtr] == popped[poppedPtr])
            {
                pushedList.RemoveAt(pushedPtr);
                pushedPtr = pushedPtr > 0 ? pushedPtr - 1 : 0;
                poppedPtr++;
            }
            else
            {
                pushedPtr++;
            }
            if (poppedPtr >= popped.Length)
            {
                return pushedList.Count == 0;
            }
            if (pushedPtr >= pushedList.Count)
            {
                return false;
            }
        }
    }
}
// @lc code=end

