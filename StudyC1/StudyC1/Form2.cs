using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyC1
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public string text2;
        public int row_selected;
        public Form2(string text, Form1 form1)
        {
            InitializeComponent();
            text2 = text;
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var data = InitData();
            data = data.Where(c => c.cow_code.ToLower().Contains(text2.ToLower())).ToList();
            var cow = data.FirstOrDefault(c => c.cow_code == text2);
            if (cow != null)
            {
                c1TextBox2.Text = cow.cow_name;
            }
            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
            c1TextBox1.Text = text2;
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            form1.txbox1 = this.text2;
            Close();
        }
        private List<Cow> InitData()
        {
            var data = new List<Cow>();
            for (int i = 1; i < 16; i++)
            {
                data.Add(new Cow(i.ToString(), $"Name {i}", (i % 2 == 0 ? "Classify 1" : "Classify 2")));
            }
            return data;
        }

        private void c1TextBox1_TextChanged(object sender, EventArgs e)
        {
            var data = InitData();
            var code = c1TextBox1.Text;
            var name = c1TextBox2.Text;
            var classify = "";
            if (radioButton1.Checked) classify = "Classify 1";
            else if(radioButton2.Checked) classify = "Classify 2";
            data = data.Where(c => (string.IsNullOrEmpty(classify) ? true : c.cow_class == classify)
                                && (string.IsNullOrEmpty(code) ? true : c.cow_code.ToLower().Contains(code.ToLower()))
                                && (string.IsNullOrEmpty(name) ? true : c.cow_name.ToLower().Contains(name.ToLower()))
                                )
                        .Skip(0).Take(15).ToList();

            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
            var cow = data.FirstOrDefault(c => c.cow_code == code);
            if (cow != null)
            {
                c1TextBox2.Text = cow.cow_name;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var data = InitData();
            var code = c1TextBox1.Text;
            var name = c1TextBox2.Text;
            data = data.Where(c => c.cow_class == "Classify 1"
                                && (string.IsNullOrEmpty(code) ? true : c.cow_code.ToLower().Contains(code.ToLower()))
                                && (string.IsNullOrEmpty(name) ? true : c.cow_name.ToLower().Contains(name.ToLower()))
                                )
                        .Skip(0).Take(15).ToList();

            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var data = InitData();
            var code = c1TextBox1.Text;
            var name = c1TextBox2.Text;
            data = data.Where(c => c.cow_class == "Classify 2"
                                && (string.IsNullOrEmpty(code) ? true : c.cow_code.ToLower().Contains(code.ToLower()))
                                && (string.IsNullOrEmpty(name) ? true : c.cow_name.ToLower().Contains(name.ToLower())))
                        .Skip(0).Take(15).ToList();
            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            var data = InitData();
            var code = c1TextBox1.Text;
            var name = c1TextBox2.Text;
            data = data.Where(c => (string.IsNullOrEmpty(code) ? true : c.cow_code.ToLower().Contains(code.ToLower()))
                                && (string.IsNullOrEmpty(name) ? true : c.cow_name.ToLower().Contains(name.ToLower())))
                        .Skip(0).Take(15).ToList();
            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
        }

        private void c1TextBox2_TextChanged(object sender, EventArgs e)
        {
            var data = InitData();
            var code = c1TextBox1.Text;
            var name = c1TextBox2.Text;
            data = data.Where(c => (string.IsNullOrEmpty(code) ? true : c.cow_code.ToLower().Contains(code.ToLower()))
                                && (string.IsNullOrEmpty(name) ? true : c.cow_name.ToLower().Contains(name.ToLower())))
                        .Skip(0).Take(15).ToList();
            label2.Text = $"件数 1/{data.Count / 15}";
            c1FlexGrid1.DataSource = data;
            var cow = data.FirstOrDefault(c => c.cow_name == name);
            if (cow != null)
            {
                c1TextBox1.Text = cow.cow_code;
            }
        }

        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            c1FlexGrid1.Rows[this.row_selected].Selected = false;
            var row = c1FlexGrid1.Row;
            this.row_selected = row;
            c1FlexGrid1.Rows[row].Selected = true;
            var cell = c1FlexGrid1[row, 1];
            this.text2 = cell.ToString();
        }
    }
    public class Cow
    {
        public Cow(string code, string name, string cl)
        {
            cow_code = code;
            cow_name = name;
            cow_class = cl;
        }
        public string cow_code { get; set; }
        public string cow_name { get; set; }
        public string cow_class { get; set; }
    }
}
