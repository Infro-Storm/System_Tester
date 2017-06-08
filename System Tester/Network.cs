using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Tester
{
    class Network
    {
        private const int BUFFER_SIZE = 1024;
        private const int TASK_LOAD = 5000;
        private static IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, Model.networkPort);
        public static Dictionary<string, string> neighbors = new Dictionary<string, string>();
        private static bool send_next = false;
        private static Random rnd = new Random();
        private static IPEndPoint selectedNeiborEndPoint;
        private static IPEndPoint FirstNeiborEndPoint;
        private static void Send(int commandCode, IPEndPoint endPoint)
        {
            char[] sendPack = new char[] { (char)commandCode };
            Send(sendPack, endPoint);
        }
        //public static void set

        private static void Send(int commandCode, string message, IPEndPoint endPoint)
        {
            string sendPack = (char)commandCode + message;
            Send(sendPack, endPoint);
        }

        private static void Send(string str, IPEndPoint endPoint)
        {
            Send(str.ToCharArray(), endPoint);
        }
        private static void Send(char[] datagram, IPEndPoint endPoint)
        {
            // Создаем UdpClient
            UdpClient sender = new UdpClient();
            endPoint.Port = Model.networkPort;

            try
            {
                // Преобразуем данные в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(datagram);

                // Отправляем данные
                sender.Send(bytes, bytes.Length, endPoint);
            }
            catch (Exception ex)
            {
                Logger.AddText("Возникло исключение передачи данных: " + ex.ToString(), Message_level.normal, Message_type.error);
            }
            finally
            {
                // Закрыть соединение
                sender.Close();
            }
        }

        public static void StartSpeedTest()
        {
            Logger.AddText("Starting bandwidth test...", Message_level.debug, Message_type.info);
            if (FirstNeiborEndPoint == null)
            {
                Model.MainWindow.ShowMessage("Сетевое соедиенение", "Нет сетевого соединения!", Message_type.error);
                return;
            }
                if (selectedNeiborEndPoint == null)selectedNeiborEndPoint = FirstNeiborEndPoint;
            
            BandwidthTestSend(TASK_LOAD, selectedNeiborEndPoint);
            Logger.AddText("Bandwidth test finished!", Message_level.debug, Message_type.info);
        }

        public static void BandwidthTestSend(Int64 speedTestLoad, IPEndPoint ep)
        {
            Stopwatch watchdog = new Stopwatch();
            Stopwatch timer = new Stopwatch();
            List<DeviceForView> btest = new List<DeviceForView>();
            send_next = true;
            timer.Start();
            byte[] rnd_buff = new byte[BUFFER_SIZE];
            for (int i = 0; i < speedTestLoad; i++)
            {

                rnd.NextBytes(rnd_buff);
                watchdog.Start();
                while (!send_next && watchdog.ElapsedMilliseconds < 1000) ;
                watchdog.Stop();
                string result = System.Text.Encoding.UTF8.GetString(rnd_buff);
                char[] send_arr = result.ToCharArray();
                send_arr[0] = (char)0x03;
                Send(send_arr, ep);
                send_next = false;
            }
            timer.Stop();
            btest.Add(new DeviceForView("Результат тестирования ТВС", Model.ValueСonvert(BUFFER_SIZE * TASK_LOAD / timer.ElapsedMilliseconds * 1000 * 8, "бит/сек", 1024), ""));
            Model.MainWindow.SetInfo(btest, TabOfProgramm.general, "Результат тестирования");

        }

        private static void NeighborDiscover()
        {
            while (true)
            {               
                Send(0x01, broadcastEndPoint );
                Logger.AddText("Discover pack sended.", Message_level.debug, Message_type.debug);
                Thread.Sleep(5000);
            }
        }

        public static void SetNeighbor(string str)
        {
            SetNeighbor(new IPEndPoint(IPAddress.Parse(str), Model.networkPort));
        }

        public static void SetNeighbor(IPEndPoint ep)
        {
            ep.Port = Model.networkPort;
            selectedNeiborEndPoint = ep;
        }

        public static void SetFirstNeighbor(IPEndPoint ep)
        {
            ep.Port = Model.networkPort;
            FirstNeiborEndPoint = ep;
        }

        private static void ProtocolProcessor(string msg, IPEndPoint neighborIP)
        {
            string ipaddress = neighborIP.Address.ToString();
            switch (msg[0])
            {
                case (char)0x01:
                    Send(0x02, Environment.MachineName,  neighborIP);
                    Logger.AddText("Discovery pack: " + ipaddress);
                    break;
                case (char)0x02:
                    string netName = msg.Substring(1);
                    Logger.AddText("Found neighbor! His name is " + netName  + " " + ipaddress);
                    if (!neighbors.ContainsKey(ipaddress))
                    {
                        neighbors.Add(ipaddress, netName);
                        Model.MainWindow.NewNeighbor(ipaddress, netName);
                        if (FirstNeiborEndPoint == null) SetFirstNeighbor(neighborIP);
                    }
                    break;
                case (char)0x03:
                    Send(0x04, neighborIP);
                    break;
                case (char)0x04:
                    send_next = true;
                    break;
                default:
                    Logger.AddText("System Tester network protocol error! Recived invalid pack: " + msg, Message_level.normal, Message_type.error);
                    break;
            }
        }

        public static void Receiver()
        {
            // Создаем UdpClient для чтения входящих данных
            Logger.AddText("Start neighbor seacher...", Message_level.debug, Message_type.debug);
            Thread neighborDiscover = new Thread(NeighborDiscover);
            neighborDiscover.Start();
            try
            {
                UdpClient receivingUdpClient = new UdpClient(Model.networkPort);
                Logger.AddText("Waiting neighbor answers...", Message_level.debug, Message_type.debug);
                IPEndPoint RemoteIpEndPoint = null;
                while (true)
                {
                    // Ожидание дейтаграммы
                    byte[] receiveBytes = receivingUdpClient.Receive(
                       ref RemoteIpEndPoint);

                    // Преобразуем и отображаем данные
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    ProtocolProcessor(returnData, RemoteIpEndPoint);
                }
            }
            catch (Exception ex)
            {
                Logger.AddText("Возникло исключение приема данных: " + ex.ToString(), Message_level.normal, Message_type.error);
            }
        }
    }
}
