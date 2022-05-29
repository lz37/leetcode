/*
 * @lc app=leetcode.cn id=437 lang=cpp
 *
 * [437] 路径总和 III
 */

struct TreeNode {
  int val;
  TreeNode *left;
  TreeNode *right;
  TreeNode() : val(0), left(nullptr), right(nullptr) {}
  TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
  TreeNode(int x, TreeNode *left, TreeNode *right)
      : val(x), left(left), right(right) {}
};
// @lc code=start
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left),
 * right(right) {}
 * };
 */
class Solution {
private:
  int count = 0;
  int target;
  void dfs(TreeNode *root) {
    if (root) {
      subDfs(root, root, root->val);
      dfs(root->left);
      dfs(root->right);
    }
  }
  void subDfs(TreeNode *root, TreeNode *child, long long val) {
    if (val == target)
      count++;
    if (child->left)
      subDfs(root, child->left, val + child->left->val);
    if (child->right)
      subDfs(root, child->right, val + child->right->val);
  }

public:
  /**
   * @brief
   * 127/127 cases passed (12 ms)
   * Your runtime beats 90.23 % of cpp submissions
   * Your memory usage beats 55.79 % of cpp submissions (15.6 MB)
   * @param root
   * @param targetSum
   * @return int
   */
  int pathSum(TreeNode *root, int targetSum) {
    target = targetSum;
    dfs(root);
    return count;
  }
};
// @lc code=end
