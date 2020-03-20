using System;
using System.Diagnostics.CodeAnalysis;

namespace Problems.MyCalendar
{
    public class MyCalendar
    {
        private readonly Tree tree;

        public MyCalendar()
        {
            tree = new Tree();
        }

        public bool Book(int start, int end)
        {
            var interval = new Interval(start, end);

            return tree.Add(interval);
        }

        private class Tree
        {
            private IntervalNode rootNode;

            public bool Add(Interval interval)
            {
                if (rootNode == null)
                {
                    rootNode = new IntervalNode(interval);
                    return true;
                }

                return rootNode.Add(interval);
            }

            private class IntervalNode
            {
                public IntervalNode(Interval interval)
                {
                    Data = interval ?? throw new ArgumentNullException(nameof(interval));
                }

                public Interval Data { get; }
                public IntervalNode Left { get; set; }
                public IntervalNode Right { get; set; }

                public bool Add(Interval interval)
                {
                    int comparision = Compare(Data, interval);

                    if (comparision == 0)
                    {
                        return false; // the interval overlaps this node's interval
                    } else if (comparision < 0)
                    {
                        // the interval does not overlap but happens before current event
                        // if no node at the left, then add the interval node and return true
                        // to indicate the booking was successful
                        if (Left == null)
                        {
                            Left = new IntervalNode(interval);
                            return true;
                        }

                        // otherwise keep digging on the tree to insert on the left side.
                        return Left.Add(interval);
                    } else
                    {
                        // the interval does not overlap but happens after current event
                        // if no node at the right, then add the interval node and return true
                        // to indicate the booking was successful
                        if (Right == null)
                        {
                            Right = new IntervalNode(interval);
                            return true;
                        }

                        // otherwise keep digging on the tree to insert on the right side
                        return Right.Add(interval);
                    }

                }

                private int Compare(Interval interval1, Interval interval2)
                {
                    if (interval1 is null)
                    {
                        throw new ArgumentNullException(nameof(interval1));
                    }

                    if (interval2 is null)
                    {
                        throw new ArgumentNullException(nameof(interval2));
                    }

                    if (Math.Max(interval1.Start, interval2.Start) < Math.Min(interval1.End, interval2.End))
                    {
                        return 0; // these intervals overlap each other
                    }

                    if (interval2.Start >= interval1.End)
                    {
                        return -1;
                    }

                    if (interval1.Start >= interval2.End)
                    {
                        return 1;
                    }

                    throw new InvalidOperationException();
                }
            }
        }

        private class Interval 
        {
            public Interval(int start, int end)
            {
                if (start < 0)
                    throw new ArgumentOutOfRangeException(nameof(start));
                if (end < 0)
                    throw new ArgumentOutOfRangeException(nameof(end));
                if (end < start)
                    throw new ArgumentException($"End is expected to be greater than start.");

                Start = start;
                End = end;
            }

            public int Start { get; }
            public int End { get; }
        }
    }
}
