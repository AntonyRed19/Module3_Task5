using System;

namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fw = new FileWorker();
            fw.CreateFile();
            fw.ListofMethods()
                .GetAwaiter().GetResult();
        }
    }
}
