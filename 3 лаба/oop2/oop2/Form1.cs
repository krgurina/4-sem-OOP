using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;


namespace oop2
{
    public partial class Form1 : Form
    {
        public List<Discipline> SaveList = new List<Discipline>();
        public List<Discipline> DisciplineList= new List<Discipline>();
        public Lector lector;
        public Discipline discipline;
        public string controlForm;
        readonly string path = @"F:\лабы\ООП\2 лаба\oop2\save.json";
        readonly string path2 = @"F:\лабы\ООП\2 лаба\oop2\save2.json";
        public int index = 0;
        public int delIndex = 0;

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            // счетчик кол-ва объектов (сначала 0)
            toolStripStatusLabel1.Text = "0   ";
            toolStripStatusLabel2.Text = string.Empty;

            //для таймера даты и времени
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar2.Value.ToString();
        }

        //кнопка сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            //CheckInput();
            toolStripStatusLabel2.Text = "сохранение";

            string title = textBox1.Text;
            string course = comboBox1.Text;

            string specialization = string.Empty;
            if (checkBox1.Checked) specialization += checkBox1.Text + " ";
            if (checkBox2.Checked) specialization += checkBox2.Text + " ";
            if (checkBox3.Checked) specialization += checkBox3.Text + " ";
            if (checkBox4.Checked) specialization += checkBox4.Text + " ";

            int sem = Convert.ToInt32(numericUpDown1.Value);
            int lectCount = Convert.ToInt32(trackBar1.Value);
            int labsCount = Convert.ToInt32(trackBar2.Value);


            if (radioButton1.Checked)
                controlForm = radioButton1.Text;
            if (radioButton2.Checked)
                controlForm = radioButton2.Text;

            //лектор
            string fio = textBox3.Text;
            string kafedra = comboBox2.Text;
            string auditoria = textBox2.Text;
            //создание лектора
            CreateLector(fio, kafedra, auditoria);
            //создание дисциплины
            CreateDiscipline(title, sem, course, lectCount, labsCount, specialization, controlForm, lector);

            //запись в файл
            using (StreamWriter writer = new StreamWriter(path2))
            {
                writer.Write(JsonSerializer.Serialize(DisciplineList, typeof(List<Discipline>)));
            }

        }
        //валидация лектора
        void CreateLector(string FIO, string kafedra, string audience)
        {
            lector = new Lector(FIO, kafedra, audience);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(lector);
            if (!Validator.TryValidateObject(lector, context, results, true))
            {
                foreach (var error in results)
                    MessageBox.Show($"Ошибка: {error.ErrorMessage}");
                MessageBox.Show("Лектор не проходит валидацию.\nИнформация не записана.");
            }
            else
                MessageBox.Show("Лектор проходит валидацию.\nИнформация записана в объект!", "DisciplineRedact", MessageBoxButtons.OK);
        }
        //валидация дисциплины
        void CreateDiscipline(string title, int semestr, string course, int lectionCount, int labsCount, string specialization, string controlType, Lector lect)
        {
            discipline = new Discipline(title, semestr, course, lectionCount, labsCount, specialization, controlType, lect);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(discipline);
            if (!Validator.TryValidateObject(discipline, context, results, true))
            {
                foreach (var error in results)
                    MessageBox.Show($"Ошибка: {error.ErrorMessage}");
                MessageBox.Show("Лектор не проходит валидацию.\nИнформация не записана.");
            }
            else
            {
                DisciplineList.Add(discipline);
                MessageBox.Show("Лектор проходит валидацию.\nИнформация записана в объект!", "DisciplineRedact", MessageBoxButtons.OK);
            }
        }
        private void CheckList()
        {
            try
            {
                string err = string.Empty;
                if (SaveList.Count == 0)
                    err += "Список пуст";


                if((index > SaveList.Count||index<0)&&SaveList.Count!=0)
                {
                    err += "\nindex Индекс вышел за пределы массива";
                    index = 0;
                }

                if ((delIndex > SaveList.Count || delIndex < 0)&&SaveList.Count!=0)
                {
                    err += "\ndelIndex Индекс вышел за пределы массива";
                    delIndex = 0;

                }
                if (err != string.Empty)
                    throw new Exception(err);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
        private void CheckInput()
        {
            try
            {
                string err = string.Empty;

                if (textBox1.Text == String.Empty)
                {
                    err+= "\nВведите название предмета";
                }

                if (textBox3.Text == String.Empty)
                {
                    err += "\nВведите имя лектора";
                }

                if (textBox2.Text == String.Empty)
                {
                    err += "\nВведите аудиторию";
                }

                if (trackBar1.Value == 0)
                {
                    err += "\nУкажите количество лекций";
                }

                if (trackBar2.Value == 0)
                {
                    err += "\nУкажите количество лаб";
                }

                if(comboBox1.Text == String.Empty || comboBox1.SelectedItem == null)
                {
                    err += "\nУкажите курс";
                }

                if (comboBox2.Text == String.Empty||comboBox2.SelectedItem==null)
                {
                    err += "\nУкажите кафедру";
                }

                if(!(radioButton1.Checked&&radioButton2.Checked))
                {
                    err += "\nВыберите форму контроля";
                }

                string disallow = "!@#$%^&*+=?~><1234567890";
                string letters= "qwertyuiop[]asdfghjkl;'zxcvbnmйцукенгшщзхъфывапролджэячсмитьбю!@#$%^&*+=?~><";


                for (int i = 0; i < disallow.Length; i++)
                {
                    if (textBox1.Text.Contains(disallow[i]))
                        err += "\nНазвание предмета содержит недопустимые символы";
                }

                for (int i = 0; i < disallow.Length; i++)
                {
                    if (textBox3.Text.Contains(disallow[i]))
                        err += "\nИмя лектора содержит недопустимые символы";
                }

                for (int i = 0; i < letters.Length; i++)
                {
                    if (textBox2.Text.Contains(letters[i]))
                        err += "\nНомер аудитории содержит недопустимые символы";
                }

                if(err!=string.Empty)
                    throw new Exception(err);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        //кнопка вывести
        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    List<Discipline>? restored = JsonSerializer.Deserialize<List<Discipline>>(line);
                    SaveList = JsonSerializer.Deserialize<List<Discipline>>(line);
                    foreach (var item in restored)
                        richTextBox1.Text += item.ToString();
                }
            }

            toolStripStatusLabel1.Text = SaveList.Count.ToString();
            toolStripStatusLabel2.Text = "вывод";

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 SearchForm = new Form2();
            //SearchForm.DisciplineListForSearch = this.DisciplineList;
            SearchForm.Show();
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 SortForm = new Form3();
            //SortForm.DisciplineList = this.SaveList;
            SortForm.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия v.0.1\nГурина Кристина", "DisciplineRedact", MessageBoxButtons.OK);
        }

        //очистить
        private void button3_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            textBox1.Text=string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            trackBar1.Value = 0;
            label9.Text = "0";
            trackBar2.Value = 0;
            label14.Text = "0";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false; 
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            toolStripStatusLabel2.Text = "Очистка";

        }

        //кнопка вперёд
        private void button5_Click(object sender, EventArgs e)
        {
            CheckList();
            if (SaveList.Count == 0)
            {
                richTextBox1.Text = string.Empty;
                return;
            }
            delIndex = index;
            
            richTextBox1.Text = SaveList[index].ToString();
            index++;

            if (index == SaveList.Count)
                index = 0;
            toolStripStatusLabel2.Text = "Вперёд ";

        }

        //кнопка назад
        private void button6_Click(object sender, EventArgs e)
        {
            CheckList();
            if (SaveList.Count == 0)
            {
                richTextBox1.Text = string.Empty;
                return;
            }
            delIndex = index;
            richTextBox1.Text = SaveList[index].ToString();
            index--;
            if (index < 0)
                index = SaveList.Count-1;
            toolStripStatusLabel2.Text = "назад";

        }

        //кнопка удалить
        private void button4_Click(object sender, EventArgs e)
        {
            
            CheckList();
            if (SaveList.Count == 0)
                return;
            SaveList.Remove(SaveList[delIndex]);
            index--;
            button5_Click(sender, e);
            toolStripStatusLabel1.Text = SaveList.Count.ToString();
            toolStripStatusLabel2.Text = "удаление";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;

        }
    }
}
