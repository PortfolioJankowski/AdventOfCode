
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;

public class Solution
{
    public int SecondStar()
    {
        int result = 0;
        using (StreamReader stream = new StreamReader("C:\\Users\\Mateusz\\Desktop\\data.txt"))
        {  
            string dataRow = stream.ReadLine();
            while (dataRow != null)
            {
                List<int> rowDigits = GetDigits(dataRow);
                if (rowDigits.Count == 1)
                {
                    int x = rowDigits[0];
                    rowDigits.Add(x);
                }
                result += rowDigits.First() * 10 + rowDigits.Last();
                Console.WriteLine(result);

                dataRow = stream.ReadLine();
            }
            return result;
        }
    }

    public List<int> GetDigits(string input)
    {
        Dictionary<string, int> DigitsDict = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };
        var output = new List<int>();
       
        char[] charInput = input.ToCharArray();
        for (int i = 0; i<charInput.Count(); i++)
        {
            if (int.TryParse(charInput[i].ToString(), out int result))
            {
                output.Add(result);               
            }
            else
            {
                if (charInput.Length - i >= 5)
                {
                    string fiveLettersDigit = charInput[i].ToString() + charInput[i + 1].ToString() + charInput[i + 2].ToString() + charInput[i + 3].ToString() + charInput[i + 4].ToString();
                    if (fiveLettersDigit == "three"
                        || fiveLettersDigit == "seven"
                        || fiveLettersDigit == "eight")
                    {
                        output.Add(DigitsDict[fiveLettersDigit]);
                        
                        continue;
                    }

                }
                if (charInput.Length - i >= 4)
                {
                    string fourLettersDigit = charInput[i].ToString() + charInput[i + 1].ToString() + charInput[i + 2].ToString() + charInput[i + 3].ToString();
                    if (fourLettersDigit == "four"
                        || fourLettersDigit == "five"
                        || fourLettersDigit == "nine")
                    {
                        output.Add(DigitsDict[fourLettersDigit]);
                        
                        continue;
                    }
                }
                if (charInput.Length - i >= 3)
                {
                    string threeLetterDigit = charInput[i].ToString() + charInput[i + 1].ToString() + charInput[i + 2].ToString();

                    if (threeLetterDigit == "one"
                        || threeLetterDigit == "two"
                        || threeLetterDigit == "six")
                    {
                        output.Add(DigitsDict[threeLetterDigit]);
                        
                        continue;
                    }
                }
            }                
        }
        return output;
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.SecondStar());
        }
    }
}