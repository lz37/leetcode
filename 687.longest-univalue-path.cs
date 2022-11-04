/*
 * @lc app=leetcode id=687 lang=csharp
 *
 * [687] Longest Univalue Path
 */
namespace Leetcode.LongestUnivaluePath;
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
    private int max = 0;
    private int dfs(TreeNode node)
    {
        if (node is null)
        {
            return 0;
        }
        var leftLength = 0;
        var rightLength = 0;
        if (node.left is not null)
        {
            if (node.left.val == node.val)
            {
                leftLength = dfs(node.left) + 1;
            }
            else
            {
                dfs(node.left);
            }
        }
        if (node.right is not null)
        {
            if (node.right.val == node.val)
            {
                rightLength = dfs(node.right) + 1;
            }
            else
            {
                dfs(node.right);
            }
        }
        max = Math.Max(max, leftLength + rightLength);
        return Math.Max(leftLength, rightLength);
    }
    /// <summary>
    /// 71/71 cases passed (234 ms)
    /// Your runtime beats 81.33 % of csharp submissions
    /// Your memory usage beats 78.67 % of csharp submissions (45.9 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int LongestUnivaluePath(TreeNode root)
    {
        dfs(root);
        return max;
    }
}
// @lc code=end

