/*
 * @lc app=leetcode id=998 lang=csharp
 *
 * [998] Maximum Binary Tree II
 */
namespace Leetcode.MaximumBinaryTreeII;
// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    private int maxPosOf(List<TreeNode> nodeList)
    {
        var res = 0;
        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].val > nodeList[res].val)
            {
                res = i;
            }
        }
        return res;
    }
    private List<TreeNode> getA(List<TreeNode> a, int index)
    {
        if (a.Count == 0)
        {
            return a;
        }
        var root = a[index];
        if (root.right is not null)
        {
            a.Insert(index + 1, root.right);
            a = getA(a, index + 1);
        }
        if (root.left is not null)
        {
            a.Insert(index, root.left);
            a = getA(a, index);
        }
        return a;
    }
    private TreeNode getConstructB(List<TreeNode> toB, int rootPos)
    {
        var root = toB[rootPos];
        var leftList = toB.GetRange(0, rootPos);
        var rightList = toB.GetRange(rootPos + 1, toB.Count - rootPos - 1);
        if (leftList.Count != 0)
        {
            root.left = getConstructB(leftList, maxPosOf(leftList));
        }
        if (rightList.Count != 0)
        {
            root.right = getConstructB(rightList, maxPosOf(rightList));
        }
        return root;
    }
    /// <summary>
    /// 75/75 cases passed (121 ms)
    /// Your runtime beats 80 % of csharp submissions
    /// Your memory usage beats 20 % of csharp submissions (37.8 MB)
    /// </summary>
    /// <param name="root"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public TreeNode InsertIntoMaxTree(TreeNode root, int val)
    {
        var a = new List<TreeNode>();
        if (root is not null)
        {
            a.Add(root);
        }
        a = getA(a, 0);
        a.Add(new TreeNode(val));
        return getConstructB(a, val > root?.val ? a.Count - 1 : a.IndexOf(root));
    }
}
// @lc code=end

