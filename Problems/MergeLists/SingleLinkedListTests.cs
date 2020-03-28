using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Problems.MergeLists
{
    public class SingleLinkedListTests
    {
        private readonly SinglyLinkedList linkedList;

        public SingleLinkedListTests()
        {
            linkedList = new SinglyLinkedList();
        }

        [Fact(DisplayName = "New_Linked_List_Is_Empty")]
        public void New_Linked_List_Is_Empty()
        {
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeNull(); 
            linkedList.Count.Should().Be(0);
        }

        [Fact(DisplayName = "Append_Should_Insert_New_Node_At_End")]
        public void Append_Should_Insert_New_Node_At_End()
        {
            linkedList.Append(1);

            linkedList.Head.Should().NotBeNull();
            linkedList.Tail.Should().NotBeNull();
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(1);

            linkedList.Append(10);
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(10);
        }

        [Fact(DisplayName = "Append_Should_Increment_Count_By_One")]
        public void Append_Should_Increment_Count_By_One()
        {
            linkedList.Append(1);
            linkedList.Count.Should().Be(1);
            linkedList.Append(10);
            linkedList.Count.Should().Be(2);
        }

        [Fact(DisplayName = "Prepend_Should_Insert_New_Node_At_Beginning")]
        public void Prepend_Should_Insert_New_Node_At_Beginning()
        {
            linkedList.Prepend(1);

            linkedList.Head.Should().NotBeNull();
            linkedList.Tail.Should().NotBeNull();
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(1);

            linkedList.Prepend(10);
            linkedList.Head.Data.Should().Be(10);
            linkedList.Tail.Data.Should().Be(1);
        }

        [Fact(DisplayName = "Prepend_Should_Increment_Count_By_One")]
        public void Prepend_Should_Increment_Count_By_One()
        {
            linkedList.Prepend(1);
            linkedList.Count.Should().Be(1);
            linkedList.Prepend(10);
            linkedList.Count.Should().Be(2);
        }

        [Fact(DisplayName = "RemoveLast_Should_Return_And_Remove_The_Last_Node")]
        public void RemoveLast_Should_Return_And_Remove_The_Last_Node()
        {
            linkedList.Append(1);
            linkedList.Append(2);
            linkedList.Append(3);

            var actual = linkedList.RemoveLast();

            actual.Should().NotBeNull();
            actual.Data.Should().Be(3);
            linkedList.Count.Should().Be(2);
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(2);
            linkedList.Tail.Next.Should().BeNull();
        }

        [Fact(DisplayName = "RemoveLast_Should_Set_Head_And_Tail_The_Same_When_List_Has_Two_Nodes")]
        public void RemoveLast_Should_Set_Head_And_Tail_The_Same_When_List_Has_Two_Nodes()
        {
            linkedList.Append(1);
            linkedList.Append(2);

            var removedNode = linkedList.RemoveLast();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(2);
            linkedList.Head.Should().BeSameAs(linkedList.Tail);
            linkedList.Head.Next.Should().BeNull();
        }

        [Fact(DisplayName = "RemoveLast_Shoud_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node" )]
        public void RemoveLast_Should_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node()
        {
            linkedList.Append(1);

            var removedNode = linkedList.RemoveLast();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(1);
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeSameAs(linkedList.Head);
        }

        [Fact(DisplayName = "RemoveFirst_Should_Return_And_Remove_The_First_Node")]
        public void RemoveFirst_Should_Return_And_Remove_The_First_Node()
        {
            linkedList.Append(1);
            linkedList.Append(2);
            linkedList.Append(3);

            var removedNode = linkedList.RemoveFirst();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(1);
            linkedList.Head.Should().NotBeNull();
        }

        //[Fact]
        //public void RemoveLast_Should_Return_And_Remove
    }
}
