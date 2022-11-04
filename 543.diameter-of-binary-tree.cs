/*
 * @lc app=leetcode id=543 lang=csharp
 *
 * [543] Diameter of Binary Tree
 */
namespace Leetcode.DiameterOfBinaryTree;
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
    private int maxDiameter = 0;
    private void dfsCalc(TreeNode root)
    {
        if (root is null)
        {
            return;
        }
        dfsCalc(root.left);
        dfsCalc(root.right);
        int leftLength = root.left != null ? root.left.val + 1 : 0;
        int rightLength = root.right != null ? root.right.val + 1 : 0;
        root.val = Math.Max(leftLength, rightLength);
        maxDiameter = Math.Max(maxDiameter, leftLength + rightLength);
    }
    /// <summary>
    /// 104/104 cases passed (168 ms)
    /// Your runtime beats 22.83 % of csharp submissions
    /// Your memory usage beats 87.17 % of csharp submissions (37.9 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }
        dfsCalc(root);
        return maxDiameter;
    }
}
// @lc code=end

