using System;
using System.Collections;

namespace Problems.Atoi
{
    public class Solution
    {
        /* Main Questions:
        1. Can the input string contain whitespaces at both beginning or end?
            A: Yes. Ignore all whitespaces at the beginning only. Only ' ' is considered a whitespace.
        2. Can the input string contain any other non-numerical characters?
            A: Yes, you can expect non-numerical characters. But for conversion to be valid, the first sequence of chars has to be a valid integer value (ie. no words or any other char except '+' or '-')
        3. What do we expect from the function if we encounter such characters?
            A: Just ignore them. They will not affect the result.
        4. It needs to return an int. So I assume we're dealing with 32-bit integers. right?
            A: Yes.
        5. Will it always include the sign at the beginning? If not, do we assume the result will be a positive number?
            A: Yes. The sign is optional. Default will be +.
        6. What about if the number is out-of-range?
            A: You will either return INT_MAX (2^31 - 1) for positive values or INT_MIN (-2^31) for negative ones.
        7. What if the input string has no valid number (ie. string is empty or has no numbers)?
            A: No conversion is performed. Return Zero.
        */
        public int MyAtoi(string str)
        {
            // let's define INT_MAX and INT_MIN
            const int INT_MAX = Int32.MaxValue;
            const int INT_MIN = Int32.MinValue;

            if (str.Length == 0)
            {
                return 0;
            }

            int sign = 1;
            int i = 0;
            int result = 0;

            // discard as many whitespaces are found.
            while (i < str.Length && str[i] == ' ') i++;

            if (i < str.Length && (str[i] == '-' || str[i] == '+'))
            {
                sign = str[i] == '-' ? -1 : 1;
                i++;
            }
            // discard as many leading zeroes are found
            while (i < str.Length && str[i] == '0') i++;

            while (i < str.Length)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    if (result > (INT_MAX / 10) || (result == INT_MAX / 10 && str[i] - '0' > 7))
                    {
                        return sign == -1 ? INT_MIN : INT_MAX;
                    }
                    result = (result * 10) + str[i] - '0';
                }
                else
                {
                    break;
                }

                i++;
            }

            return result * sign;
        }

        public int MyAtoi2(string str)
        {
            return MyAtoiRecursive(str, str.Length - 1);
        }

        private int MyAtoiRecursive(string str, int i)
        {
            int sign = 0;
            
            if (str[i] == '+' || str[i] == '-')
            {
                sign = str[i] == '-' ? -1 : 1;
                return (str[i + 1] - '0');
            }
            if (i == 0)
                return 0;

            if (IsDigit(str[i]))
            {
                int result = (10 * MyAtoiRecursive(str, i - 1) + str[i] - '0');
                return result * sign;
            }
            
            return MyAtoiRecursive(str, i - 1);
            

            //int result = (10 * MyAtoiRecursive(str, i - 1) + str[i] - '0');
            //return result;
            //return result * sign;
        }

        private bool IsDigit(char chr) => chr >= '0' && chr <= '9';
    }
}