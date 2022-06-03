/*
 * @lc app=leetcode.cn id=538 lang=cpp
 *
 * [538] 把二叉搜索树转换为累加树
 */

#include <algorithm>
#include <iostream>
#include <vector>
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
  void dfs(std::vector<TreeNode *> &nodes, TreeNode *root) {
    if (root) {
      nodes.push_back(root);
      dfs(nodes, root->left);
      dfs(nodes, root->right);
    }
  }

public:
  /**
   * @brief
   * 215/215 cases passed (36 ms)
   * Your runtime beats 57.83 % of cpp submissions
   * Your memory usage beats 5.02 % of cpp submissions (33.4 MB)
   * @param root
   * @return TreeNode*
   */
  TreeNode *convertBST(TreeNode *root) {
    std::vector<TreeNode *> nodes;
    dfs(nodes, root);
    std::sort(nodes.begin(), nodes.end(),
              [](TreeNode *a, TreeNode *b) { return a->val < b->val; });
    for (int i = nodes.size() - 2; i >= 0; i--) {
      nodes[i]->val += nodes[i + 1]->val;
    }
    return root;
  }
};
// @lc code=end
