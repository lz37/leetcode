/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes
 */
namespace Leetcode.CountCompleteTreeNodes;
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
    private int deepth = 0;
    private int dfs(TreeNode node, int nowDeep, int pos)
    {
        if (node is { right: TreeNode, left: TreeNode })
        {
            var res = -1;
            if ((res = dfs(node.right, nowDeep + 1, pos * 2)) > 0)
                return res;
            if ((res = dfs(node.left, nowDeep + 1, pos * 2 - 1)) > 0)
                return res;
        }
        else if (node is { left: TreeNode })
        {
            deepth = nowDeep + 1;
            return pos * 2 - 1;
        }
        else
        {
            if (deepth == 0) { deepth = nowDeep; }
            if (nowDeep > deepth) { deepth++; return pos; }
        }
        return -1;
    }
    /// <summary>
    /// 18/18 cases passed (101 ms)
    /// Your runtime beats 94.37 % of csharp submissions
    /// Your memory usage beats 21.83 % of csharp submissions (46.3 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int CountNodes(TreeNode root)
    {
        if (root is null)
            return 0;
        var pos = dfs(root, 1, 1);
        return pos < 0 ? (1 << deepth) - 1 : pos + (1 << (deepth - 1)) - 1;
    }
}
// @lc code=end