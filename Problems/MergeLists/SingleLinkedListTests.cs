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

        [Fact]
        public void New_Linked_List_Is_Empty()
        {
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeNull(); 
            linkedList.Count.Should().Be(0);
        }

        [Fact]
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

        [Fact]
        public void Append_Should_Increment_Count_By_One()
        {
            linkedList.Append(1);
            linkedList.Count.Should().Be(1);
            linkedList.Append(10);
            linkedList.Count.Should().Be(2);
        }

        [Fact]
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

        [Fact]
        public void Prepend_Should_Increment_Count_By_One()
        {
            linkedList.Prepend(1);
            linkedList.Count.Should().Be(1);
            linkedList.Prepend(10);
            linkedList.Count.Should().Be(2);
        }

        [Fact]
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

        //[Fact]
        //public void RemoveLast_Should_Return_And_Remove
    }
}
