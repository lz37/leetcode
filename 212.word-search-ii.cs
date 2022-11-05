/*
 * @lc app=leetcode id=212 lang=csharp
 *
 * [212] Word Search II
 */
namespace Leetcode.WordSearchII;
// @lc code=start
public class Solution
{
    private class TrieNode
    {
        public TrieNode[] next = new TrieNode[26];
        public string? word;
    }
    /// <summary>
    /// <code>以words = ["oath","pea","eat","rain"]为例</code>
    /// 在root节点下生成o->a->t->h（最后一节点word=oath）及其他节点组成的树
    /// 该例子看不出来，如果是aot、apple两个单词，那么root的next[a]就是公用的
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    private TrieNode buildNode(string[] words)
    {
        var root = new TrieNode();
        foreach (var word in words)
        {
            var p = root;
            foreach (var ch in word)
            {
                int i = ch - 'a';
                if (p.next[i] is null)
                {
                    p.next[i] = new TrieNode();
                }
                p = p.next[i];
            }
            p.word = word;
        }
        return root;
    }

    private void dfs(char[][] board, int i, int j, TrieNode p, IList<string> res)
    {
        var c = board[i][j];
        if (c == '#' || p.next[c - 'a'] is null)
        {
            return;
        }
        p = p.next[c - 'a'];
        // 到底了
        if (p.word is not null)
        {
            res.Add(p.word);
            p.word = null;
        }
        // visited
        board[i][j] = '#';
        // 四方延伸
        if (i > 0) dfs(board, i - 1, j, p, res);
        if (j > 0) dfs(board, i, j - 1, p, res);
        if (i < board.Length - 1) dfs(board, i + 1, j, p, res);
        if (j < board[0].Length - 1) dfs(board, i, j + 1, p, res);
        // not visited
        board[i][j] = c;
    }
    /// <summary>
    /// 64/64 cases passed (730 ms)
    /// Your runtime beats 71.19 % of csharp submissions
    /// Your memory usage beats 60.68 % of csharp submissions (47.4 MB)
    /// <see href="https://leetcode.com/problems/word-search-ii/discuss/59780/Java-15ms-Easiest-Solution-(100.00)"/>
    /// </summary>
    /// <param name="board"></param>
    /// <param name="words"></param>
    /// <returns></returns>
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var res = new List<string>();
        var root = buildNode(words);
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                dfs(board, i, j, root, res);
            }
        }
        return res;
    }
}
// @lc code=end

