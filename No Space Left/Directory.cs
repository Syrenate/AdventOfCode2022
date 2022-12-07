using System;
using System.Collections.Generic;
using System.Text;

namespace No_Space_Left
{
    public class Directory
    {
        string name = "";
        int size = 0;
        List<Directory> contains;
        List<string[]> files;
        Directory parent;
        int layer = 0;

        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public List<Directory> Contains { get => contains; set => contains = value; }
        public List<string[]> Files { get => files; set => files = value; }
        public int Layer { get => layer; set => layer = value; }
        public Directory Parent { get => parent; set => parent = value; }
    }
}
