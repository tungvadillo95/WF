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
    public partial class Form1 : Form
    {
        public Form2 form2;
        public string txbox1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2(c1TextBox1.Text, this);
            form2.ShowDialog();
            c1TextBox1.Text = txbox1;
        }
    }
}
