
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;

public class Solution
{
    public int SecondDay()
    {
        int r = 12;
        int g = 13;
        int b = 14;

        int result = 0;

        
        string[] allLines = File.ReadAllLines("C:\\Users\\Mateusz\\Desktop\\data.txt");
        foreach (string dataRow in allLines)
        {
            var rgb = GetNumbers(dataRow.Split(":").Last());
            int temp = rgb[0] * rgb[1] * rgb[2];
            result = result + temp;
            
        }
        return result;
    }

    public int[] GetNumbers(string input)
    {
        int rCheck = 0;
        int gCheck = 0;
        int bCheck = 0;

        var output = new int[3];
        var games = input.Split(";");
        foreach (var game in games)
        {
            var gameNoSpaces = game.Replace(",", "").Split(" ");
            var counter = 0;
            foreach (var word in gameNoSpaces)
            {
                if (word == "blue")
                {
                    var parsedB = int.TryParse(gameNoSpaces[counter - 1], out int result);
                    if (bCheck == 0)
                    {
                        bCheck = result;
                    }
                    else if (result > bCheck)
                    {
                        bCheck = result;
                    }    
                }
                if (word == "red")
                {
                    var parsedR = int.TryParse(gameNoSpaces[counter - 1], out int result);
                    if (rCheck == 0)
                    {
                        rCheck = result;
                    }
                    else if (result > rCheck)
                    {
                        rCheck = result;
                    }

                }
                if (word == "green")
                {
                    var parsedG = int.TryParse(gameNoSpaces[counter - 1], out int result);
                    if (gCheck == 0)
                    {
                        gCheck = result;
                    }
                    else if (result > gCheck)
                    {
                        gCheck = result;
                    }
                }
                counter++;
            }
        }
        output[0] = rCheck;
        output[1] = gCheck;
        output[2] = bCheck;

        return output;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.SecondDay());
        }
    }
}