using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm_lab1
{
    public partial class Form2 : Form
    {
        Form1 Main;
        public Form2(Form1 fr)
        {
            Main = fr;
            InitializeComponent();
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Main.SendMessageFromSocket(textBox1.Text, 3);
            MessageBox.Show("ФИО добавлено!");
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
    

