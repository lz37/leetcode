/*
 * @lc app=leetcode.cn id=1302 lang=cpp
 *
 * [1302] 层数最深叶子节点的和
 */
#include <queue>
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
public:
  /**
   * @brief
   * 39/39 cases passed (88 ms)
   * Your runtime beats 65.02 % of cpp submissions
   * Your memory usage beats 27.3 % of cpp submissions (60.4 MB)
   * @param root
   * @return int
   */
  int deepestLeavesSum(TreeNode *root) {
    std::queue<TreeNode *> bfs;
    bfs.push(root);
    for (; !bfs.empty();) {
      auto num = bfs.size();
      int ans = 0;
      for (; num--;) {
        auto fr = bfs.front();
        bfs.pop();
        ans += fr->val;
        if (fr->left) {
          bfs.push(fr->left);
        }
        if (fr->right) {
          bfs.push(fr->right);
        }
      }
      if (bfs.size() == 0) {
        return ans;
      }
    }
    return 0;
  }
};
// @lc code=end
