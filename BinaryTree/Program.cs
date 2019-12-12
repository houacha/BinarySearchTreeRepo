using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>() { 10, 8, 7, 9, 11, 12, 6 };
            binarySearchTree.Add(10);
            binarySearchTree.Add(8);
            binarySearchTree.Add(7);
            binarySearchTree.Add(9);
            binarySearchTree.Add(11);
            binarySearchTree.Add(12);
            binarySearchTree.Add(6);
            List<string> result = binarySearchTree.Search(9);
            //BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>() { "hi", "world", "i", "am", "testing", "this" };
            foreach (var item in binarySearchTree)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
