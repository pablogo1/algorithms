using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Problems.MergeLists
{
    public class SinglyLinkedListComparer : IEqualityComparer<SinglyLinkedList>
    {
        public bool Equals([AllowNull] SinglyLinkedList x, [AllowNull] SinglyLinkedList y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] SinglyLinkedList obj)
        {
            return obj.GetHashCode();
        }
    }
}
