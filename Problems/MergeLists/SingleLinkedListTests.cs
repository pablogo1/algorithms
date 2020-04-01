using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.IO;

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

        [Fact(DisplayName = "FromArray_Returns_New_Linked_List_From_Array")]
        public void FromArray_Returns_New_Linked_List_From_Array()
        {
            int[] array = { 1, 2, 3, 4 };

            var actual = SinglyLinkedList.FromArray(array);

            actual.Should().NotBeNull();
            actual.Count.Should().Be(4);
            actual.Head.Data.Should().Be(1);
            actual.Tail.Data.Should().Be(4);
        }

        [Fact(DisplayName = "FromArray_Returns_New_Empty_Linked_List_From_Empty_Array")]
        public void FromArray_Returns_New_Empty_Linked_List_From_Empty_Array()
        {
            int[] array = { };

            var actual = SinglyLinkedList.FromArray(array);

            actual.Should().NotBeNull();
            actual.Count.Should().Be(0);
            actual.Head.Should().BeNull();
            actual.Tail.Should().BeNull();
        }

        [Fact(DisplayName = "FromArray_Throws_ArgumentNullException_When_Array_Is_Null")]
        public void FromArray_Throws_ArgumentNullException_When_Array_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SinglyLinkedList.FromArray(null);
            });
        }

        [Theory(DisplayName = "Print_Prints_List_To_Writer")]
        [InlineData(new int[] { }, " ", "[]")]
        [InlineData(new int[] { }, ",", "[]")]
        [InlineData(new int[] { 1, 2, 3 }, " ", "[1 2 3]")]
        [InlineData(new int[] { 1, 2, 3 }, ",", "[1,2,3]")]
        [InlineData(new int[] { 1 }, " ", "[1]")]
        [InlineData(new int[] { 1 }, ",", "[1]")]
        public void Print_Prints_List_To_Writer(int[] initArray, string sep, string expected)
        {
            var list = SinglyLinkedList.FromArray(initArray);

            using (var sw = new StringWriter())
            {
                list.Print(sw, sep);
                sw.ToString().Should().Be(expected);
            }
        }

        [Fact(DisplayName = "Append_Should_Insert_New_Node_At_End")]
        public void Append_Should_Insert_New_Node_At_End()
        {
            linkedList.Append(1);

            linkedList.Head.Should().NotBeNull();
            linkedList.Tail.Should().NotBeNull();
            linkedList.PreviousTail.Should().BeNull();
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(1);

            linkedList.Append(10);
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(10);
            linkedList.PreviousTail.Should().BeSameAs(linkedList.Head);
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
            linkedList.PreviousTail.Should().BeNull();
            linkedList.Head.Data.Should().Be(1);
            linkedList.Tail.Data.Should().Be(1);

            linkedList.Prepend(10);
            linkedList.Head.Data.Should().Be(10);
            linkedList.Tail.Data.Should().Be(1);
            linkedList.PreviousTail.Should().BeSameAs(linkedList.Head);

            linkedList.Prepend(29);
            linkedList.Head.Data.Should().Be(29);
            linkedList.Tail.Data.Should().Be(1);
            linkedList.PreviousTail.Data.Should().Be(10);
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

        [Fact(DisplayName = "RemoveLast_Should_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node" )]
        public void RemoveLast_Should_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node()
        {
            linkedList.Append(1);

            var removedNode = linkedList.RemoveLast();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(1);
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeSameAs(linkedList.Head);
        }

        [Fact(DisplayName = "RemoveLast_Should_Return_Null_When_List_Is_Empty")]
        public void RemoveLast_Should_Return_Null_When_List_Is_Empty()
        {
            var removedNode = linkedList.RemoveLast();

            removedNode.Should().BeNull();
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeNull();
        }

        [Fact(DisplayName = "RemoveLast_Should_Decrement_Count_By_One")]
        public void RemoveLast_Should_Decrement_Count_By_One()
        {
            linkedList.Append(1);
            linkedList.Append(2);

            var removedNode = linkedList.RemoveLast();

            linkedList.Count.Should().Be(1);
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
            linkedList.Head.Data.Should().Be(2);
            linkedList.Head.Should().NotBeSameAs(linkedList.Tail);
        }

        [Fact(DisplayName = "RemoveFirst_Should_Set_Head_And_Tail_The_Same_When_List_Has_Two_Nodes")]
        public void RemoveFirst_Should_Set_Head_And_Tail_The_Same_When_List_Has_Two_Nodes()
        {
            linkedList.Append(1);
            linkedList.Append(2);

            var removedNode = linkedList.RemoveFirst();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(1);
            linkedList.Head.Should().BeSameAs(linkedList.Tail);
            linkedList.Head.Next.Should().BeNull();
        }

        [Fact(DisplayName = "RemoveFirst_Should_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node")]
        public void RemoveFirst_Should_Set_Head_And_Tail_Null_When_List_Has_Only_One_Node()
        {
            linkedList.Append(1);

            var removedNode = linkedList.RemoveFirst();

            removedNode.Should().NotBeNull();
            removedNode.Data.Should().Be(1);
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeSameAs(linkedList.Head);
        }

        [Fact(DisplayName = "RemoveFirst_Should_Return_Null_When_List_Is_Empty")]
        public void RemoveFirst_Should_Return_Null_When_List_Is_Empty()
        {
            var removedNode = linkedList.RemoveFirst();

            removedNode.Should().BeNull();
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeNull();
        }

        [Fact(DisplayName = "RemoveFirst_Should_Decrement_Count_By_One")]
        public void RemoveFirst_Should_Decrement_Count_By_One()
        {
            linkedList.Append(1);
            linkedList.Append(2);

            var removedNode = linkedList.RemoveFirst();

            linkedList.Count.Should().Be(1);
        }

        [Fact(DisplayName = "Append_And_RemoveLast_Should_Set_Count_To_Zero")]
        public void Append_And_RemoveLast_Should_Set_Count_To_Zero()
        {
            linkedList.Append(1);
            linkedList.RemoveLast();

            linkedList.Count.Should().Be(0);
        }
    }
}
