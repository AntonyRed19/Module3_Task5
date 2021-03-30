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

        public async Task<string> HelloAsync()
        {
            var a = File.ReadAllTextAsync(_path);
            return await a;
        }

        public async Task<string> WorldAsync()
        {
            return await Task.FromResult(_text1);
        }

        public async Task ListofAsync()
        {
             await HelloAsync();
             await WorldAsync();
             await Task.Run(() => _text + _text1);
        }

        public async Task<string> ListofMethodsAsync()
        {
            var list = new List<Task>();
            list.Add(Task.Run(async () =>
            {
                return await File.ReadAllTextAsync(_path);
            }));
            list.Add(Task.Run(async () =>
            {
                return await Task.FromResult(_text1);
            }));
            await Task.WhenAll(list);
            return await Task.Run(() => _text + _text1);
        }
    }
}