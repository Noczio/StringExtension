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
        public static string Capitalize(this string @string) { return @string.ToLower().Substring(0, 1).ToUpper() + @string.Substring(1).ToLower(); }
        public static string Title(this string @string)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(@string.ToLower());
        }
        public static string Remove_Diacritics(string @string)
        {
            var transfomation_dict = new Dictionary<string, string> { {"á","a"},
                {"é","e"},
                {"í","i"},
                {"ó","o"},
                {"ú","u"},
                {"ü","u"}
            };

            var string_separated = String_Slipt.Split_By_White_Space(@string);
            string fixed_string = String.Empty;

          
            foreach (var word in string_separated.Select((data, indx) => new { Value = data, Index = indx }))
            {
                foreach (var letter in word.Value)
                {
                    if (transfomation_dict.ContainsKey(letter.ToString())) fixed_string += transfomation_dict[letter.ToString()];
                    else fixed_string += letter;
                }
                if (word.Index < string_separated.Length) fixed_string += " ";
            }                                                             

            return fixed_string;
        }

    }
}
