using PZ_4;
using static PZ_4.Node;

internal class Program
{
    public static void Main(string[] args)
    {
        DTreeNode root = null;
        Random rnd = new Random();
        Console.WriteLine("Значения узлов:");
        for (int i = 0; i < 15; i++)
        {
            int a = rnd.Next(-1000, 1000); //-1000, т.к нужно для тертьего задания
            root = SearchInTree.Add(root, (char)(' ' + i), a);
            Console.Write(a + " ");
        }
        Console.WriteLine("\nЗадание № 1");
        Console.WriteLine("Сумма сгенерированных узлов: " + SearchInTree.Sum(root));    

        Console.WriteLine("Задание № 2");
        Console.WriteLine("Кол-во внутренних узлов: " + SearchInTree.CountNodes(root));

        Console.WriteLine("Задание № 3");
        List<int> nNode = SearchInTree.CountNegNodes(root);
        Console.WriteLine("Отрицательные значения дерева:" + nNode.Count);
        foreach (int b in nNode)
        {
            Console.Write(b + " ");
        }
    }
}