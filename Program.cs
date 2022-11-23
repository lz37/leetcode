namespace Leetcode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var solution = new BasicCalculator.Solution();
            var res = solution.Calculate("(1+(4+5+2)-3)+(6+8)");
            Console.WriteLine(res);
        }
    }
}