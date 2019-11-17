using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class String_Slipt
    {
        public static string[] Split_By_White_Space(this string @string)
        {
            var separator = new char[] { ' ' };
            string[] string_separated = @string.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return string_separated;
        }

        public static string[] Split_By_Capital_Letter(this string @string)
        {
            string first_part = @string.Substring(0, 1);
            string second_part = @string.Substring(1);
            string string_capital_separated = first_part;

            foreach (var letter in second_part)
            {
                if (char.IsUpper(letter)) string_capital_separated += " " + letter;
                else string_capital_separated += letter;
            }

            return Split_By_White_Space(string_capital_separated);
        }
    }
}