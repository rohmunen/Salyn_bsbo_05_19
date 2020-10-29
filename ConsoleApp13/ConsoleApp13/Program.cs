using System;
using System.Linq;

namespace ConsoleApp13
{
    class Program
    {
        //()()(
        static void Main(string[] args)
        {
            Console.WriteLine(ValidParentheses("(())((()())())"));
        }
        public static bool ValidParentheses(string input)
        {
            if (input.Length == 0 || (!input.Contains("(")) || !input.Contains(")"))
            {
                return false;
            }
            int openingParantheses = 0;
            int closingParantheses = 0;
            foreach (var item in input)
            {
                if (item == '(')
                {
                    openingParantheses++;
                }
                if (item == ')')
                {
                    closingParantheses++;
                }
                if (openingParantheses < closingParantheses)
                {
                    return false;
                }
            }
            if (openingParantheses != closingParantheses)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
