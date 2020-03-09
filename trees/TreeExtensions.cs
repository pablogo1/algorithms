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

        public static void Print<T>(this Tree<T> tree)
            where T : IComparable<T>
        {
            PrintNode(tree.Root);
        }

        private static void PrintNode<T>(Node<T> node, int direction = 0)
            where T : IComparable<T>
        {
            if(node == null) return;

            var directionStr = direction < 0 ? "  /  " : "   \\   ";
            if(direction == 0) directionStr = "";

            Console.WriteLine(directionStr);
            Console.WriteLine($"{node.Data}");

            PrintNode(node.Left, -1);
            PrintNode(node.Right, 1);
        }
    }
}
