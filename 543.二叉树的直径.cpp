/*
 * @lc app=leetcode.cn id=543 lang=cpp
 *
 * [543] 二叉树的直径
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
#ifndef max
#define max(x, y) x > y ? x : y
#endif
private:
  int maxDiameter = 0;
  void dfsCalc(TreeNode *root) {
    if (!root)
      return;
    dfsCalc(root->left);
    dfsCalc(root->right);
    int leftLength = root->left ? root->left->val + 1 : 0;
    int rightLength = root->right ? root->right->val + 1 : 0;
    root->val = max(leftLength, rightLength);
    maxDiameter = max(maxDiameter, leftLength + rightLength);
  }

public:
  /**
   * @brief
   * 104/104 cases passed (4 ms)
   * Your runtime beats 94.78 % of cpp submissions
   * Your memory usage beats 92.52 % of cpp submissions (19.6 MB)
   *
   * @param root
   * @return int
   */
  int diameterOfBinaryTree(TreeNode *root) {
    if (!root)
      return 0;
    dfsCalc(root);
    return maxDiameter;
  }
};
// @lc code=end
