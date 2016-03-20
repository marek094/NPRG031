using System;

namespace Lesson03HomeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode();
            tree.TestInit();

            tree.Print();
           
            Console.WriteLine(tree.Contains(50));
            Console.WriteLine(tree.Contains(10));

            tree.Add(40);
            tree.Add(30);
            tree.Add(1);
            //tree.Add(3);
            //tree.Add(2);

            tree.Print();

            Console.WriteLine(tree.Contains(70));  

            Console.WriteLine(tree.Remove(10));
            tree.Print();
            Console.WriteLine(tree.Remove(50));
            tree.Print();

            /*
            contains = tree.Contains(10);
            if (contains)

                throw new Exception("Contains is true, but item was removed.");
            find = tree.Find(10);
            if (find != null)
                throw new Exception("Item was removed.");
            //*/
            Console.ReadKey();
        }
    }
}
