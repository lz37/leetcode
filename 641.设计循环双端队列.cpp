/*
 * @lc app=leetcode.cn id=641 lang=cpp
 *
 * [641] 设计循环双端队列
 */

// @lc code=start
/**
 * @brief
 * 51/51 cases passed (28 ms)
 * Your runtime beats 36.53 % of cpp submissions
 * Your memory usage beats 12.26 % of cpp submissions (16.6 MB)
 */
class MyCircularDeque {
private:
  int maxNum;
  int num;
  struct DqNode {
    int val;
    DqNode *next;
    DqNode *before;
    DqNode(int val, DqNode *next, DqNode *before)
        : val(val), next(next), before(before){};
  };
  DqNode *front;
  DqNode *rear;

public:
  MyCircularDeque(int k) {
    this->maxNum = k;
    this->num = 0;
    front = nullptr;
    rear = nullptr;
  }
  ~MyCircularDeque() {
    for (; front;) {
      auto tmp = front;
      front = front->next;
      delete tmp;
    }
  }

  bool insertFront(int value) {
    if (num == maxNum) {
      return false;
    }
    if (num == 0) {
      front = new DqNode(value, nullptr, nullptr);
      rear = front;
    } else {
      front->before = new DqNode(value, front, nullptr);
      front = front->before;
    }
    this->num++;
    return true;
  }

  bool insertLast(int value) {
    if (num == maxNum) {
      return false;
    }
    if (num == 0) {
      rear = new DqNode(value, nullptr, nullptr);
      front = rear;
    } else {
      rear->next = new DqNode(value, nullptr, rear);
      rear = rear->next;
    }
    this->num++;
    return true;
  }

  bool deleteFront() {
    if (num == 0) {
      return false;
    }
    if (num == 1) {
      delete front;
      front = nullptr;
      rear = nullptr;
    } else {
      auto tmp = front;
      front = front->next;
      delete tmp;
      front->before = nullptr;
    }
    this->num--;
    return true;
  }

  bool deleteLast() {
    if (num == 0) {
      return false;
    }
    if (num == 1) {
      delete rear;
      front = nullptr;
      rear = nullptr;
    } else {
      auto tmp = rear;
      rear = rear->before;
      delete tmp;
      rear->next = nullptr;
    }
    this->num--;
    return true;
  }

  int getFront() { return front ? front->val : -1; }

  int getRear() { return rear ? rear->val : -1; }

  bool isEmpty() { return this->num == 0; }

  bool isFull() { return this->num == this->maxNum; }
};

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque* obj = new MyCircularDeque(k);
 * bool param_1 = obj->insertFront(value);
 * bool param_2 = obj->insertLast(value);
 * bool param_3 = obj->deleteFront();
 * bool param_4 = obj->deleteLast();
 * int param_5 = obj->getFront();
 * int param_6 = obj->getRear();
 * bool param_7 = obj->isEmpty();
 * bool param_8 = obj->isFull();
 */
// @lc code=end
