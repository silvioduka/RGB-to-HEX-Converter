/*
RGB to HEX Converter from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-12 

RGB colors are represented as triplets of numbers in the range of 0-255, representing the red, green and blue components of the resulting color. 

Each RGB color has a corresponding hexadecimal value, which is expressed as a six-digit combination of numbers and letters and starts with the # sign. The numbers and letters in a hex value can be in the range [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F]. 

The hexadecimal is basically a base 16 representation of the RGB value, which is a base 10 value. 

Write a program that takes an RGB color value as input and converts it to its Hexadecimal equivalent. 

For Example: 
Input: (66, 134, 244) 
Hex equivalent: #4286f4 

Input: (119, 119, 119) 
Hex equivalent: #777777 or #777 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBToHEXConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string rgbColor = "(66, 134, 244)"; // Insert a RGB colors as triplets of numbers in the range of 0-255

            Console.WriteLine($"Input: {rgbColor}");
            Console.WriteLine($"Hex equivalent: {RGBtoHEX(rgbColor)}");
        }

        static string RGBtoHEX(string color)
        {
            color = color.Replace(',', ' ').Replace('(', ' ').Replace(')', ' ');

            string[] rgb = color.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (rgb.Length != 3) { return "Wrong RGB format!!"; }
            
            int r, g, b;

            bool t = true;
            t &= Int32.TryParse(rgb[0], out r);
            t &= Int32.TryParse(rgb[1], out g);
            t &= Int32.TryParse(rgb[2], out b);

            if (t == false) { return "Wrong RGB values!!"; }

            return String.Format($"#{ToHEX(r)}{ToHEX(g)}{ToHEX(b)}");
        }

        static string ToHEX(int number)
        {
            if (number < 0 || number > 255) return "ER";

            string digits = "0123456789abcdef";
            string result = "";

            while (number > 0)
            {
                result = digits.Substring((int)(number % 16), 1) + result;

                number /= 16;
            }

            return result.PadLeft(2, '0');
        }
    }
}