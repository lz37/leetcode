/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */
namespace Leetcode.ReverseWordsInAString;

// @lc code=start
public class Solution
{
    // reverse a[] from a[i] to a[j]
    private void reverse(char[] a, int i, int j)
    {
        while (i < j)
        {
            var t = a[i];
            a[i++] = a[j];
            a[j--] = t;
        }
    }

    private void reverseWords(char[] a, int n)
    {
        var i = 0;
        var j = 0;
        while (i < n)
        {
            while (i < j || i < n && a[i] == ' ')
                i++; // skip spaces
            while (j < i || j < n && a[j] != ' ')
                j++; // skip non spaces
            reverse(a, i, j - 1); // reverse the word
        }
    }

    // trim leading, trailing and multiple spaces
    private string cleanSpaces(char[] a, int n)
    {
        var i = 0;
        var j = 0;
        while (j < n)
        {
            while (j < n && a[j] == ' ')
                j++; // skip spaces
            while (j < n && a[j] != ' ')
                a[i++] = a[j++]; // keep non spaces
            while (j < n && a[j] == ' ')
                j++; // skip spaces
            if (j < n)
                a[i++] = ' '; // keep only one space
        }
        return new string(a)[..i];
    }

    /// <summary>
    /// 58/58 cases passed (129 ms)
    /// Your runtime beats 64.52 % of csharp submissions
    /// Your memory usage beats 98.02 % of csharp submissions (36.2 MB)
    /// <see href="https://leetcode.com/problems/reverse-words-in-a-string/discuss/47720/Clean-Java-two-pointers-solution-(no-trim(-)-no-split(-)-no-StringBuilder)"/>
    /// 思路类似于字符串翻转
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseWords(string s)
    {
        if (s is null)
            return null;
        var a = s.ToCharArray();
        var n = a.Length;
        // step 1. reverse the whole string
        reverse(a, 0, n - 1);
        // step 2. reverse each word
        reverseWords(a, n);
        // step 3. clean up spaces
        return cleanSpaces(a, n);
    }
}

// @lc code=end
public class MySolution
{
    /// <summary>
    /// 58/58 cases passed (94 ms)
    /// Your runtime beats 83.17 % of csharp submissions
    /// Your memory usage beats 12.05 % of csharp submissions (38.8 MB)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseWords(string s)
    {
        var strArr = new List<string>();
        Array.ForEach(
            s.Split(" "),
            str =>
            {
                if (str != "")
                {
                    strArr.Add(str);
                }
            }
        );
        strArr.Reverse();
        return string.Join(" ", strArr);
    }
}
