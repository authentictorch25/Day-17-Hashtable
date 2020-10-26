using System;

namespace HashsetsAndBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<string, string> mapNode = new MyMapNode<string, string>(5);
            Console.WriteLine("Adding KeyValue pair");
            mapNode.Add("0", "To");
            mapNode.Add("1", "be");
            mapNode.Add("2", "or");
            mapNode.Add("3", "not");
            mapNode.Add("4", "to");
            mapNode.Add("5", "be");
            Console.WriteLine("Getting the value of index 1: " + mapNode.Get("1"));
            Console.WriteLine("Getting the value of index 4: " + mapNode.Get("4"));
            mapNode.GetFrequencyOf("to");
            Console.ReadLine();

        }
    }
}
