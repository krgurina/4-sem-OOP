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
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace oop2
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public string LectorSearch { get; set; }
        public string SemesterSearch { get; set; }
        public string CourseSearch { get; set; }
        public string SearchResult { get; set; } = String.Empty;
        public List<Discipline> DisciplineListForSearch = new List<Discipline>();
        public List<Discipline> SearchList = new List<Discipline>();
        readonly string pathSearsh = @"F:\лабы\ООП\2 лаба\oop2\search.json";
        readonly string path = @"F:\лабы\ООП\2 лаба\oop2\save.json";
        public Form2()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    DisciplineListForSearch = JsonSerializer.Deserialize<List<Discipline>>(line);
                }
            }
        }

        public Form2(Form1 f)
        {                           /// передаю первую форму в качестве параметра
            InitializeComponent();  /// при инициализации второй формы и задаю
            form1 = f;              /// полю form1 значение этого параметра
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(pathSearsh))
            {
                writer.Write(JsonSerializer.Serialize(SearchList, typeof(List<Discipline>)));
            }
            MessageBox.Show("Сохранено в файл");

        }

        //поиск по курсу
        private void button4_Click(object sender, EventArgs e)
        {
            CourseSearch = textBox2.Text;
            var resSem = from dist in DisciplineListForSearch
                         where dist.course == CourseSearch
                         select dist;

            SearchList = resSem.ToList();

            richTextBox1.Text = "Найдено элементов: " + SearchList.Count.ToString();
            foreach (var item in SearchList)
            {
                richTextBox1.Text += item.ToString();
            }
        }
        //поиск по семестру
        private void button5_Click(object sender, EventArgs e)
        {
            SemesterSearch = textBox3.Text;
            int sem = Convert.ToInt32(SemesterSearch);
            var resSem = from dist in DisciplineListForSearch
                         where dist.semestr == sem
                         select dist;

            SearchList = resSem.ToList();

            richTextBox1.Text = "Найдено элементов: " + SearchList.Count.ToString();
            foreach (var item in SearchList)
            {
                richTextBox1.Text += item.ToString();
            }
        }

        //по всем критериям
        private void button6_Click(object sender, EventArgs e)
        {
            CourseSearch = textBox2.Text;
            SemesterSearch = textBox3.Text;
            int sem = Convert.ToInt32(SemesterSearch);

            Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
            SearchList.Clear();
            foreach (var item in DisciplineListForSearch)
            {
                string s = item.lector.FIO;
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                    SearchList.Add(item);
            }


            var res = from dist in SearchList
                      where dist.course == CourseSearch
                      where dist.semestr == sem
                      select dist;

            SearchList = res.ToList();

            richTextBox1.Text = "Найдено элементов: " + SearchList.Count.ToString();
            foreach (var item in SearchList)
            {
                richTextBox1.Text += item.ToString();
            }
        }

        //поиск по лектору
        private void button3_Click_1(object sender, EventArgs e)
        {
            Regex regex = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
            SearchList.Clear();
            foreach (var item in DisciplineListForSearch)
            {
                string s = item.lector.FIO;
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                    SearchList.Add(item);
            }

            richTextBox1.Text = "Найдено элементов: " + SearchList.Count.ToString();
            foreach (var item in SearchList)
            {
                richTextBox1.Text += item.ToString();
            }
        }
    }
}
