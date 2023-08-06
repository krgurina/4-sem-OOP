using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace oop1
{
    public partial class Calculator : Form
    { 
        public string inputStr {get; set;}
        public string findSubStr { get; set; }
        public string subStr { get; set; }
        public int indx { get; set; }
        public string strIndx { get; set; }

        public Calculator()
        {
            InitializeComponent();
        }
        
        private void CheckInputStr()
        {
            try
            {
                if (textBox1.Text == String.Empty)
                {
                    throw new Exception("Введите начальную строку");
                }
            }
            catch(Exception e)
            {
                textBox1.BackColor = System.Drawing.Color.Red;
                MessageBox.Show(e.Message);
                textBox1.BackColor = System.Drawing.Color.White;
                throw;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckInputStr();
        
            if (textBox2.Text== String.Empty)
            {
                textBox2.BackColor = System.Drawing.Color.Red;
                throw new Exception("Введите искомую подстроку");
            }
            textBox2.BackColor = System.Drawing.Color.White;

            if (!inputStr.Contains(findSubStr))
            {
                textBox2.BackColor = System.Drawing.Color.Red;
                throw new Exception("Такой подстроки нет в изначальной строке");
            }
            textBox2.BackColor = System.Drawing.Color.White;

            if (textBox3.Text == String.Empty)
            {
                textBox3.BackColor = System.Drawing.Color.Red;
                throw new Exception("Введите подстроку на которую будете заменять");
            }
            textBox3.BackColor = System.Drawing.Color.White;

            inputStr = inputStr.Replace(findSubStr,subStr);
            textBox1.Text = inputStr;
            result.Text = inputStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            inputStr = inputStr.Remove(0, 1);   //1 символа с начала
            textBox1.Text = inputStr;
            result.Text = inputStr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            int ind = inputStr.Length - 1;
            inputStr = inputStr.Remove(ind);   //1 символа с конца
            textBox1.Text = inputStr;
            result.Text = inputStr;
        }

        //считываем строку
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputStr = textBox1.Text;
        }
        //для подстроки
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            findSubStr = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            subStr = textBox3.Text;
        }

        //символ по индексу
        private void button4_Click(object sender, EventArgs e)
        {
            CheckInputStr();

            if(textBox4.Text==String.Empty)
            {

                textBox4.BackColor = System.Drawing.Color.Red;
                throw new Exception("Введите индекс");
            }
            textBox4.BackColor = System.Drawing.Color.White;

            if (int.TryParse(strIndx, out var number))
            {
                indx = number;
            }
            else
            {
                textBox4.BackColor = System.Drawing.Color.Red;
                throw new Exception("Некорректный индекс");
            }
            textBox4.BackColor = System.Drawing.Color.White;

            if (indx > inputStr.Length - 1)
            {
                textBox4.BackColor = System.Drawing.Color.Red;
                throw new Exception("Индекс вышел за пределы строки");
            }
            textBox4.BackColor = System.Drawing.Color.White;

            result.Text = Convert.ToString(inputStr[indx]);
            
        }

        //считываем индекс
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            strIndx = textBox4.Text;
        }

            //длина строки
        private void button5_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            result.Text = Convert.ToString(inputStr.Length);
        }

        //гласные
        private void button6_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            string glasnie = "уеыаоэяиюёeyuioa";

            var count = inputStr.Count(x => glasnie.Contains(x));
            
            result.Text = Convert.ToString(count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            string soglasnie = "йцкнгшщзхъфвпрлджчсмтьбqwrtpsdfghjklzxcvbnm";
            int soglasnieCount = 0;

            for (int i = 0; i < inputStr.Length; i++)
            {
                for (int j = 0; j < soglasnie.Length; j++)
                {
                    if (inputStr[i] == soglasnie[j])
                        soglasnieCount++;
                }
            }
            result.Text = Convert.ToString(soglasnieCount);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            int sentences = inputStr.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            result.Text = Convert.ToString(sentences);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CheckInputStr();
            int words = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            result.Text = Convert.ToString(words);
        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
