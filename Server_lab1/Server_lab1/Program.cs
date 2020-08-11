using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Server_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Устанавливаем для сокета локальную конечную точку
            //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            //IPAddress ipAddr = ipHost.AddressList[0];
            IPAddress ipAddr = IPAddress.Loopback;
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8005);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;
                    // Мы дождались клиента, пытающегося с нами соединиться
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    // Получили данные

                    int switchcase = Convert.ToInt32(data[0].ToString());
                    data = data.Substring(1, data.Length - 1);
                    Console.WriteLine("Получено: " + data);
                    switch (switchcase)
                    {
                        case 3:
                         Console.WriteLine("Операция - Добавление ФИО");
                    Reply(data);
                    byte[] msg2 = Encoding.UTF8.GetBytes("3");
                    handler.Send(msg2);
                    Console.WriteLine("ФИО добавлено!");
                    break;
                        case 2:

                            Console.WriteLine("Операция - Факториал");
                            int Fact = 1;
                            for (int i = 2; i <= Convert.ToInt32(data); i++)
                            {
                                Fact = Fact * i;
                            }
                            string reply = Fact.ToString();
                            byte[] msg = Encoding.UTF8.GetBytes("2" + reply);
                            handler.Send(msg);
                            Console.WriteLine("Ответ:" + reply);
                            break;
                        case 1:
                            Console.WriteLine("Операция - Название месяца");
                            string reply1 = monts(Convert.ToInt32(data));
                            byte[] msg1 = Encoding.UTF8.GetBytes("1" + reply1);
                            handler.Send(msg1);
                            Console.WriteLine("Ответ:" + reply1);
                            break;
                            

                        case 4:
                            Console.WriteLine("Операцию - Обновление списка данных");
                            try
                            {
                                FileStream bFile = new FileStream("ФИО.txt", FileMode.OpenOrCreate);
                                StreamReader sr = new StreamReader(bFile, Encoding.Default);
                                string replys = "";
                                string str = sr.ReadLine();
                                while (str != null)
                                {
                                    replys = replys + str + "~";
                                    str = sr.ReadLine();
                                }
                                sr.Close();
                                byte[] msg3 = Encoding.UTF8.GetBytes("4" + replys);
                                handler.Send(msg3);
                            }
                            catch
                            {
                                byte[] msg3 = Encoding.UTF8.GetBytes("5");
                                handler.Send(msg3);

                            }
                            break;
                    }
                    Console.WriteLine("Готово!");
                    // Отправляем ответ клиенту\

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        static string monts(int d)
        {
            
          if (d == 1 ) return "Январь";
            if (d == 2) return "Февраль";
            if (d == 3) return "Март";
            if (d == 4) return "Апрель";
            if (d == 5) return "Май";
            if (d == 6) return "Июнь";
            if (d == 7) return "Июль";
            if (d == 8) return "Август";
            if (d == 9) return "Сентябрь";
            if (d == 10) return "Октябрь";
            if (d == 11) return "Ноябрь";
            if (d == 12) return "Декабрь";
            else return "Введите число от 1 до 12!";


            
        }
        static void Reply(string data)
        {
            System.IO.File.Delete("Reply.txt");
            FileStream bFile = new FileStream("ФИО.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(bFile, Encoding.Default);
            string date = DateTime.Now.ToString();
            sw.WriteLine("[" + date + "] " + data);
            sw.Close();
        }
    }
}