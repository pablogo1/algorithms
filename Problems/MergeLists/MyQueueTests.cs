using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.MergeLists
{
    public class MyQueueTests
    {
        private readonly MyQueue myQueue;

        public MyQueueTests()
        {
            myQueue = new MyQueue();
        }

        [Fact(DisplayName = "New_MyQueue_Should_Be_Empty")]
        public void New_MyQueue_Should_Be_Empty()
        {
            myQueue.IsEmpty.Should().BeTrue();
        }

        [Fact(DisplayName = "Enqueue_Should_Put_Item_At_End_Of_Queue")]
        public void Enqueue_Should_Put_Item_At_End_Of_Queue()
        {
            myQueue.Enqueue(1);
            myQueue.Peek().Should().Be(1);

            myQueue.Enqueue(2);
            myQueue.Peek().Should().Be(1);
        }

        [Fact(DisplayName = "Dequeue_Should_Return_Item_At_The_Head_Of_Queue_And_Remove_It")]
        public void Dequeue_Should_Return_Item_At_The_Head_Of_Queue_And_Remove_It()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);

            myQueue.Dequeue().Should().Be(1);
            myQueue.Peek().Should().Be(2);
        }

        [Fact(DisplayName = "Dequeue_Should_Throw_InvalidOperationException_When_Queue_Is_Empty")]
        public void Dequeue_Should_Throw_InvalidOperationException_When_Queue_Is_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => myQueue.Dequeue());
        }

        [Fact(DisplayName = "Peek_Should_Return_Item_At_The_Head_Of_Queue_But_Keeps_It_On_Queue")]
        public void Peek_Should_Return_Item_At_The_Head_Of_Queue_But_Keeps_It_On_Queue()
        {
            myQueue.Enqueue(1);

            myQueue.Peek().Should().Be(1);
            myQueue.Peek().Should().Be(1);

            myQueue.Enqueue(2);
            myQueue.Peek().Should().Be(1);
        }

        [Fact(DisplayName = "Peek_Should_Throw_InvalidOperationException_When_Queue_Is_Empty")]
        public void Peek_Should_Throw_InvalidOperationException_When_Queue_Is_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => myQueue.Peek());
        }

        [Fact(DisplayName = "IsEmpty_Should_Return_False_After_Item_Has_Been_Enqueued")]
        public void IsEmpty_Should_Return_False_After_Item_Has_Been_Enqueued()
        {
            myQueue.Enqueue(1);

            myQueue.IsEmpty.Should().BeFalse();

            myQueue.Dequeue();
            myQueue.Enqueue(2);

            myQueue.IsEmpty.Should().BeFalse();
        }

        [Fact(DisplayName = "IsEmpty_ShouldReturn_True_After_All_Items_Had_Been_DeQueued")]
        public void IsEmpty_ShouldReturn_True_After_All_Items_Had_Been_DeQueued()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);

            myQueue.Dequeue();
            myQueue.Dequeue();

            myQueue.IsEmpty.Should().BeTrue();
        }
    }
}
