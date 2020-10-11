using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AudioMerger
{
    class Program
    {
        class Pair
        {
            public String FileA { get; set; }
            public String FileB { get; set; }
            public String OutputName { get; set; }
        }

        public static List<String> listA = new List<String>();
        public static List<String> listB = new List<String>();
        static List<Pair> pairs = new List<Pair>();


        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");


            //Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            //Console.WriteLine(Directory.GetCurrentDirectory());
            
            foreach (string item in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                //Console.WriteLine(item); //this is full path of each file
                var fileName = item.Split(@"\")[^1];
                if (fileName.StartsWith("A",StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    listA.Add(fileName);
                    //Console.WriteLine($"File {fileName} has been added to List-A");
                }
                else if (fileName.StartsWith("B", StringComparison.OrdinalIgnoreCase) && fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    listB.Add(fileName);
                    //Console.WriteLine($"File {fileName} has been added to List-B");
                }
            }

            Console.WriteLine($"Total Item’s in List-A: {listA.Count}, List-B: {listB.Count}");

//            Console.WriteLine(@"
//============================================================
//                RESULT AFTER SORTING
//============================================================");

            listA.Sort();
            listB.Sort();

            //Console.WriteLine("LIST A");
            foreach (var item in listA)
            {
                //Console.WriteLine(item);

                var firstLetterRemovedNameOfA = item.Substring(1);
                //Console.WriteLine(firstLetterRemovedNameOfA);
                var matching = listB.FirstOrDefault(f => f.Substring(1).Equals(firstLetterRemovedNameOfA, StringComparison.OrdinalIgnoreCase));
                //Console.WriteLine(matching);
                if (matching != null)
                {
                    pairs.Add(new Pair { FileA = item, FileB = matching, OutputName = firstLetterRemovedNameOfA });
                }


            }
            //Console.WriteLine("\nLIST B");
            //foreach (var item in listB)
            //{
            //    Console.WriteLine(item);
            //}


            Console.WriteLine(@"
====================------=======================
                    RESULT
====================------=======================
");

            foreach (var item in pairs)
            {
                Console.WriteLine("{0,-18}  <---->  {1,18}  ====>  {2,-18}", item.FileA,item.FileB,item.OutputName);
            }




        }
    }
}
