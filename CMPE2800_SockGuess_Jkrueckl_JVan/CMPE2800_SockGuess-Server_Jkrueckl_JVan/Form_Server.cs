using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using SocketGuessTrany2017;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CMPE2800_SockGuess_Server_Jkrueckl_JVan
{
    public partial class Form_Server : Form
    {
        static Random _Rnd = new Random();

        Socket _SockListen = null;
        Socket _SockConnected = null;

        Thread _T;

        private delegate void delVoidSocket(Socket s);
        private delegate void delVoidString(string s);        

        public Form_Server()
        {
            InitializeComponent();
        }

        private void Form_Server_Shown(object sender, EventArgs e)
        {
            if (_SockListen == null)
                SetupListener();
            else
                LogError("Socket already exists.");
        }

        private void LogError(Exception ex)
        {
            UI_LB_Log.Items.Add(DateTime.Now + " : " + ex.ToString());
        }
        private void LogError(string ex)
        {
            UI_LB_Log.Items.Add(DateTime.Now + " : " + ex);
        }

        private void SetupListener()
        {
            // Re-create sockets
            _SockConnected = null;
            _SockListen = null;

            // Create Socket
            try
            {
                _SockListen = new Socket(
                    AddressFamily.InterNetwork, // IP V4
                    SocketType.Stream,          // Connection based socket
                    ProtocolType.Tcp);          // TCP procol
            }
            catch (Exception ex) { LogError("Failed to create listener."); return; }

            // Bind to endport
            try
            {
                _SockListen.Bind(new IPEndPoint(IPAddress.Any, 1666));
            }
            catch (Exception ex) { LogError("Failed to Bind to port. Closing in 10 seconds.");
                ExitTimer.Enabled = true;
                return;
            }

            // start listening
            try
            {
                _SockListen.Listen(5);
            }
            catch (Exception ex) { LogError("Failed to set socket to listener."); return; }

            // Waiting for connection
            try
            {
                _SockListen.BeginAccept(CallbackAccept, _SockListen);
            }
            catch (Exception ex) { LogError("Failed to begin accepting connections on the listener socket."); return; }

            //assume success
            LogError("Listening on port 1666.");
        }

        private void CallbackAccept(IAsyncResult ar)
        {
            // Prevent cross threading
            Socket soc = (Socket)ar.AsyncState;

            try
            {
                // Create connected socket
                Socket connectedSocket = soc.EndAccept(ar);

                // connection made, spin up reciever thread
                Invoke(new delVoidSocket(SetupReceiver), connectedSocket);
            }
            catch (Exception ex)
            {
                Invoke(new delVoidString(HandleError), ex.Message);
            }
        }

        private void SetupReceiver(Socket sock)
        {
            //dispose of listener
            try
            {
                _SockListen.Close();
            }
            catch (Exception ex) { LogError("Failed to dispose of listener after connection made"); }

            LogError("Successful connection made with : " + sock.RemoteEndPoint);

            if(_SockConnected == null)
                _SockConnected = sock;

            // Start main receive thread
            _T = new Thread(ReceiveThreadMethod);
            _T.IsBackground = true;
            _T.Start(_SockConnected);
        }

        private void HandleError(string errorMessage)
        {
            LogError(errorMessage);

            SetupListener();
        }

        private void ReceiveThreadMethod(object obj)
        {
            // Possible optimization of how many bytes we need to accept
            byte[] buffer = new byte[2000];

            int gameNumber = _Rnd.Next(1, 1001);

            Socket sock = (Socket)obj; // Prevent possible cross thread

            sock.ReceiveTimeout = 0;

            while(true)
            {
                // Make sure label is the game number and display it safetly
                Invoke(new Action(() => UI_L_GeneratedNumber.Text = gameNumber.ToString()));

                int bytes = 0;

                try
                {
                    // blocking receive
                    bytes = sock.Receive(buffer);
                }
                catch (Exception ex)
                {
                    // hard disconnection
                    Invoke(new Action(() => ReceiverDisconnect("RecieveThreadMethod : Hard disconnection detected")));
                    return;
                } 

                // Detection for soft disconnection
                if(bytes == 0)
                {
                    Invoke(new Action(() => ReceiverDisconnect("RecieveThreadMethod : Soft disconnection detected")));
                    return;
                }

                // Assuming we have the whole information --------------------------------------------------------

                // Recieving
                BinaryFormatter bf = new BinaryFormatter();
                GuessFrame receiveframe = null;

                try
                {
                    receiveframe = (GuessFrame)bf.Deserialize(new MemoryStream(buffer));
                }
                catch(Exception ex)
                {
                    try
                    {
                        Invoke(new Action(() => LogError("The data recieved is not the correct type.")));
                    }
                    catch{ Console.WriteLine("Got some real problems on line 193 : Form_Server"); }
                }

                if (receiveframe != null)
                {
                    try
                    {
                        Invoke(new Action(() => LogError("The data recieved is : " + receiveframe._GuessOrResponse)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Got some real problems on line 204 : Form_Server");
                    }

                    // Sending
                    GuessFrame sendFrame = new GuessFrame(receiveframe._GuessOrResponse.CompareTo(gameNumber));
                    MemoryStream ms = new MemoryStream();
                    try
                    {
                        bf.Serialize(ms, sendFrame);

                        try
                        {
                            Invoke(new Action(() => LogError(
                                "The data sent is : " + receiveframe._GuessOrResponse.CompareTo(gameNumber))));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Got some real problems on line 212 : Form_Server");
                        }

                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Invoke(new Action(() => LogError("Problems serializing the send frame")));
                        }
                        catch
                        {
                            Console.WriteLine("Got some real problems on line 224 : Form_Server");
                        }
                    }

                    try
                    {
                        sock.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Invoke(new Action(() => LogError("Error sending the frame.")));
                        }
                        catch
                        {
                            Console.WriteLine("Got some real problems on line 225 : Form_Server");
                        }
                    }

                    // Start new game!
                    if (receiveframe._GuessOrResponse.CompareTo(gameNumber) == 0)
                    {
                        gameNumber = _Rnd.Next(1, 1001);
                        try
                        {
                            Invoke(new Action(() => LogError("The client guessed the correct number : ")));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Got some real problems on line 254 : Form_Server");
                        }
                    }
                }
                else
                {
                    Invoke(new Action(() => ReceiverDisconnect("ReceiveThreadMethod : Received wrong frame type, booted client")));
                    return;
                }               
            }
        }

        /// <summary>
        /// Shuts down and recycles the connection socket.
        /// </summary>
        /// <param name="reason"></param>
        private void ReceiverDisconnect(string reason)
        {
            LogError(reason);

            _SockConnected.Close();
            _SockConnected = null;

            SetupListener();
        }

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
