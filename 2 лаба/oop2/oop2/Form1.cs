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

namespace oop2
{
    public partial class Form1 : Form
    {
        public string controlForm;
        readonly string path = @"F:\лабы\ООП\2 лаба\oop2\save.json";
        readonly string path2 = @"F:\лабы\ООП\2 лаба\oop2\save2.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar2.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckInput();
            string title = textBox1.Text;
            int sem = Convert.ToInt32(numericUpDown1.Value);
            string course = comboBox1.Text;

            string specialization = "";
            if (checkBox1.Checked) specialization += checkBox1.Text + " ";
            if (checkBox2.Checked) specialization += checkBox2.Text + " ";
            if (checkBox3.Checked) specialization += checkBox3.Text + " ";
            if (checkBox4.Checked) specialization += checkBox4.Text + " ";

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
            Lector lector = new Lector(fio, kafedra, auditoria);

            Discipline discipline = new Discipline(title, sem, course, lectCount, labsCount, specialization, controlForm, lector);


            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(JsonSerializer.Serialize(discipline, typeof(Discipline)));
            }
            using (StreamWriter writer = new StreamWriter(path2))
            {
                writer.Write(JsonSerializer.Serialize(lector, typeof(Lector)));
            }

        }
        private void CheckInput()
        {
            try
            {
                string err = string.Empty;

                if (textBox1.Text == String.Empty)
                {
                    err+="Введите название предмета";
                }

                if (textBox3.Text == String.Empty)
                {
                    throw new Exception("Введите имя лектора");
                }

                if (textBox2.Text == String.Empty)
                {
                    throw new Exception("Введите аудиторию");
                }

                if (trackBar1.Value == 0)
                {
                    throw new Exception("Укажите количество лекций");
                }

                if (trackBar2.Value == 0)
                {
                    throw new Exception("Укажите количество лаб");
                }

                if(comboBox1.Text == String.Empty || comboBox1.SelectedItem == null)
                {
                    throw new Exception("Укажите курс");
                }

                if (comboBox2.Text == String.Empty||comboBox2.SelectedItem==null)
                {
                    throw new Exception("Укажите кафедру");
                }

                string disallow = "!@#$%^&*+=?~><1234567890";
                string letters= "qwertyuiop[]asdfghjkl;'zxcvbnmйцукенгшщзхъфывапролджэячсмитьбю!@#$%^&*+=?~><";


                for (int i = 0; i < disallow.Length; i++)
                {
                    if (textBox1.Text.Contains(disallow[i]))
                        throw new Exception("Название предмета содержит недопустимые символы");
                }

                for (int i = 0; i < disallow.Length; i++)
                {
                    if (textBox3.Text.Contains(disallow[i]))
                        throw new Exception("Имя лектора содержит недопустимые символы");
                }

                for (int i = 0; i < letters.Length; i++)
                {
                    if (textBox2.Text.Contains(letters[i]))
                        throw new Exception("Номер аудитории содержит недопустимые символы");
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

        private void button2_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Discipline? restored = JsonSerializer.Deserialize<Discipline>(line);
                    MessageBox.Show(restored.ToString());
                }
            }

            using (StreamReader sr = new StreamReader(path2))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Lector? restored = JsonSerializer.Deserialize<Lector>(line);
                    MessageBox.Show(restored.ToString());
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
