using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AudioMerger
{
    class Program
    {
        public static List<String> listA = new List<String>();
        public static List<String> listB = new List<String>();


        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");


            Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            Console.WriteLine(Directory.GetCurrentDirectory());
            
            Console.WriteLine();
            foreach (string item in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                //Console.WriteLine(item); //this is full path of each file
                var fileName = item.Split(@"\")[^1];
                if (fileName.StartsWith("A",StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    listA.Add(fileName);
                    Console.WriteLine($"File {fileName} has been added to List-A");
                }
                else if (fileName.StartsWith("B", StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    listB.Add(fileName);
                    Console.WriteLine($"File {fileName} has been added to List-B");
                }
            }

            Console.WriteLine(@"
============================================================
                RESULT AFTER SORTING
============================================================");

            listA.Sort();
            listB.Sort();

            Console.WriteLine("LIST A");
            foreach (var item in listA)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nLIST B");
            foreach (var item in listB)
            {
                Console.WriteLine(item);
            }

        }
    }
}
