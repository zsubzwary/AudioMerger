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
            Console.WriteLine(Directory.GetCurrentDirectory());
            
            Console.WriteLine();
            foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine(item);
            }
        }
    }
}
