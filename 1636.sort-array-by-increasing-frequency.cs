/*
 * @lc app=leetcode id=1636 lang=csharp
 *
 * [1636] Sort Array by Increasing Frequency
 */
namespace Leetcode.SortArrayByIncreasingFrequency;
// @lc code=start
public class Solution
{
    /// <summary>
    /// 180/180 cases passed (148 ms)
    /// Your runtime beats 95.51 % of csharp submissions
    /// Your memory usage beats 12.36 % of csharp submissions (44.3 MB)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] FrequencySort(int[] nums)
    {
        var hash = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            hash[num] = hash.ContainsKey(num) ? hash[num] + 1 : 1;
        }
        var set = new SortedSet<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((o1, o2) =>
        (o1.Value != o2.Value) ? o1.Value - o2.Value : o2.Key - o1.Key));
        hash.AsEnumerable().ToList().ForEach(o => set.Add(o));
        var res = new int[nums.Length];
        var i = 0;
        foreach (var pair in set)
        {
            for (int j = 0; j < pair.Value; j++)
            {
                res[i + j] = pair.Key;
            }
            i += pair.Value;
        }
        return res;
    }
}
// @lc code=end

