/*
 * @lc app=leetcode id=295 lang=csharp
 *
 * [295] Find Median from Data Stream
 */
namespace Leetcode.FindMedianFromDataStream;

// @lc code=start
/// <summary>
/// 21/21 cases passed (1073 ms)
/// Your runtime beats 53.87 % of csharp submissions
/// Your memory usage beats 89.59 % of csharp submissions (87.3 MB)
/// <see href="https://leetcode.com/problems/find-median-from-data-stream/discuss/74047/JavaPython-two-heap-solution-O(log-n)-add-O(1)-find"/>
/// 事先想过搞个平衡二叉树找中位数，但是太麻烦了，不过想想PriorityQueue就是由平衡二叉树实现的，那么左一个右一个就好了
/// 但是要注意large和small的优先级是反的，因为peek只拿最小值，但要挑出small的最大值才行
/// C#的PriorityQueue和Java不同，要额外传入一个优先度
/// </summary>
public class MedianFinder
{
    private PriorityQueue<int, int> small = new PriorityQueue<int, int>();
    private PriorityQueue<int, int> large = new PriorityQueue<int, int>();
    private bool even = true;

    public MedianFinder() { }

    public void AddNum(int num)
    {
        // 这里谁先谁后都无所谓，但要和FindMedian的对应上
        if (even)
        {
            small.Enqueue(num, -num);
            large.Enqueue(small.Peek(), small.Dequeue());
        }
        else
        {
            large.Enqueue(num, num);
            small.Enqueue(large.Peek(), -large.Dequeue());
        }
        even = !even;
    }

    public double FindMedian()
    {
        if (even)
            return (small.Peek() + large.Peek()) / 2.0;
        else
            return large.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end
/*
["MedianFinder","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian"]\n[[],[-1],[],[-2],[],[-3],[],[-4],[],[-5],[]]
*/
