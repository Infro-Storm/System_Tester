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
        private static IPAddress remoteIPAddress = IPAddress.Broadcast;
        public static Dictionary<string, string> neighbors = new Dictionary<string, string>();


        private static void Send(char[] datagram)
        {
            // Создаем UdpClient
            UdpClient sender = new UdpClient();

            // Создаем endPoint по информации об удаленном хосте
            IPEndPoint endPoint = new IPEndPoint(remoteIPAddress, Model.networkPort);

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

        private static void NeighborDiscover()
        {
            while (true)
            {               
                Send(new char[] {(char) 0x01 } );
                Logger.AddText("Discover pack sended.", Message_level.debug, Message_type.debug);
                Thread.Sleep(5000);
            }
        }

        private static void ProtocolProcessor(string msg, IPEndPoint neighborIP)
        {
            switch (msg[0])
            {
                case (char)0x01:
                    string sendPack = (char)0x02 + Environment.MachineName;
                    Send(sendPack.ToCharArray());
                    break;
                case (char)0x02:
                    string ipaddress = neighborIP.Address.ToString();
                    string netName = msg.Substring(1);
                    Logger.AddText("Found neighbor! His name is " + netName  + " " + ipaddress);
                    if (!neighbors.ContainsKey(ipaddress))
                    {
                        neighbors.Add(ipaddress, netName);
                        Model.MainWindow.newNeighbor(ipaddress, netName);
                    }
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
