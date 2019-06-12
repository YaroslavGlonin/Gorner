using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gorner
{
    public partial class Form1 : Form
    {
        int y;//результат
        int r;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
                        MessageBox.Show("Схема Горнера — алгоритм вычисления значения многочлена," +
 "записанного в виде суммы мономов, при заданном значении переменной." +
 "Метод Горнера позволяет найти корни многочлена, а также вычислить" +
 "производные полинома в заданной точке. Схема Горнера также является" +
"простым алгоритмом для деления многочлена на бином вида x", "Схема Горнера 3.11.2009_year_gr.4402");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)//Альтернативный
        {
            label15.Text = "";
            //Провека ошибок ввода данных
            if (textBox6.Text == ""||textBox5.Text == ""||textBox4.Text == "")
                MessageBox.Show("Введите данные", "Ошибка");
                else
                    if (textBox4.Text == "0")
                        MessageBox.Show("Деление на 0 невозможно!", "Ошибка");
                    else
                        if (textBox6.Text == "1" || textBox5.Text == "0")
                            label1.Text = "1";
                        else
                            if (textBox4.Text == "0")
                                label1.Text = "0";
            try// блок проверки на ошибки
            {
                int a = Convert.ToInt32(textBox6.Text);
                int x = Convert.ToInt32(textBox5.Text);
                int m = Convert.ToInt32(textBox4.Text);
                label9.Text = a + " ^ " + x + " * mod " + m;
                //переводим степень в двочную систему счисления
                string stepen = Convert.ToString(Convert.ToInt32(textBox5.Text), 2);
                label13.Text = "Промежуточных результатов : " + stepen.Length.ToString();
                // в массив
                char[] ch = stepen.ToCharArray();
                y = 1;
                r = (a * a) % m;
                for (int i = 0; i <= stepen.Length-1; i++)
                {
                    if (i >= stepen.Length-1)
                    {
                        if (ch[i] == '1')
                            y = (y * a) % m;
                    }
                    else
                    {
                        if (ch[i] == '1')
                            y = ((y * y) * r) % m;
                        else { y = (y * y) % m; }
                    }
                    if (stepen.Length - 1 == i)
                        label15.Text = label15.Text + y.ToString() + ". ";
                    else
                        label15.Text = label15.Text + y.ToString() + ", ";
                }
                label1.Text = y.ToString();
            }
            catch { MessageBox.Show("Максимальное число разрядов в машинном слове 32!", "Ошибка"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label16.Text = "";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Введите данные", "Ошибка");
            else
                if (textBox3.Text == "0")
                    MessageBox.Show("Деление на 0 невозможно!", "Ошибка");
                else
                    if (textBox1.Text == "1" || textBox2.Text == "0")
                        label7.Text = "1";
                    else
                        if (textBox3.Text == "0")
                            label7.Text = "0";
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                int x = Convert.ToInt32(textBox2.Text);
                int m = Convert.ToInt32(textBox3.Text);
                label5.Text = a + " ^ " + x + " * mod " + m;
                string stepen = Convert.ToString(Convert.ToInt32(textBox2.Text), 2);
                char[] ch = stepen.ToCharArray();
                label17.Text = "Промежуточных результатов : " + stepen.Length.ToString();
                r = a;
                if (x % 2 == 0)//четное
                    y = 1;
                else//нечетное
                    y = a;
                label16.Text = label16.Text + y.ToString() + ". ";
                for (int i = stepen.Length - 2; i >= 0; i--)
                {
                    r = (r * r) % m;
                        if (ch[i] == '1')
                            y = (y * r) % m;
                        if (i==0)
                            label16.Text = label16.Text + y.ToString() + ". ";
                        else
                            label16.Text = label16.Text + y.ToString() + ", ";
                }
                label7.Text = y.ToString();
            }
            catch { MessageBox.Show("Максимальное число разрядов в машинном слове 32!", "Ошибка"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox2.Text =
                "r = a;\n" +
                "  if (x % 2 == 0)\n" +
                "      y = 1;\n" +
                "    else\n" +
                "       y = a;\n" +
                "  for (int i = stepen.Length - 2; i >= 0; i--)\n" +
                "    {\n" +
                "      r = (r * r) % m;\n" +
                "        if (ch[i] == '1')\n" +
                "            y = (y * r) % m;\n" +
                "    }";
            richTextBox1.Text =
                "y = 1;\n" +
                "r = (a * a) % m;\n" +
                "for (int i = 0; i <= stepen.Length-1; i++)\n" +
                "  {\n" +
                "      if (i >= stepen.Length-1)\n" +
                "        {\n" +
                "          if (ch[i] == '1')\n" +
                "             y = (y * a) % m;\n" +
                "        }\n" +
                "      else\n" +
                "        {\n" +
                "           if (ch[i] == '1')\n" +
                "               y = ((y * y) * r) % m;\n" +
                "           else { y = (y * y) % m; }\n" +
                "        }\n" +
                "   }";
        }
        }
    }
