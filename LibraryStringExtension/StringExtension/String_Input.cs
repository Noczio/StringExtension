using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public interface IIsNullOrEmpty
    {
        bool Is_Null_Or_Empty(string @string);
    }

    public class String_Input : IIsNullOrEmpty
    {
        #region Properties

        private string str;

        public string input
        {
            get { return str; }
            set { if (Is_Null_Or_Empty(value)) str = String.Empty; else str = value; }
        }

        #endregion Properties

        #region Constructor & destructor

        public String_Input()
        {
            input = String.Empty;
        }

        public String_Input(string @string)
        {
            input = @string;
        }

        ~String_Input()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion Constructor & destructor

        #region Interface implementation

        /// <summary>
        /// Gets a string as parameter and verifies if it is null or empty
        /// </summary>
        /// <param name="string"></param>
        /// <returns>true or false</returns>
        public bool Is_Null_Or_Empty(string @string)
        {
            return string.IsNullOrEmpty(@string) == true;
        }

        #endregion Interface implementation

        #region Methods

        /// <summary>
        /// Changes the displayed text on screen depending on the given message name=custom_message
        /// This method repeats itself until a string is given as input
        /// This method also works as a setter
        /// </summary>
        /// <param name="custom_message"></param>
        public string Get_Input(string custom_message)
        {
            bool ext_condition = true;
            string temp_input = String.Empty;

            do
            {
                if (ext_condition) Console.Write($"Write down {custom_message}: ");
                else Console.Write($"You didn't Write down {custom_message}, write it down again: ");

                temp_input = Console.ReadLine();

                if (Is_Null_Or_Empty(temp_input)) ext_condition = false;
                else input = temp_input; ext_condition = true;
            } while (ext_condition == false);

            return input;
        }

        #endregion Methods
    }
}