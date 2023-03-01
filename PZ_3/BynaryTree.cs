using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_3
{
    public class BynaryTree
    {
        public Node Root { get; set; }

        public BynaryTree(int n)
        {
            Root = CreateBalancedTree(n);
        }

        public Node CreateBalancedTree(int n)
        {
            int text;
            Node root;

            if (n == 0)
                root = null;
            else
            {
                Console.WriteLine("enter data>>");
                text = Convert.ToInt32(Console.ReadLine());

                root = new Node(text);
                root.Left = CreateBalancedTree(n / 2);
                root.Right = CreateBalancedTree(n - n / 2 - 1);
            }
            return root;
        }

        public static void GetTreeData(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Info);
                GetTreeData(root.Left);
                GetTreeData(root.Right);
            }
        }
    }
}
