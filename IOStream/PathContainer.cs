using System;

namespace IOStream
{
    public static class PathContainer
    {
        public static string Path { get; private set; } = AppDomain.CurrentDomain.BaseDirectory + "DB.txt";

        public static void SetPath(string path)
        {
            Path = path;
        }
    }
}