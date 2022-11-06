/*
 * @lc app=leetcode id=1302 lang=csharp
 *
 * [1302] Deepest Leaves Sum
 */
namespace Leetcode.DeepestLeavesSum;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    /// <summary>
    /// 39/39 cases passed (148 ms)
    /// Your runtime beats 96.11 % of csharp submissions
    /// Your memory usage beats 12.78 % of csharp submissions (53.7 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int DeepestLeavesSum(TreeNode root)
    {
        var bfs = new LinkedList<TreeNode>();
        bfs.AddLast(root);
        while (bfs.Count != 0)
        {
            var size = bfs.Count;
            var ans = 0;
            while (size-- > 0)
            {
                var fr = bfs.First?.Value;
                bfs.RemoveFirst();
                ans += fr.val;
                if (fr.left is not null)
                {
                    bfs.AddLast(fr.left);
                }
                if (fr.right is not null)
                {
                    bfs.AddLast(fr.right);
                }
            }
            if (bfs.Count == 0)
            {
                return ans;
            }
        }
        return 0;
    }
}
// @lc code=end
