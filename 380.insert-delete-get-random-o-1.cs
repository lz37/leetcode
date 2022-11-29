/*
 * @lc app=leetcode id=380 lang=csharp
 *
 * [380] Insert Delete GetRandom O(1)
 */
namespace Leetcode.InsertDeleteGetRandomO1;
// @lc code=start
/// <summary>
/// 19/19 cases passed (342 ms)
/// Your runtime beats 91.91 % of csharp submissions
/// Your memory usage beats 63.6 % of csharp submissions (87.8 MB)
/// <see href="https://leetcode.com/problems/insert-delete-getrandom-o1/discuss/85401/Java-solution-using-a-HashMap-and-an-ArrayList-along-with-a-follow-up.-(131-ms)"/>
/// </summary>
public class RandomizedSet
{
    private List<int> nums = new();
    private Dictionary<int, int> locs = new();
    private Random random = new();

    public RandomizedSet()
    {

    }

    public bool Insert(int val)
    {
        if (locs.ContainsKey(val))
            return false;
        locs[val] = nums.Count;
        nums.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!locs.ContainsKey(val))
            return false;
        var loc = locs[val];
        if (loc < nums.Count - 1)
        {
            nums[loc] = nums[^1];
            locs[nums[loc]] = loc;
        }
        nums.RemoveAt(nums.Count - 1);
        locs.Remove(val);
        return true;
    }

    public int GetRandom()
    {
        return nums[random.Next(nums.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
// @lc code=end