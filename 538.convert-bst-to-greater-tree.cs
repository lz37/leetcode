/*
 * @lc app=leetcode id=538 lang=csharp
 *
 * [538] Convert BST to Greater Tree
 */

namespace Leetcode.ConvertBST2GreaterTree;
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
    private List<TreeNode> dfs(List<TreeNode> nodes, TreeNode? root)
    {
        if (root is null)
        {
            return nodes;
        }
        else
        {
            nodes.Add(root);
            return dfs(dfs(nodes, root.left), root.right);
        }
    }
    /// <summary>
    /// 215/215 cases passed (106 ms)
    /// Your runtime beats 89.39 % of csharp submissions
    /// Your memory usage beats 9.09 % of csharp submissions (44.7 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode ConvertBST(TreeNode root)
    {
        var nodes = dfs(new List<TreeNode>(), root);
        nodes.Sort((a, b) => a.val - b.val);
        for (int i = nodes.Count - 2; i >= 0; i--)
        {
            nodes[i].val += nodes[i + 1].val;
        }
        return root;
    }
}
// @lc code=end

