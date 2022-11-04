/*
 * @lc app=leetcode id=437 lang=csharp
 *
 * [437] Path Sum III
 */
namespace Leetcode.PathSumIII;
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
    private int count = 0;
    private int target;
    private void dfs(TreeNode root)
    {
        if (root is null)
        {
            return;
        }
        subDfs(root, root, root.val);
        dfs(root.left);
        dfs(root.right);
    }
    private void subDfs(TreeNode root, TreeNode child, long val)
    {
        if (val == target)
        {
            count++;
        }
        if (child.left != null)
        {
            subDfs(root, child.left, val + child.left.val);
        }
        if (child.right != null)
        {
            subDfs(root, child.right, val + child.right.val);
        }
    }
    /// <summary>
    /// 128/128 cases passed (168 ms)
    /// Your runtime beats 56.01 % of csharp submissions
    /// Your memory usage beats 99.66 % of csharp submissions (38.2 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <param name="targetSum"></param>
    /// <returns></returns>
    public int PathSum(TreeNode root, int targetSum)
    {
        target = targetSum;
        dfs(root);
        return count;
    }
}
// @lc code=end

