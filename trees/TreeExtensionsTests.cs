using System;
using trees;
using Xunit;

namespace Trees
{
    public class TreeExtensionsTests
    {
        public class CheckBstTests
        {
            private Tree<int> _tree;

            public CheckBstTests()
            {
                _tree = new Tree<int>();

            }

            [Fact]
            public void ShouldReturnTrue_ForABinarySearchTree()
            {
                _tree.Insert(10);
                _tree.Insert(5);
                _tree.Insert(20);
                _tree.Insert(15);
                _tree.Insert(25);
                _tree.Insert(3);
                _tree.Insert(9);

                var isBst = _tree.CheckBst();

                Assert.True(isBst);
            }

            [Fact]
            public void ShouldReturnFalse_ForANonBinarySearchTree()
            {
                _tree.Insert(10);

                var root = _tree.Root;
                root.Left = new Node<int>(5);
                root.Left.Left = new Node<int>(30);

                _tree.Insert(20);

                var isBst = _tree.CheckBst();

                Assert.False(isBst);
            }
        }

        public class HeightTests
        {
            private readonly Tree<int> _tree;

            public HeightTests()
            {
                _tree = new Tree<int>();
            }

            [Fact]
            public void ShouldReturnZero_ForAnEmptyBst()
            {
                Assert.Equal(0, _tree.Height());
            }

            [Fact]
            public void ShouldReturnOne_ForATreeWithOnlyOneNode()
            {
                _tree.Insert(1);

                Assert.Equal(1, _tree.Height());
            }

            [Fact]
            public void ShouldReturnX_ForABstTree()
            {
                /*
                 *    (1)          10
                 *               /    \
                 *    (2)       5      20 
                 *             / \    /   \
                 *    (3)     3   9  15    25
                 */

                _tree.Insert(10);
                _tree.Insert(5);
                _tree.Insert(20);
                _tree.Insert(15);
                _tree.Insert(25);
                _tree.Insert(3);
                _tree.Insert(9);

                Assert.Equal(3, _tree.Height());
            }
        }

        public class PrintTests
        {
            private readonly Tree<int> _tree = new Tree<int>();

            [Fact]
            public void PrintTest()
            {
                _tree.Insert(10);
                _tree.Insert(5);
                _tree.Insert(20);
                _tree.Insert(15);
                _tree.Insert(25);
                _tree.Insert(3);
                _tree.Insert(9);

                _tree.Print();
            }
        }
    }
}