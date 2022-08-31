/*
 * @lc app=leetcode.cn id=1302 lang=java
 *
 * [1302] 层数最深叶子节点的和
 */
import java.util.concurrent.ConcurrentLinkedQueue;

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

  /**
   * 39/39 cases passed (11 ms)
   * Your runtime beats 6.95 % of java submissions
   * Your memory usage beats 89.11 % of java submissions (43.4 MB)
   * @param root
   * @return
   */
  public int deepestLeavesSum(TreeNode root) {
    var bfs = new ConcurrentLinkedQueue<TreeNode>();
    bfs.add(root);
    for (; !bfs.isEmpty();) {
      var size = bfs.size();
      var ans = 0;
      for (; size-- > 0;) {
        var fr = bfs.poll();
        ans += fr.val;
        if (fr.left != null) {
          bfs.add(fr.left);
        }
        if (fr.right != null) {
          bfs.add(fr.right);
        }
      }
      if (bfs.size() == 0) {
        return ans;
      }
    }
    return 0;
  }
}
// @lc code=end
