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
            // let's define valid digits: 0-9
            // let's define valid chars: +,-
            // remove whitespaces

            int isPositive = 0;
            Stack stack = new Stack();
            int i = 0;
            int result = 0;

            // discard as many whitespaces are found.
            while (str[i] == ' ' && i < str.Length) i++;

            while (i < str.Length)
            {
                if (str[i] == '+' || str[i] == '-')
                {
                    if (isPositive == 0)
                    {
                        isPositive = str[i] == '+' ? 1 : -1;
                    }
                    else
                    {
                        Console.WriteLine($"Conversion is not valid. Current i = {i}; str[i] = {str[i]}");
                        return 0; // conversion is not valid.
                    }
                    i++;
                    continue;
                }
                // discard as many leading zeroes are found
                while (str[i] == '0' && i < str.Length) i++;

                if (str[i] >= 48 && str[i] <= 57)
                { //ascii codes for '0' and '9'
                    stack.Push(str[i] - 48);
                }
                else
                {
                    break;
                }
                i++;
            }

            int decimalPlace = 0;
            while (stack.Count > 0)
            {
                result += Convert.ToInt32(stack.Pop()) * (int)Math.Pow(10, decimalPlace);
                if (result > INT_MAX) return INT_MAX;
                if (result < INT_MIN) return INT_MIN;
                decimalPlace++;
            }
            isPositive = isPositive == 0 ? 1 : isPositive;
            result *= isPositive;

            return result;
        }
    }
}