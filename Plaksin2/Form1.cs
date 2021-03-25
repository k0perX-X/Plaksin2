using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Plaksin2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<(string Name, DateTime Date, int Time)> mas = new List<(string Name, DateTime Date, int Time)>();

        private void button1_Click(object sender, EventArgs e)
        {
            mas.Add((
                Name: textBox1.Text,
                Date: dateTimePicker1.Value,
                Time: trackBar1.Value
                ));
            richTextBox1.Text +=
                $"Name: {textBox1.Text}, Date: {dateTimePicker1.Value}, Time: {((trackBar1.Value * 15) / 60).ToString() + ":" + ((trackBar1.Value * 15) % 60).ToString()}\n";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timeLabel.Text = ((trackBar1.Value * 15) / 60).ToString() + ":" + ((trackBar1.Value * 15) % 60).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            (string Name, DateTime Date, int Time) o;
            if (!checkBox1.Checked)
            {
                for (int i = 0; i < mas.Count; i++)
                {
                    for (int j = 0; j < mas.Count; j++)
                    {
                        if (mas[i].Date.Year * 1000000 + mas[i].Date.Month * 10000 + mas[i].Date.Day * 100 +
                            mas[i].Time < mas[j].Date.Year * 1000000 + mas[j].Date.Month * 10000 +
                            mas[j].Date.Day * 100 + mas[j].Time)
                        {
                            o = mas[i];
                            mas[i] = mas[j];
                            mas[j] = o;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < mas.Count; i++)
                {
                    for (int j = 0; j < mas.Count; j++)
                    {
                        if (mas[i].Date.Year * 1000000 + mas[i].Date.Month * 10000 + mas[i].Date.Day * 100 +
                            mas[i].Time > mas[j].Date.Year * 1000000 + mas[j].Date.Month * 10000 +
                            mas[j].Date.Day * 100 + mas[j].Time)
                        {
                            o = mas[i];
                            mas[i] = mas[j];
                            mas[j] = o;
                        }
                    }
                }
            }

            richTextBox1.Text = "";
            for (int i = 0; i < mas.Count; i++)
            {
                richTextBox1.Text +=
                    $"Name: {mas[i].Name}, Date: {mas[i].Date}, Time: {((mas[i].Time * 15) / 60).ToString() + ":" + ((mas[i].Time * 15) % 60).ToString()}\n";
            }
        }
    }
}