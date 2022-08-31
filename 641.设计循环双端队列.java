/*
 * @lc app=leetcode.cn id=641 lang=java
 *
 * [641] 设计循环双端队列
 */

// @lc code=start
/**
 * 51/51 cases passed (4 ms)
 * Your runtime beats 100 % of java submissions
 * Your memory usage beats 19.15 % of java submissions (42.2 MB)
 */
class MyCircularDeque {

  private int maxNum;
  private int num;

  private class DqNode {

    int val;
    DqNode next;
    DqNode before;

    public DqNode(int val, DqNode next, DqNode before) {
      this.val = val;
      this.next = next;
      this.before = before;
    }
  }

  private DqNode front;
  private DqNode rear;

  public MyCircularDeque(int k) {
    this.maxNum = k;
    this.num = 0;
    front = null;
    rear = null;
  }

  public boolean insertFront(int value) {
    if (num == maxNum) {
      return false;
    }
    if (num == 0) {
      front = new DqNode(value, null, null);
      rear = front;
    } else {
      front.before = new DqNode(value, front, null);
      front = front.before;
    }
    this.num++;
    return true;
  }

  public boolean insertLast(int value) {
    if (num == maxNum) {
      return false;
    }
    if (num == 0) {
      front = new DqNode(value, null, null);
      rear = front;
    } else {
      rear.next = new DqNode(value, null, rear);
      rear = rear.next;
    }
    this.num++;
    return true;
  }

  public boolean deleteFront() {
    switch (num) {
      case 0:
        return false;
      case 1:
        front = null;
        rear = null;
        break;
      default:
        front = front.next;
        front.before = null;
        break;
    }
    this.num--;
    return true;
  }

  public boolean deleteLast() {
    switch (num) {
      case 0:
        return false;
      case 1:
        front = null;
        rear = null;
        break;
      default:
        rear = rear.before;
        rear.next = null;
        break;
    }
    this.num--;
    return true;
  }

  public int getFront() {
    return front == null ? -1 : front.val;
  }

  public int getRear() {
    return rear == null ? -1 : rear.val;
  }

  public boolean isEmpty() {
    return num == 0;
  }

  public boolean isFull() {
    return num == maxNum;
  }
}
/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * boolean param_1 = obj.insertFront(value);
 * boolean param_2 = obj.insertLast(value);
 * boolean param_3 = obj.deleteFront();
 * boolean param_4 = obj.deleteLast();
 * int param_5 = obj.getFront();
 * int param_6 = obj.getRear();
 * boolean param_7 = obj.isEmpty();
 * boolean param_8 = obj.isFull();
 */
// @lc code=end
