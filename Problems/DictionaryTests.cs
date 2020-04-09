using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Problems
{
    public class DictionaryTests
    {
        private readonly ITestOutputHelper output;

        public DictionaryTests(ITestOutputHelper output)
        {
            this.output = output ?? throw new ArgumentNullException(nameof(output));
        }

        [Fact(DisplayName = "Dictionary_Keeps_Keys_In_Order")]
        public void Dictionary_Keeps_Keys_In_Order_Of_Insertion()
        {
            var dict = new Dictionary<int, int>();
            dict.Add(1, 1);
            dict.Add(4, 1);
            dict.Add(2, 1);
            dict.Add(3, 1);

            int[] orderedKeys = { 1, 4, 2, 3 };
            int index = 0;
            foreach(var key in dict.Keys)
            {
                output.WriteLine($"{key} = {dict[key]}");
                key.Should().Be(orderedKeys[index++]);
            }
        }
    }
}
