using System;
using System.Linq;
using Xunit;

namespace Trees
{
    public class TreeTests
    {
        public class InsertTests 
        {
            [Fact]
            public void ShouldSetRootNode_WhenTreeIsEmpty()
            {
                const int data = 5;
                var tree = new Tree<int>();

                tree.Insert(data);

                Assert.False(tree.IsEmpty);
                Assert.NotNull(tree.Root);
                Assert.Equal(data, tree.Root.Data);
            }

            [Fact]
            public void ShouldSetRootLeftNode_WhenDataIsLessThanRootData()
            {
                const int data = 5;
                var tree = new Tree<int>(10);

                tree.Insert(data);

                Assert.False(tree.IsEmpty);
                Assert.NotNull(tree.Root.Left);
                Assert.Equal(data, tree.Root.Left.Data);
            }

            [Fact]
            public void ShouldSetRootRightNode_WhenDataIsGreaterThanRootData()
            {
                const int data = 15;
                var tree = new Tree<int>(10);

                tree.Insert(data);

                Assert.False(tree.IsEmpty);
                Assert.NotNull(tree.Root.Right);
                Assert.Equal(data, tree.Root.Right.Data);
            }
        }

        public class TraverseTests
        {
            private Tree<int> _tree;

            public TraverseTests()
            {
                _tree = new Tree<int>(10);
                _tree.Insert(5);
                _tree.Insert(3);
                _tree.Insert(9);
                _tree.Insert(20);
                _tree.Insert(25);
                // _tree.Insert(15);
            }

            [Fact]
            public void ShouldTraverseTreeInOrder_WhenTraverseOrderIsInOrder()
            {
                //When
                var items = _tree.Traverse(TraverseOrder.InOrder);
                
                //Then
                Assert.Collection(items,
                    i => Assert.Equal(3, i),
                    i => Assert.Equal(5, i),
                    i => Assert.Equal(9, i),
                    i => Assert.Equal(10, i),
                    i => Assert.Equal(20, i),
                    i => Assert.Equal(25, i)
                );
            }

            [Fact]
            public void ShouldTraverseTreePostOrder_WhenTraverseOrderIsPostOrder()
            {
                //when
                var items = _tree.Traverse(TraverseOrder.PostOrder);

                //Then
                Assert.Collection(items,
                    i => Assert.Equal(3, i),
                    i => Assert.Equal(9, i),
                    i => Assert.Equal(5, i),
                    i => Assert.Equal(25, i),
                    i => Assert.Equal(20, i),
                    i => Assert.Equal(10, i)
                );
            }

            [Fact]
            public void ShouldTraverseTreePreOrder_WhenTraverseOrderIsPreOrder()
            {
                //When
                var items = _tree.Traverse(TraverseOrder.PreOrder);

                //Then
                Assert.Collection(items,
                    i => Assert.Equal(10, i),
                    i => Assert.Equal(5, i),
                    i => Assert.Equal(3, i),
                    i => Assert.Equal(9, i),
                    i => Assert.Equal(20, i),
                    i => Assert.Equal(25, i)
                );
            }
        }
    }
}
