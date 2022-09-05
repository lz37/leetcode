/*
 * @lc app=leetcode.cn id=652 lang=java
 *
 * [652] 寻找重复的子树
 */
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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

  private Map<String, Integer> mp = new HashMap<>();
  private List<TreeNode> res = new ArrayList<>();

  private String preOrderTraversal(TreeNode node) {
    if (node == null) {
      return "#";
    }
    var str =
      String.valueOf(node.val) +
      " " +
      preOrderTraversal(node.left) +
      " " +
      preOrderTraversal(node.right);
    if (mp.getOrDefault(str, 0) == 1) {
      res.add(node);
    }
    mp.put(str, mp.getOrDefault(str, 0) + 1);
    return str;
  }

  /**
   * 176/176 cases passed (19 ms)
   * Your runtime beats 84.97 % of java submissions
   * Your memory usage beats 42.36 % of java submissions (48.5 MB)
   * <p>
   * {@link https://leetcode.cn/problems/find-duplicate-subtrees/comments/}
   * </p>
   * @author
   * wooooo(cpp实现)
   * @param root
   * @return
   */
  public List<TreeNode> findDuplicateSubtrees(TreeNode root) {
    preOrderTraversal(root);
    return res;
  }
}
// @lc code=end
