﻿using System;

namespace PL
{
    public class ConsoleMenu
    {
        public static void WriteItem(string item) => Console.WriteLine($"{item}");
        public static string ReadItem() => Console.ReadLine();
        public static string ReadItem(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static void ReadItemError() => Console.WriteLine("Значення не вірне. Будь ласка, спробуйте ще раз.");
        public static void Clear() => Console.Clear();
    }
}