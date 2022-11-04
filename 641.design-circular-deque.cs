/*
 * @lc app=leetcode id=641 lang=csharp
 *
 * [641] Design Circular Deque
 */
namespace Leetcode.DesignCircularDeque;
// @lc code=start
/// <summary>
/// 51/51 cases passed (234 ms)
/// Your runtime beats 65.71 % of csharp submissions
/// Your memory usage beats 28.57 % of csharp submissions (44.8 MB)
/// </summary>
public class MyCircularDeque
{
    #region private
    private int maxNum;
    private int num;
    private DqNode? front;
    private DqNode? rear;
    private class DqNode
    {
        public int val;
        public DqNode? next;
        public DqNode? before;

        public DqNode(int val, DqNode? next, DqNode? before)
        {
            this.val = val;
            this.next = next;
            this.before = before;
        }
    }
    #endregion

    public MyCircularDeque(int k)
    {
        maxNum = k;
        num = 0;
        front = null;
        rear = null;
    }

    public bool InsertFront(int value)
    {
        if (num == maxNum)
        {
            return false;
        }
        if (num == 0)
        {
            front = new DqNode(value, null, null);
            rear = front;
        }
        else
        {
            front.before = new DqNode(value, front, null);
            front = front.before;
        }
        num++;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (num == maxNum)
        {
            return false;
        }
        if (num == 0)
        {
            front = new DqNode(value, null, null);
            rear = front;
        }
        else
        {
            rear.next = new DqNode(value, null, rear);
            rear = rear.next;
        }
        num++;
        return true;
    }

    public bool DeleteFront()
    {
        switch (num)
        {
            case 0:
                return false;
            case 1:
                front = null;
                rear = null;
                break;
            default:
                front = front?.next;
                front.before = null;
                break;
        }
        num--;
        return true;
    }

    public bool DeleteLast()
    {
        switch (num)
        {
            case 0:
                return false;
            case 1:
                front = null;
                rear = null;
                break;
            default:
                rear = rear?.before;
                rear.next = null;
                break;
        }
        this.num--;
        return true;
    }

    public int GetFront()
    {
        return front == null ? -1 : front.val;
    }

    public int GetRear()
    {
        return rear == null ? -1 : rear.val;
    }

    public bool IsEmpty()
    {
        return num == 0;
    }

    public bool IsFull()
    {
        return num == maxNum;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
// @lc code=end

