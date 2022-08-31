/*
 * @lc app=leetcode.cn id=543 lang=java
 *
 * [543] 二叉树的直径
 */
class TreeNode {

  int val;
  TreeNode left;
  TreeNode right;

  TreeNode() {}

  TreeNode(int val) {
    this.val = val;
  }

  TreeNode(int val, TreeNode left, TreeNode right) {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {

  private int maxDiameter = 0;

  private void dfsCalc(TreeNode root) {
    if (root == null) {
      return;
    }
    dfsCalc(root.left);
    dfsCalc(root.right);
    int leftLength = root.left != null ? root.left.val + 1 : 0;
    int rightLength = root.right != null ? root.right.val + 1 : 0;
    root.val = Math.max(leftLength, rightLength);
    maxDiameter = Math.max(maxDiameter, leftLength + rightLength);
  }

  /**
   * 104/104 cases passed (0 ms)
   * Your runtime beats 100 % of java submissions
   * Your memory usage beats 43.73 % of java submissions (41.2 MB)
   * @param root
   * @return
   */
  public int diameterOfBinaryTree(TreeNode root) {
    if (root == null) {
      return 0;
    }
    dfsCalc(root);
    return maxDiameter;
  }
}
// @lc code=end
