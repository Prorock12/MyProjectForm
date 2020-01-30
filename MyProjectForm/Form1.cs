using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProjectForm
{
    public partial class Form1 : Form
    {
        const int number = 10;
        List<Animals> animals = new List<Animals>();
        int count = 0;
        bool[] can = new bool[number - 1];
        string[] mass = new string[number];
        string[,] massOfData = new string[number, number - 1];
        string path = @"C:\Богдан\C#\SoftServe\TXT_FILES\MyProject.txt";
        string pathSortByYear = @"C:\Богдан\C#\SoftServe\TXT_FILES\File1.txt";
        string pathToFile2 = @"C:\Богдан\C#\SoftServe\TXT_FILES\File2.txt";
        int CountOfFile2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Oparation.Reader(path, mass, massOfData, can);
            int i = 0;
            listBox1.Items.AddRange(Oparation.OutPut(massOfData));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oparation.WriteToList(animals, massOfData);
            foreach (Animals a in animals)
            {
                listBox2.Items.Add(a.Print());
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oparation.Sort(animals, pathSortByYear);
            foreach (Animals a in animals)
            {
                listBox3.Items.Add(a.Print());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Oparation.OutPutToFile2(pathToFile2, animals,ref CountOfFile2);
            List<string> text = new List<string>();
            int count = 0;
            using (StreamReader reader = new StreamReader(pathToFile2))
            {
                while (count!=4) 
                {
                    text.Add(reader.ReadLine());
                    count++;
                }
                foreach (string s in text)
                {
                    listBox4.Items.Add(s);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
