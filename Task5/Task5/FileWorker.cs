using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class FileWorker
    {
        private readonly string _path = "1.txt";
        private readonly string _text = "Hello";
        private readonly string _text1 = "World";
        public void CreateFile()
        {
            File.WriteAllText(_path, _text);
        }

        public async Task<string> ListofMethodsAsync()
        {
            var list = new List<Task<string>>();
            list.Add(Task.Run(() => File.ReadAllTextAsync(_path)));
            list.Add(Task.Run(() => _text1));
            var result = await Task.WhenAll(list);
            return string.Join(" ", result);
        }
    }
}