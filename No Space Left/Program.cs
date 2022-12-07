
using System;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System.Reflection.PortableExecutable;

namespace No_Space_Left
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Users\\lukej\\source\\repos\\AdventOfCode2022\\No Space Left\\Day7Input.txt");

            //Directory root = new Directory() { Name = "root", Layer = 0 };
            //Dictionary<string, Directory> directories = new Dictionary<string, Directory>();
            //directories.Add("/,root", root);
            //string currentDir = "/";
            //foreach (string line in input)
            //{
            //    if (line.Contains("hztjntff")) { 
            //        currentDir = currentDir; }
            //    if (line[0] == '$')
            //    {
            //        if (line == "$ cd /")
            //        {
            //            currentDir = "/,root";
            //        }
            //        else if (line == "$ cd ..")
            //        {
            //            foreach (var d in directories)
            //            {
            //                if (d.Value.Contains.Contains(currentDir))
            //                {
            //                    currentDir = d.Key;
            //                    break;
            //                }
            //            }
            //        }
            //        else if (line != "$ ls")
            //        {
            //            foreach (var d in directories)
            //            {
            //                if (d.Value.Contains.Contains(line.Split(" ")[2]))
            //                {
            //                    currentDir = line.Split(" ")[2] + "," + d.Key.Split(",")[0];
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    else if (line.Contains("dir "))
            //    {
            //        string key = line.Split(" ")[1] + "," + currentDir.Split(",")[0];

            //        Directory newDir = new Directory();
            //        newDir.Name = line.Split(" ")[1];
            //        newDir.Layer = directories[currentDir].Layer + 1;
            //        newDir.Parent = currentDir.Split(",")[0];
            //        directories[currentDir].Contains.Add(newDir.Name);
            //        directories.Add(key, newDir);
            //    }
            //    else
            //    {
            //        string[] newFile = new string[2] { line.Split(" ")[0], line.Split(" ")[1] };
            //        directories[currentDir].Files.Add(newFile);
            //    }
            //}

            //int FileSize(Directory d)
            //{
            //    int size = 0;

            //    foreach(string[] file in d.Files)
            //    {
            //        size += Convert.ToInt32(file[0]);
            //    }

            //    string n = "";
            //    if (d.Name == "root") { n = "/"; }
            //    else { n = d.Name; }
            //    foreach(string d2 in d.Contains)
            //    {
            //        size += FileSize(directories[d2 + "," + n]);
            //    }

            //    d.Size = size;
            //    return size;
            //}

            //FileSize(directories["/,root"]);

            //int size = 0;
            //foreach (var d in directories)
            //{
            //    if (d.Value.Size < 100000)
            //    {
            //        size += d.Value.Size;
            //    }
            //}

            //Console.WriteLine("Part 1: " + size);

            Directory currentDir = new Directory();
            List<Directory> directories = new List<Directory>();
            Directory root = new Directory();
            root.Name = "/"; root.Contains = new List<Directory>();
            root.Files = new List<string[]>(); root.Layer = 0;
            directories.Add(root);
            currentDir = directories[0];

            foreach (string l in input)
            {
                string[] line = l.Split(' ');
                if (line[0] == "$")
                {
                    if (line[1] == "cd")
                    {
                        if (line[2] == "/")
                        {
                            currentDir = directories[0];
                        }
                        else if (line[2] == "..")
                        {
                            currentDir = currentDir.Parent;
                        }
                        else
                        {
                            foreach (var d in currentDir.Contains)
                            {
                                if (d.Name == line[2])
                                {
                                    currentDir = d; break;
                                }
                            }
                        }
                    }
                }
                else if (line[0] == "dir")
                {
                    Directory newDir = new Directory() { Name = line[1], 
                        Contains = new List<Directory>(), Files = new List<string[]>(),
                        Parent = currentDir, Layer = currentDir.Layer + 1 };
                    currentDir.Contains.Add(newDir);
                    directories.Add(newDir);
                }
                else
                {
                    currentDir.Files.Add(new string[2] { line[1], line[0] });
                }
            }

            int getSize(Directory dir)
            {
                int size = 0;

                foreach (string[] file in dir.Files)
                {
                    size += Convert.ToInt32(file[1]);
                }
                foreach (var d in dir.Contains)
                {
                    size += getSize(d);
                }

                dir.Size = size;
                return size;
            }

            getSize(root);

            // Part 1
            int totalSize = 0;
            foreach (Directory d in directories)
            {
                if (d.Size < 100000)
                {
                    totalSize += d.Size;
                }
            }

            // Part 2
            int unusedSpace = 70000000 - root.Size;
            int n = 0;
            if (unusedSpace < 30000000)
            {
                n = 30000000 - unusedSpace;
            }

            Directory smallest = root;
            foreach (Directory d in directories)
            {
                if (d.Size > n && d.Size < smallest.Size)
                {
                    smallest = d;
                }
            }

            Console.WriteLine("Part 1: " + totalSize);
            Console.WriteLine("Part 2: " + smallest.Size);
        }
    }
}
