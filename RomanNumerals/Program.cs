using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Roman Numerals convertor!");
            Console.WriteLine("Input [Q] to quit.");
            var sb = new StringBuilder();
            while (true)
            {
                Console.Write("Please input a number (1-3999):");
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    break;
                }
                int number = 0;
                Console.WriteLine();
                try
                {
                    number = Convert.ToInt32(input);
                    if (number < 1 || number > 3999)
                    {
                        number = 0;
                        throw new Exception("Number is out of range.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var romanNumbers = new Dictionary<int, char> { { 1, 'I' }, { 5, 'V' }, { 10, 'X' }, { 50, 'L' }, { 100, 'C' }, { 500, 'D' }, { 1000, 'M' } };

                int fourthDigit = (number % 10000) / 1000;
                switch (fourthDigit)
                {
                    case 1:
                    case 2:
                    case 3:
                        sb.Append(romanNumbers[1000], fourthDigit);
                        break;
                    default:
                        break;
                }

                int thirdDigit = (number % 1000) / 100;
                switch (thirdDigit)
                {
                    case 1:
                    case 2:
                    case 3:
                        sb.Append(romanNumbers[100], thirdDigit);
                        break;
                    case 4:
                        sb.Append(romanNumbers[100]);
                        sb.Append(romanNumbers[500]);
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        sb.Append(romanNumbers[500]);
                        sb.Append(romanNumbers[100], thirdDigit - 5);
                        break;
                    case 9:
                        sb.Append(romanNumbers[100]);
                        sb.Append(romanNumbers[1000]);
                        break;
                    default:
                        break;
                }

                int secondDigit = (number % 100) / 10;
                switch (secondDigit)
                {
                    case 1:
                    case 2:
                    case 3:
                        sb.Append(romanNumbers[10], secondDigit);
                        break;
                    case 4:
                        sb.Append(romanNumbers[10]);
                        sb.Append(romanNumbers[50]);
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        sb.Append(romanNumbers[50]);
                        sb.Append(romanNumbers[10], secondDigit - 5);
                        break;
                    case 9:
                        sb.Append(romanNumbers[10]);
                        sb.Append(romanNumbers[100]);
                        break;
                    default:
                        break;
                }

                int singleDigit = number % 10;
                switch (singleDigit)
                {
                    case 1:
                    case 2:
                    case 3:
                        sb.Append(romanNumbers[1], singleDigit);
                        break;
                    case 4:
                        sb.Append(romanNumbers[1]);
                        sb.Append(romanNumbers[5]);
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        sb.Append(romanNumbers[5]);
                        sb.Append(romanNumbers[1], singleDigit - 5);
                        break;
                    case 9:
                        sb.Append(romanNumbers[1]);
                        sb.Append(romanNumbers[10]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"Result: {number} == {sb.ToString()}");
                sb.Clear();

            }
        }
    }
}
