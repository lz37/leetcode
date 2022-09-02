/*
 * @lc app=leetcode.cn id=687 lang=java
 *
 * [687] 最长同值路径
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

  private int max = 0;

  private int dfs(TreeNode node) {
    if (node == null) {
      return 0;
    }
    var leftLength = 0;
    var rightLength = 0;
    if (node.left != null) {
      if (node.left.val == node.val) {
        leftLength = dfs(node.left) + 1;
      } else {
        dfs(node.left);
      }
    }
    if (node.right != null) {
      if (node.right.val == node.val) {
        rightLength = dfs(node.right) + 1;
      } else {
        dfs(node.right);
      }
    }
    max = Math.max(max, leftLength + rightLength);
    return Math.max(leftLength, rightLength);
  }

  /**
   * 71/71 cases passed (2 ms)
   * Your runtime beats 96.54 % of java submissions
   * Your memory usage beats 93.7 % of java submissions (44.6 MB)
   * @param root
   * @return
   */
  public int longestUnivaluePath(TreeNode root) {
    dfs(root);
    return max;
  }
}
// @lc code=end
