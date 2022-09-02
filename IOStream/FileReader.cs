using System;
using System.IO;

namespace IOStream
{
    public class FileReader : IDisposable
    {
        private readonly string _path = PathContainer.Path;

        public FileReader()
        {
        }

        public FileReader(string path)
        {
            _path = path;
        }

        public string Read()
        {
            string text;
            using (var file = new StreamReader(_path))
            {
                text = file.ReadToEnd();
            }

            return text;
        }

        public void Dispose()
        {
        }
    }
}