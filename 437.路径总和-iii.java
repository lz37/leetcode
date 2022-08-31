/*
 * @lc app=leetcode.cn id=437 lang=java
 *
 * [437] 路径总和 III
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

  private int count = 0;
  private int target;

  private void dfs(TreeNode root) {
    if (root != null) {
      subDfs(root, root, root.val);
      dfs(root.left);
      dfs(root.right);
    }
  }

  private void subDfs(TreeNode root, TreeNode child, long val) {
    if (val == target) {
      count++;
    }
    if (child.left != null) {
      subDfs(root, child.left, val + child.left.val);
    }
    if (child.right != null) {
      subDfs(root, child.right, val + child.right.val);
    }
  }

  /**
   * 128/128 cases passed (19 ms)
   * Your runtime beats 54.13 % of java submissions
   * Your memory usage beats 80.71 % of java submissions (40.9 MB)
   * @param root
   * @param targetSum
   * @return
   */
  public int pathSum(TreeNode root, int targetSum) {
    target = targetSum;
    dfs(root);
    return count;
  }
}
// @lc code=end
