/*
 * @lc app=leetcode id=399 lang=csharp
 *
 * [399] Evaluate Division
 */
namespace Leetcode.EvaluateDivision;
// @lc code=start
public class Solution
{
    private IDictionary<string, IDictionary<string, double>> graph = new Dictionary<string, IDictionary<string, double>>();
    private double findTarge(string start, string target, ISet<string> visited)
    {
        if (start == target)
        {
            return 1.0;
        }
        foreach (var pair in graph[start])
        {
            if (visited.Contains(pair.Key))
            {
                continue;
            }
            visited.Add(pair.Key);
            var tmp = findTarge(pair.Key, target, visited);
            if (tmp != -1.0)
            {
                return tmp * pair.Value;
            }
        }
        return -1.0;
    }
    /// <summary>
    /// 24/24 cases passed (254 ms)
    /// Your runtime beats 44.57 % of csharp submissions
    /// Your memory usage beats 81.14 % of csharp submissions (41.4 MB)
    /// </summary>
    /// <param name="equations"></param>
    /// <param name="values"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var ans = new double[queries.Count];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = -1.0;
        }
        for (int i = 0; i < equations.Count; i++)
        {
            var start = equations[i][0];
            var end = equations[i][1];
            var value = values[i];
            if (!graph.ContainsKey(start))
            {
                graph[start] = new Dictionary<string, double>();
            }
            if (!graph.ContainsKey(end))
            {
                graph[end] = new Dictionary<string, double>();
            }
            graph[start][end] = value;
            graph[end][start] = 1.0 / value;
        }
        for (int i = 0; i < queries.Count; i++)
        {
            if (graph.ContainsKey(queries[i][0]) && graph.ContainsKey(queries[i][1]))
            {
                ans[i] = findTarge(queries[i][0], queries[i][1], new HashSet<string>());
            }
        }
        return ans;
    }
}
// @lc code=end

