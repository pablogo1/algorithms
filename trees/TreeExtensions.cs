using System;
using System.Collections;

namespace Trees
{
    public static class TreeExtensions
    {
        public static bool CheckBst(this Tree<int> tree)
        {
            if(tree == null || tree.IsEmpty) {
                return true;
            }

            return tree.Root.CheckBst();
        }

        private static bool CheckBst(this Node<int> node)
        {
            return CheckBst(node, Int32.MinValue, Int32.MaxValue);
        }

        private static bool CheckBst(Node<int> node, int min, int max)
        {
            if(node == null) return true;
            if(node.Data < min || node.Data > max)
                return false;
            
            return CheckBst(node.Left, min, node.Data) && CheckBst(node.Right, node.Data, max);
        }
    }
}