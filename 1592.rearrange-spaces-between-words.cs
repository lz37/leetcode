/*
 * @lc app=leetcode id=1592 lang=csharp
 *
 * [1592] Rearrange Spaces Between Words
 */
namespace Leetcode.RearrangeSpacesBetweenWords;
// @lc code=start
using System.Text;

public class Solution
{
    private string makeSpaces(int n)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(" ");
        }
        return sb.ToString();
    }
    public string ReorderSpaces(string text)
    {
        var beginAndEnd = new List<KeyValuePair<int, int>>();
        var spacesNum = 0;
        var start = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                spacesNum++;
                if (i != 0 && text[i - 1] != ' ')
                {
                    beginAndEnd.Add(new KeyValuePair<int, int>(start, i));
                }
            }
            if (text[i] != ' ' && (i == 0 || text[i - 1] == ' '))
            {
                start = i;
            }
        }
        if (!text.EndsWith(" "))
        {
            beginAndEnd.Add(new KeyValuePair<int, int>(start, text.Length));
        }
        var wordsNum = beginAndEnd.Count;
        if (wordsNum == 1)
        {
            var word = beginAndEnd[0];
            return text.AsSpan(word.Key, word.Value - word.Key).ToString() + makeSpaces(text.Length - (word.Value - word.Key));
        }
        var gapSpaces = makeSpaces(spacesNum / (wordsNum - 1));
        var lastSpaces = makeSpaces(spacesNum - gapSpaces.Length * (wordsNum - 1));
        var res = "";
        for (int i = 0; i < wordsNum; i++)
        {
            var bAndE = beginAndEnd[i];
            res += text.AsSpan(bAndE.Key, bAndE.Value - bAndE.Key).ToString();
            if (1 == wordsNum - 1)
            {
                res += lastSpaces;
            }
            else
            {
                res += gapSpaces;
            }
        }
        return res;
    }
}
// @lc code=end

