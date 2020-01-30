using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MyProjectForm
{
    public class Oparation
    {
        const int number = 10;
        public static void Reader(string path, string[] mass, string[,] massOfData,bool[] can)
        {
            int count, j;
            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 0; i < number; i++)
                {
                    j = 0;
                    count = 0;
                    mass[i] = reader.ReadLine();
                    for (int b = 0; b < 4; b++)
                    {
                        can[b] = false;
                    }
                    while (count != mass[i].Length)
                    {
                        foreach (char ch in mass[i])
                        {
                            count++;
                            if (ch != ' ' && can[j] == false)
                            {
                                massOfData[i, j] += ch;
                            }
                            else if (ch == ' ' && can[j] == false)
                            {
                                can[j] = true;
                                j++;
                            }
                        }
                    }
                }
            }
        }
        public static string[] OutPut(string[,] massOfData)
        {
            string[] result = new string[number];
            string text=null;
            for (int i = 0; i < number; i++)
            {
                result[i] += i + 1 + ") ";
                for (int j = 0; j < 4; j++)
                {
                    text += (massOfData[i, j] + " ");
                }
                result[i]+=text;
                text = null;
            }
            return result;
        }
        public static void WriteToList(List<Animals> animals,string[,] massOfData)
        {
            for (int i = 0; i < number; i++)
            {
                if (massOfData[i, 0] == "Horse")
                    animals.Add(new Horse(massOfData[i, 0], Convert.ToInt32(massOfData[i, 1]), massOfData[i, 2], massOfData[i, 3]));
                else if (massOfData[i, 0] == "Donkey")
                    animals.Add(new Donkey(massOfData[i, 0], Convert.ToInt32(massOfData[i, 1]), massOfData[i, 2], Convert.ToDouble(massOfData[i, 3])));
            }
        }
        public static void Sort(List<Animals> animals,string pathSortByYear)
        {
            animals.Sort();
            Console.WriteLine("************************Sort**************************");
            foreach (Animals a in animals)
            {
                Console.WriteLine(a.Print());
                using (StreamWriter writer = new StreamWriter(pathSortByYear, true))
                {
                    writer.WriteLine(a.Print());
                }
            }
        }
        public static int OutPutToFile2(string pathToFile2,List<Animals> animals,ref int CountOfFile2)
        { 
            string nameOfDonkey = null;
            string nameOfHorse = null;
            int count = 0; // Count For Horse
            int countForDonkey = 0;
            bool enterForDonkey = false;
            bool enterForHorse = false;
            string Compare = null;
            using (StreamWriter writer = new StreamWriter(pathToFile2, true))
            {
                foreach (Animals a in animals)
                {
                    if (a.Name == "Horse" && a.Suit.ToLower() == "white")
                    {
                        Compare = a.Print();
                        if (nameOfHorse != Compare && count != 0)
                        {
                            writer.WriteLine(nameOfHorse + " " + count);
                            CountOfFile2++;
                            count = 0;
                            enterForHorse = false;
                            nameOfHorse = null;
                        }
                        count++;
                        enterForHorse = true;
                        nameOfHorse = a.Print();
                        continue;
                    }
                    else if (enterForHorse == true)
                    {
                        writer.WriteLine(nameOfHorse + " " + count);
                        CountOfFile2++;
                        count = 0;
                        enterForHorse = false;
                        nameOfHorse = null;
                    }
                    if (a.Name == "Donkey" && a.Height < 150)
                    {
                        Compare = a.Print();
                        if (nameOfDonkey != Compare && countForDonkey != 0)
                        {
                            writer.WriteLine(nameOfDonkey + " " + countForDonkey);
                            CountOfFile2++;
                            countForDonkey = 0;
                            enterForDonkey = false;
                            nameOfDonkey = null;
                        }
                        countForDonkey++;
                        enterForDonkey = true;
                        nameOfDonkey = a.Print();
                        continue;
                    }
                    else if (enterForDonkey == true)
                    {
                        writer.WriteLine(nameOfDonkey + " " + countForDonkey);
                        CountOfFile2++;
                        countForDonkey = 0;
                        enterForDonkey = false;
                        nameOfDonkey = null;
                    }
                }
                if (nameOfDonkey != null)
                    writer.WriteLine(nameOfDonkey + " " + countForDonkey);
                else if (nameOfHorse != null)
                    writer.WriteLine(nameOfHorse + " " + count);
                CountOfFile2++;
                return CountOfFile2;
            }
        }
    }
}