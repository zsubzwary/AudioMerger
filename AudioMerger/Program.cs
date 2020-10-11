using System;
using System.IO;
using System.Reflection;

namespace AudioMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}
