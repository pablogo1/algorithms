using System;
using Trees;

namespace trees
{
    public static class TreeExtensions
    {
        public static int Height<T>(this Tree<T> tree)
            where T : IComparable<T>
        {
            return Height(tree.Root);
        }

        private static int Height<T>(Node<T> root)
            where T : IComparable<T>
        {
            if (root == null) return 0;

            var leftHeight = Height(root.Left);
            var rightHeight = Height(root.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
