using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Problems.MergeLists
{
    public class MyStackTests
    {
        private readonly MyStack stack = new MyStack();

        [Fact (DisplayName = "IsEmpty_Should_Return_True_When_Stack_Is_New")]
        public void IsEmpty_Should_Return_True_When_Stack_Is_New()
        {
            stack.IsEmpty.Should().BeTrue();
        }

        [Fact(DisplayName = "IsEmpty_Should_Return_True_When_Item_Is_Pushed")]
        public void IsEmpty_Should_Return_True_When_Item_Is_Pushed()
        {
            stack.Push(1);
            stack.IsEmpty.Should().BeFalse();

            stack.Push(2);
            stack.IsEmpty.Should().BeFalse();
        }

        [Fact(DisplayName = "IsEmpty_Should_Return_False_When_All_Items_Are_Popped")]
        public void IsEmpty_Should_Return_False_When_All_Items_Are_Popped()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Pop();
            stack.Pop();

            stack.IsEmpty.Should().BeTrue();
        }

        [Fact(DisplayName = "Push_Should_Put_Item_At_The_Top_Of_Stack")]
        public void Push_Should_Put_Item_At_The_Top_Of_Stack()
        {
            stack.Push(1);
            stack.Peek().Should().Be(1);

            stack.Push(2);
            stack.Peek().Should().Be(2);
        }

        [Fact(DisplayName = "Pop_Should_Remove_And_Return_Item_At_The_Top_Of_Stack")]
        public void Pop_Should_Remove_And_Return_Item_At_The_Top_Of_Stack()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Pop().Should().Be(2);
            stack.Pop().Should().Be(1);
        }

        [Fact(DisplayName = "Pop_Should_Throw_InvalidOperationException_When_Stack_Is_Empty")]
        public void Pop_Should_Throw_InvalidOperationException_When_Stack_Is_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact(DisplayName = "Peek_Should_Return_Item_At_The_Top_Of_Stack_And_Keep_It")]
        public void Peek_Should_Return_Item_At_The_Top_Of_Stack_And_Keep_It()
        {
            stack.Push(1);
            stack.Peek().Should().Be(1);

            stack.Push(2);
            stack.Peek().Should().Be(2);
        }

        [Fact(DisplayName = "Peek_Should_Throw_InvalidOperationException_When_Stack_Is_Empty")]
        public void Peek_Should_Throw_InvalidOperationException_When_Stack_Is_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
