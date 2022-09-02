/*
 * @lc app=leetcode.cn id=998 lang=java
 *
 * [998] 最大二叉树 II
 */
import java.util.ArrayList;
import java.util.List;

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

  private int maxPosOf(List<TreeNode> nodeList) {
    var res = 0;
    for (int i = 0; i < nodeList.size(); i++) {
      if (nodeList.get(i).val > nodeList.get(res).val) {
        res = i;
      }
    }
    return res;
  }

  private List<TreeNode> getA(List<TreeNode> a, int index) {
    if (a.isEmpty()) {
      return null;
    }
    var root = a.get(index);
    if (root.right != null) {
      a.add(index + 1, root.right);
      a = getA(a, index + 1);
    }
    if (root.left != null) {
      a.add(index, root.left);
      a = getA(a, index);
    }
    return a;
  }

  private TreeNode getConstructB(List<TreeNode> toB, int rootPos) {
    var root = toB.get(rootPos);
    var leftList = toB.subList(0, rootPos);
    var rightList = toB.subList(rootPos + 1, toB.size());
    if (!leftList.isEmpty()) {
      root.left = getConstructB(leftList, maxPosOf(leftList));
    }
    if (!rightList.isEmpty()) {
      root.right = getConstructB(rightList, maxPosOf(rightList));
    }
    return root;
  }

  /**
   * 75/75 cases passed (1 ms)
   * Your runtime beats 100 % of java submissions
   * Your memory usage beats 28.15 % of java submissions (39.7 MB)
   * {@summary 暴力解居然这个速度，亏我费劲优化半天}
   * @param root
   * @param val
   * @return
   */
  public TreeNode insertIntoMaxTree(TreeNode root, int val) {
    var a = getA(
      new ArrayList<TreeNode>() {
        {
          if (root != null) {
            add(root);
          }
        }
      },
      0
    );
    a.add(new TreeNode(val));
    return getConstructB(a, val > root.val ? a.size() - 1 : a.indexOf(root));
  }
}
// @lc code=end
