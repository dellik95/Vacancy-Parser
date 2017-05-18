using ParserVacancy.Core;
using ParserVacancy.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserVacancy
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        public Form1()
        {
            parser = new ParserWorker<string[]>(new WorkParser());
            InitializeComponent();

            parser.OnComplete += Parser_OnComplete;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnComplete(object obj)
        {
            MessageBox.Show("Well Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.ParserSettings1 = new WorkSettings
            {
                StartPoint = (int)numericUpDown1.Value,
                EndPoint = (int)numericUpDown2.Value,
                SearchVac = textBox1.Text.Replace(" ", "+")
            };
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(string.Format(@"https://rabota.ua/{0}",listBox1.SelectedItem.ToString()));
        }
    }
}
