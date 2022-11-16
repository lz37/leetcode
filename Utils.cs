namespace Leetcode;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class GuessGame
{
    private int pick = 6;
    public int guess(int num)
    {
        if (num < pick)
        {
            return 1;
        }
        else if (num > pick)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
