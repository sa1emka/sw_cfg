using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {


        public static void Main(string[] args)
        {
            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("Введите порт:");
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine("[" + i.ToString() + "] " + ports[i].ToString());
            }
            port = new SerialPort();
            string n = Console.ReadLine();
            int num = int.Parse(n);
            try
            {
                // настройки порта
                port.PortName = ports[num];
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.Handshake = Handshake.None;
                port.ReadTimeout = 100;
                port.WriteTimeout = 100;


                port.Open();
                port.DiscardOutBuffer();
                port.DiscardInBuffer();

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: невозможно открыть порт:" + e.ToString());
                return;
            }



            string komplekt, shkaf, sw, pathToFile, oper, pathToSetting;
            Console.WriteLine("Введите путь к папке c настройками");
            pathToSetting = Console.ReadLine();
            pathToFile = @"";

            Console.WriteLine("Операция:\n[1] Настройка\n[2] Сброс");
            oper = Console.ReadLine();
            switch (oper)
            {
                case "1":
                    Console.WriteLine("Номер комплекта:\n[1] Первый комплект\n[2] Второй комплект");
                    komplekt = Console.ReadLine();
                    switch (komplekt)
                    {
                        case "1":
                            Console.WriteLine("Название шкафа:\n[1] ШСР\n[2] ДРЕГ");
                            shkaf = Console.ReadLine();
                            switch (shkaf)
                            {
                                case "1":
                                    Console.WriteLine("Номер коммутатора:\n[1] Коммутатор №1\n[2] Коммутатор №2\n[3] Коммутатор №3");
                                    sw = Console.ReadLine();
                                    switch (sw)
                                    {
                                        case "1":
                                            pathToFile = pathToSetting + @"SHSR1\SHSR1_SW1.txt";

                                            break;

                                        case "2":
                                            pathToFile = pathToSetting + @"SHSR1\SHSR1_SW2.txt";
                                            break;

                                        case "3":
                                            pathToFile = pathToSetting + @"SHSR1\SHSR1_SW1.txt";
                                            break;
                                        default:
                                            return;
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Номер коммутатора:\n[1] Коммутатор №1\n[2] Коммутатор №2\n[3] Коммутатор №3");
                                    sw = Console.ReadLine();
                                    switch (sw)
                                    {
                                        case "1":
                                            pathToFile = pathToSetting + @"DREG1\DREG1_SW1.txt";
                                            break;

                                        case "2":
                                            pathToFile = pathToSetting + @"DREG1\DREG1_SW2.txt";
                                            break;

                                        case "3":
                                            pathToFile = pathToSetting + @"DREG1\DREG1_SW1.txt";
                                            break;
                                        default:
                                            return;
                                    }

                                    break;
                                default:
                                    return;

                            }


                            break;


                        case "2":
                            Console.WriteLine("Название шкафа:\n[1] ШСР\n[2] ДРЕГ");
                            shkaf = Console.ReadLine();
                            switch (shkaf)
                            {
                                case "1":
                                    Console.WriteLine("Номер коммутатора:\n[1] Коммутатор №1\n[2] Коммутатор №2\n[3] Коммутатор №3");
                                    sw = Console.ReadLine();
                                    switch (sw)
                                    {
                                        case "1":
                                            pathToFile = pathToSetting + @"SHSR2\SHSR2_SW1.txt";
                                            break;

                                        case "2":
                                            pathToFile = pathToSetting + @"SHSR2\SHSR2_SW2.txt";
                                            break;

                                        case "3":
                                            pathToFile = pathToSetting + @"SHSR2\SHSR2_SW3.txt";
                                            break;
                                        default:
                                            return;
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Номер коммутатора:\n[1] Коммутатор №1\n[2] Коммутатор №2\n[3] Коммутатор №3");
                                    sw = Console.ReadLine();
                                    switch (sw)
                                    {
                                        case "1":
                                            pathToFile = pathToSetting + @"DREG2\DREG2_SW1.txt";
                                            break;

                                        case "2":
                                            pathToFile = pathToSetting + @"DREG2\DREG2_SW2.txt";
                                            break;

                                        case "3":
                                            pathToFile = pathToSetting + @"DREG2\DREG2_SW3.txt";
                                            break;
                                        default:
                                            return;
                                    }

                                    break;
                                default:
                                    return;


                            }


                            break;
                        default:
                            return;

                    }


                    break;

                case "2":
                    {
                        pathToFile = pathToSetting + @"1.txt";
                        break;
                    }
                default:
                    return;



            }

            String[] text = File.ReadAllLines(pathToFile);

            for (int i = 0; i < text.Length; i++)
            {
                //Console.WriteLine(text[i]);
                port.Write(text[i] + "\n");

                for (int j = 4; j <= 400; j++)
                {
                Console.WriteLine(j/4+"%");
                Console.Clear();
                
                }

                    //Console.ReadKey();

                }


                port.Close();

                Console.Clear();
                Console.WriteLine("Операция завершена, нажмите любую клавишу");
                Console.ReadKey();    
            }





        }
    }


