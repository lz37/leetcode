/*
 * @lc app=leetcode.cn id=538 lang=java
 *
 * [538] 把二叉搜索树转换为累加树
 */
import java.util.ArrayList;
import java.util.Collections;

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

  private ArrayList<TreeNode> dfs(ArrayList<TreeNode> nodes, TreeNode root) {
    if (root != null) {
      nodes.add(root);
      return dfs(dfs(nodes, root.left), root.right);
    } else {
      return nodes;
    }
  }

  /**
   * 215/215 cases passed (4 ms)
   * Your runtime beats 7.35 % of java submissions
   * Your memory usage beats 80.81 % of java submissions (41.4 MB)
   * @param root
   * @return
   */
  public TreeNode convertBST(TreeNode root) {
    var nodes = new ArrayList<TreeNode>();
    nodes = dfs(nodes, root);
    Collections.sort(nodes, (a, b) -> a.val - b.val);
    for (int i = nodes.size() - 2; i >= 0; i--) {
      nodes.get(i).val += nodes.get(i + 1).val;
    }
    return root;
  }
}
// @lc code=end
