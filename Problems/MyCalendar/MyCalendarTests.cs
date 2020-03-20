using System;
using Xunit;

namespace Problems.MyCalendar
{
    public class MyCalendarTests
    {
        private readonly MyCalendar myCalendar;

        public MyCalendarTests()
        {
            myCalendar = new MyCalendar();
        }

        [Fact]
        public void CanBookEvent_WhenFirstEvent()
        {
            var result = myCalendar.Book(10, 20);

            Assert.True(result);
        }

        [Fact]
        public void CanBookEvent_WhenEventIsPriorToExistingOne()
        {
            myCalendar.Book(10, 20);

            var result = myCalendar.Book(5, 10);

            Assert.True(result);
        }

        [Fact]
        public void CanBookEvent_WhenEventIsAfterToExistingOne()
        {
            myCalendar.Book(10, 20);

            var result = myCalendar.Book(30, 40);

            Assert.True(result);
        }

        [Fact]
        public void CannotBookEvent_WhenEventOverlapsExistingEvent()
        {
            myCalendar.Book(10, 20);
            myCalendar.Book(5, 10);
            myCalendar.Book(30, 40);

            var result = myCalendar.Book(15, 30);

            Assert.False(result);
        }
    }
}
