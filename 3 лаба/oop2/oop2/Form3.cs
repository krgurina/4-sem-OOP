using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Text.Json;



namespace oop2
{
    public partial class Form3 : Form
    {
        public Form1 form1;
        public List<Discipline> DisciplineList = new List<Discipline>();
        public List<Discipline> SortList = new List<Discipline>();
        readonly string path = @"F:\лабы\ООП\2 лаба\oop2\save.json";
        readonly string pathSort = @"F:\лабы\ООП\2 лаба\oop2\sort.json";

        public Form3()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    DisciplineList = JsonSerializer.Deserialize<List<Discipline>>(line);
                }
            }
        }
        public Form3(Form1 f)
        {                           /// передаю первую форму в качестве параметра
            InitializeComponent();  /// при инициализации второй формы и задаю
            form1 = f;              /// полю form1 значение этого параметра
        }

        //сортировка по лекциям
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var res = from d in DisciplineList
                      orderby d.lectionCount
                      select d;
            SortList = res.ToList();

            foreach (var item in SortList)
            {
                richTextBox1.Text += item.ToString();
            }
        }

        //сортировать по типу контроля
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var res = from d in DisciplineList
                      orderby d.controlType
                      select d;
            SortList = res.ToList();

            foreach (var item in SortList)
            {
                richTextBox1.Text += item.ToString();
            }
        }

        //по лекцимя и контролю
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var res = from d in DisciplineList
                      orderby d.lectionCount
                      orderby d.controlType
                      select d;
            SortList = res.ToList();

            foreach (var item in SortList)
            {
                richTextBox1.Text += item.ToString();
            }
        }

        //сохранить 
        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(pathSort))
            {
                writer.Write(JsonSerializer.Serialize(SortList, typeof(List<Discipline>)));
            }
            MessageBox.Show("Сохранено в файл");
        }
    }
}
