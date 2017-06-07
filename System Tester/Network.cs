using System;
using System.Collections.Generic;
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
        private static IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, Model.networkPort);
        public static Dictionary<string, string> neighbors = new Dictionary<string, string>();

        private static void Send(int commandCode, IPEndPoint endPoint)
        {
            char[] sendPack = new char[] { (char)commandCode };
            Send(sendPack, endPoint);
        }

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

        public static void SpeedOutgoingTest(Int64 speedTestLoad)
        {
            
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
                        Model.MainWindow.newNeighbor(ipaddress, netName);
                    }
                    break;
                case (char)0x03:
                    Send(0x04, neighborIP);
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
