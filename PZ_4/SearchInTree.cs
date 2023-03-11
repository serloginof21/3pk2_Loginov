using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PZ_4.Node;

namespace PZ_4
{
    internal class SearchInTree
    {
        public static DTreeNode Add(DTreeNode Node, char info, int key)
        {
            if (Node == null) return new DTreeNode(info, key);
            else if (key < Node.Key) Node.Left = Add(Node.Left, info, key);
            else Node.Right = Add(Node.Right, info, key);
            return Node;
        }
        public static int Sum(DTreeNode Node)
        {
            if (Node == null) return 0;
            return Node.Key + Sum(Node.Left) + Sum(Node.Right);
        }
        public static int CountNodes(DTreeNode Node)
        {
            if (Node == null) return 0;
            else if (Node.Left == null && Node.Right == null) return 0;
            else return  CountNodes(Node.Left) + CountNodes(Node.Right) + 1;
        }
        public static List<int> CountNegNodes(DTreeNode Node)
        {
            List<int> res = new List<int>();
            if (Node == null) return res;
            if (Node.Key < 0) res.Add(Node.Key);
            res.AddRange(CountNegNodes(Node.Left));
            res.AddRange(CountNegNodes(Node.Right));
            return res;
        }
    }
}