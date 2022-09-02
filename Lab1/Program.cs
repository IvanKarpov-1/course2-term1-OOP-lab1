using System;

namespace Lab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.InputEncoding = System.Text.Encoding.Default;
            var application = new Application();
            application.Start();

            Console.ReadKey();
        }
    }
}