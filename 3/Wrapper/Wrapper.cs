using System;
using System.Collections.Generic;
using System.IO;

namespace Wrapper
{
    class Wrapper
    {
        private LinkedList<Staff> List;

        public Wrapper() // Default constructor
        {
            List = new LinkedList<Staff>();
        }

        public void Insert(Staff p) // Inserting element into end of list
        {
            List.AddLast(p);
        }

        public void Remove()
        {
            List.Remove(List.First);
        }

        public void Change(Staff what, Staff whom)
        {
            List.Find(what).Value = whom;
        }

        public Staff GetValue()
        {
            return List.First.Value;
        }

        public LinkedListNode<Staff> GetFirst()
        {
            return List.First;
        }

        public LinkedListNode<Staff> GetLast()
        {
            return List.Last;
        }

        public void Print()
        {
            int count = 0;
            foreach (var item in List)
            {
                Console.WriteLine($"{count}:");
                Console.WriteLine($"name: { item.Name }");
                Console.WriteLine($"shop num: { item.Num }");
                Console.WriteLine($"rank: { item.Rank }");
                count++;
            }
        }

        public LinkedListNode<Staff> GetNext(LinkedListNode<Staff> now)
        {
            return now.Next;
        }

        public LinkedListNode<Staff> GetPrev(LinkedListNode<Staff> now)
        {
            return now.Previous;
        }

        public void LoadFromFile(String fileName)
        {
            this.List.Clear();
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            String line = "", num = "", rank = "";

            while (true)
            {
                line = reader.ReadLine();
                if (line == null) break;
                num = reader.ReadLine();
                rank = reader.ReadLine();
                this.Insert(new Staff(line, Convert.ToUInt32(num), Convert.ToByte(rank)));
            }

            reader.Close();
        }

        public void SaveToFile(String filename)
        {
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            foreach (var item in List)
            {
                writer.WriteLine(item.Name);
                writer.WriteLine(item.Num);
                writer.WriteLine(item.Rank);
            }
            writer.Close();
        }

        public Staff getFromIndex(int index)
        {
            int count = 0;
            foreach (var item in List)
            {
                if (count == index) return item;
                count++;
            }
            return null;
        }
    }
}
