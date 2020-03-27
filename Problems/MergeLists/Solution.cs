namespace Problems.MergeLists
{
    public static class Solution
    {
        public static SinglyLinkedList MergeLists (SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedList resultList = new SinglyLinkedList();

            while(head1 != null && head2 != null)
            {
                if (head1 != null && head1.Data <= head2.Data)
                {
                    resultList.Append(head1.Data);
                    head1 = head1.Next;
                } 
                else if (head2 != null)
                {
                    resultList.Append(head2.Data);
                    head2 = head2.Next;
                }
            }

            while (head1 != null)
            {
                resultList.Append(head1.Data);
                head1 = head1.Next;
            }

            while (head2 != null)
            {
                resultList.Append(head2.Data);
                head2 = head2.Next;
            }

            return resultList;
        }
    }
}
