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
        private readonly string _path = "../1.txt";
        private readonly string _text = "Hello";
        private readonly string _text1 = "World";
        public string ConcatText()
        {
            var newtext = _text + _text1;
            return newtext;
        }

        public async Task<string> ListofMethods()
        {
            var list = new List<Task>();
            list.Add(Task.Run(async () =>
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    return await sr.ReadToEndAsync();
                }
            }));
            list.Add(Task.Run(async () =>
            {
                return await Task.Run(() => _text1);
            }));
            Task.WhenAll(list).GetAwaiter().GetResult();
            return await Task.Run(() => ConcatText());
        }
    }
}
