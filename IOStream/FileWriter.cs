using System;
using System.IO;

namespace IOStream
{
    public class FileWriter : IDisposable
    {
        private readonly string _path = PathContainer.Path;

        public FileWriter() { }
        public FileWriter(string path)
        {
            _path = path;
        }

        public void Write(string data, bool append)
        {
            using (var file = new StreamWriter(_path, append))
            {
                file.Write(data);
            }
        }

        public void Dispose() { }
    }
}
