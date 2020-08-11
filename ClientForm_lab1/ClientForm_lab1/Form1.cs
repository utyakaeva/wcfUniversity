using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm_lab1
{
    public partial class Form1 : Form
    {
        Socket sender;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Thread Replys = new Thread(new ThreadStart(ReplysLoader));
            Replys.IsBackground = true;
            Replys.Start();
        }
        public void SendMessageFromSocket(string MSG, int type)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством
            // Устанавливаем удаленную точку для сокета
            IPAddress ipAddr = IPAddress.Loopback;
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8005);

            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);
            byte[] msg = Encoding.UTF8.GetBytes(type.ToString() + MSG);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);
            string Answer = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            int caseswitch = Convert.ToInt32(Answer[0].ToString());
            Answer = Answer.Substring(1, Answer.Length - 1);
            switch (caseswitch)
            {
                case 1:
                     textBox4.Text = Answer;
                    break;
                case 2:
                     textBox2.Text = Answer;
                    break;
                case 3:

                    break;
                case 4:
                    listBox1.Invoke(new Action(() => { listBox1.Items.Clear(); }));
                    string[] replys = Answer.Split
                        ('~');
                    foreach (string s in replys)
                    {
                        listBox1.Invoke(new Action(() => { listBox1.Items.Add(s); }));
                    }
                    break;
            }
            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
           // sender.Close();
        }
        private void button2_Click(object sender, EventArgs e)//зодиак
        {
           SendMessageFromSocket(textBox3.Text, 1);
        }

        private void button3_Click(object sender, EventArgs e)//факториал
        {
           SendMessageFromSocket(textBox1.Text, 2);
        }

        private void button1_Click_1(object sender, EventArgs e)//фио
        {
            Form2 fr2 = new Form2(this);
            fr2.ShowDialog();
        }

        public void ReplysLoader()
        {
            while (true)
            {
                SendMessageFromSocket("Ответ по фио", 4);
                Thread.Sleep(5000);
            }
        }
    





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
