/*
 * @lc app=leetcode id=652 lang=csharp
 *
 * [652] Find Duplicate Subtrees
 */
namespace Leetcode.FindDuplicateSubtrees;

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
    private IDictionary<string, int> mp = new Dictionary<string, int>();
    private IList<TreeNode> res = new List<TreeNode>();

    private string preOrderTraversal(TreeNode node)
    {
        if (node is null)
        {
            return "#";
        }
        var str = $"{node.val} {preOrderTraversal(node.left)} {preOrderTraversal(node.right)}";
        if (mp.TryGetValue(str, out var count) && count == 1)
        {
            res.Add(node);
        }
        mp[str] = mp.TryGetValue(str, out count) ? count + 1 : 1;
        return str;
    }

    /// <summary>
    /// 175/175 cases passed (270 ms)
    /// Your runtime beats 61.11 % of csharp submissions
    /// Your memory usage beats 56.94 % of csharp submissions (57.6 MB)
    /// <see href="https://leetcode.cn/problems/find-duplicate-subtrees/comments/"/>
    /// <br/>
    /// <author>wooooo(cpp实现)</author>
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        preOrderTraversal(root);
        return res;
    }
}
// @lc code=end
