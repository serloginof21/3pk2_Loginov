using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_3
{
    public class Node
    {
        public int Info { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node() { }
        public Node(int info) { Info = info; }
        public Node(int info, Node left, Node right)
        {
            Info = info;
            Left = left;
            Right = right;
        }
        public double AllRootSum(Node root)
        {
            double sum = 0;
            if (root == null) { return 0; }
            else
            {
                sum += root.Info;
                sum += AllRootSum(root.Left);
                sum += AllRootSum(root.Right);
            }
            return sum;
        }
        public double GetAverage(int sizeRoot)
        {
            double AverSum = AllRootSum(this) / sizeRoot;
            return AverSum;
        }
        private int TrueRoot;
        private int FalseRoot;
        public void CountTrueRoot(Node root)
        {
            if (root != null)
            {
                if (root.Info > 0)
                {
                    this.TrueRoot++;
                }
                CountTrueRoot(root.Left);
                CountTrueRoot(root.Right);
            }
        }
        public int CountTRoot
        {
            get
            {
                CountTrueRoot(this);
                return TrueRoot;
            }
            set { }
        }

        public void CountFalseRoot(Node root)
        {
            if (root != null)
            {
                if (root.Info < 0)
                {
                    this.FalseRoot++;
                }
                CountFalseRoot(root.Left);
                CountFalseRoot(root.Right);
            }
        }
        public int CountFRoot
        {
            get { CountFalseRoot(this); return FalseRoot; }
            set { }
        }

        public int FindNumberRoot(Node root, int FindRoot)
        {
            int count = 0;
            if (root != null)
            {
                if(root.Info == FindRoot)
                {
                    count++;
                }
                count = count + FindNumberRoot(root.Left, FindRoot);
                count = count + FindNumberRoot(root.Right, FindRoot);
            }
            return count;
        }
    }
}