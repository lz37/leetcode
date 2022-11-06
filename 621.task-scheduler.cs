/*
 * @lc app=leetcode id=621 lang=csharp
 *
 * [621] Task Scheduler
 */
namespace Leetcode.TaskScheduler;

// @lc code=start
public class Solution
{
    private char findMostChar(IDictionary<char, int> hash)
    {
        var mostChar = 'A';
        for (var i = 'A'; i <= 'Z'; i++)
        {
            var hashI = hash.TryGetValue(i, out var count) ? count : 0;
            var hashMostChar = hash.TryGetValue(mostChar, out var countMostChar)
                ? countMostChar
                : 0;
            if (hashI > hashMostChar)
            {
                mostChar = i;
            }
        }
        return mostChar;
    }

    /// <summary>
    /// 71/71 cases passed (212 ms)
    /// Your runtime beats 80.92 % of csharp submissions
    /// Your memory usage beats 68.62 % of csharp submissions (41.4 MB)
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int LeastInterval(char[] tasks, int n)
    {
        var hash = new Dictionary<char, int>();
        foreach (var task in tasks)
        {
            hash[task] = hash.TryGetValue(task, out var c) ? c + 1 : 1;
        }
        char mostChar;
        int length = 0,
            mostTasks = 0;
        while (hash[mostChar = findMostChar(hash)] != 0)
        {
            if (mostTasks == 0)
            {
                mostTasks = hash[mostChar];
                length = hash[mostChar] * (n + 1) - n;
            }
            else if (hash[mostChar] == mostTasks)
            {
                length++;
            }
            hash[mostChar] = 0;
        }
        return Math.Max(length, tasks.Length);
    }
}
// @lc code=end
