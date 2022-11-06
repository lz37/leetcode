/*
 * @lc app=leetcode id=636 lang=csharp
 *
 * [636] Exclusive Time of Functions
 */
namespace Leetcode.ExclusiveTimeOfFunctions;

// @lc code=start
public class Solution
{
    /// <summary>
    /// 120/120 cases passed (277 ms)
    /// Your runtime beats 42.19 % of csharp submissions
    /// Your memory usage beats 98.44 % of csharp submissions (45.9 MB)
    /// </summary>
    /// <param name="n"></param>
    /// <param name="logs"></param>
    /// <returns></returns>
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var st = new Stack<KeyValuePair<int, int>>();
        var res = new int[n];
        foreach (var log in logs)
        {
            var logstrs = log.Split(':');
            var idx = int.Parse(logstrs[0]);
            var type = logstrs[1].ToCharArray();
            var timestamp = int.Parse(logstrs[2]);
            if (type[0] == 's')
            {
                if (st.Count > 0)
                {
                    res[st.First().Key] += timestamp - st.First().Value;
                    var kv = st.Pop();
                    st.Push(new KeyValuePair<int, int>(kv.Key, timestamp));
                }
                st.Push(new KeyValuePair<int, int>(idx, timestamp));
            }
            else
            {
                var t = st.Pop();
                res[t.Key] += timestamp - t.Value + 1;
                if (st.Count > 0)
                {
                    var kv = st.Pop();
                    st.Push(new KeyValuePair<int, int>(kv.Key, timestamp + 1));
                }
            }
        }
        return res;
    }
}
// @lc code=end
