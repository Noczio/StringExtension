using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StringExtension
{
    public static class String_Transform
    {
        public static string Capitalize(this string @string)
        {
            return @string.ToLower().Substring(0, 1).ToUpper() + @string.Substring(1).ToLower();
        }

        public static string Title(this string @string)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(@string.ToLower());
        }

        public static string Remove_Diacritics(this string @string)
        {
            var transfomation_dict = new Dictionary<string, string> { {"á","a"},
                {"é","e"},
                {"í","i"},
                {"ó","o"},
                {"ú","u"},
                {"ü","u"}
            };

            var string_separated = @string.Split_By_White_Space();
            string fixed_string = String.Empty;

            int string_separated_length = string_separated.Length;
            int counter = 0;
            foreach (var word in string_separated)
            {
                foreach (var letter in word)
                {
                    if (transfomation_dict.ContainsKey(letter.ToString()))
                    {
                        fixed_string += transfomation_dict[letter.ToString()];
                    }
                    else { fixed_string += letter; }
                }
                counter++;
                if (counter != string_separated_length - 1) { fixed_string += " "; }
            }

            return fixed_string;
        }
    }
}