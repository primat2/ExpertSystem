using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BestExpertSystem
{

    // *********************
    // *** Socket Events ***
    // *********************

    public class ClientConnectedEventArgs : EventArgs
    {
        public string NewClient { get; set; }

        public ClientConnectedEventArgs(string _newClient)
        {
            NewClient = _newClient;
        }
    }

    public class TextReceivedEventArgs : EventArgs
    {
        public string ClientWhoSentText { get; set; }
        public string TextReceived { get; set; }
        public TextReceivedEventArgs(string _clientWhoSentText, string _textReceived)
        {
            ClientWhoSentText = _clientWhoSentText;
            TextReceived = _textReceived;
        }
    }

    public class ConnectionDisconnectedEventArgs : EventArgs
    {
        public string DisconnectedPeer { get; set; }

        public ConnectionDisconnectedEventArgs(string _disconnectedPeer)
        {
            DisconnectedPeer = _disconnectedPeer;
        }
    }



    // *********************
    // *** Socket Client ***
    // *********************

    public class SocketClient
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;

        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<ConnectionDisconnectedEventArgs> RaiseServerDisconnected;
        public EventHandler<ConnectionDisconnectedEventArgs> RaiseServerConnected;

        public SocketClient(IPAddress ip, int port)
        {
            mClient = null;
            mServerIPAddress = ip;

            if (port <= 0 || port > 65535)
            {
                throw new Exception("Port number must be between 0 and 65535.");
            }

            mServerPort = port;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool IsConnected { get { return mClient.Connected; } }


        public static IPAddress ResolveHostNameToIPAddress(string strHostName)
        {
            IPAddress[] retAddr = null;

            try
            {
                retAddr = Dns.GetHostAddresses(strHostName);

                foreach (IPAddress addr in retAddr)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return addr;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return null;
        }

        protected virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            if (handler != null)
            {
                handler(this, trea);
            }
        }

        protected virtual void OnRaisePeerDisconnectedEvent(ConnectionDisconnectedEventArgs pdea)
        {
            EventHandler<ConnectionDisconnectedEventArgs> handler = RaiseServerDisconnected;
            if (handler != null)
            {
                handler(this, pdea);
            }
        }

        protected virtual void OnRaisePeerConnectedEvent(ConnectionDisconnectedEventArgs pdea)
        {
            EventHandler<ConnectionDisconnectedEventArgs> handler = RaiseServerConnected;
            if (handler != null)
            {
                handler(this, pdea);
            }
        }


        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                }
            }
        }

        public async Task SendToServer(string strInputUser)
        {
            if (string.IsNullOrEmpty(strInputUser))
            {
                Console.WriteLine("Empty string supplied to send.");
                return;
            }

            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;

                    //await clientStreamWriter.WriteAsync(strInputUser);
                    await clientStreamWriter.WriteLineAsync(strInputUser);
                    Console.WriteLine("Data sent...");
                }
            }

        }

        public async Task ConnectToServer(ManualResetEvent valueGetEvent)
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }

            Task t = mClient.ConnectAsync(mServerIPAddress, mServerPort);
            t.Wait();
            Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}",
                mServerIPAddress, mServerPort));

            valueGetEvent.Set();

            //RaiseServerConnected(this, new ConnectionDisconnectedEventArgs(
            //    Convert.ToString(mClient.Client.RemoteEndPoint))
            //    );


            //ReadLineAsync(mClient);
            

            //try
            //{
            //    Task t =  mClient.ConnectAsync(mServerIPAddress, mServerPort);
            //    t.Wait();
            //    Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}",
            //        mServerIPAddress, mServerPort));

            //    RaiseServerConnected(this, new ConnectionDisconnectedEventArgs(
            //        Convert.ToString(mClient.Client.RemoteEndPoint))
            //        );


            //    ReadLineAsync(mClient);
            //    valueGetEvent.Set();
            //}
            //catch (Exception excp)
            //{
            //    Console.WriteLine(excp.ToString());
            //    throw;
            //}
        }

        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        OnRaisePeerDisconnectedEvent(new ConnectionDisconnectedEventArgs(Convert.ToString(mClient.Client.RemoteEndPoint)));
                        mClient.Close();
                        break;
                    }
                    Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}",
                        readByteCount, new string(buff)));

                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(Convert.ToString(mClient.Client.RemoteEndPoint), new string(buff)));


                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }


        public async Task ReadLineAsync(Action<TransferObj> onCallback)
        {

            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                string receivedLine = string.Empty;

                while (true)
                {
                    //receivedLine = await clientStreamReader.ReadLineAsync();

                    bool end = false;
                    while (!end)
                    {
                        string newLine = await clientStreamReader.ReadLineAsync();
                        if (newLine == "!") break;

                        receivedLine += newLine;
                    }

                    var trO = JsonSerializer.Deserialize<TransferObj>(receivedLine);

                    if (receivedLine.Length <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        OnRaisePeerDisconnectedEvent(new ConnectionDisconnectedEventArgs(Convert.ToString(mClient.Client.RemoteEndPoint)));
                        mClient.Close();
                        break;
                    }

                    Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}",
                        receivedLine.Length, receivedLine));

                    onCallback.Invoke(trO);
                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(Convert.ToString(mClient.Client.RemoteEndPoint),receivedLine));

                    receivedLine = string.Empty;
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                //throw;
            }
        }
    }
}
