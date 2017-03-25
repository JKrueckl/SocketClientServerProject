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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using SocketGuessTrany2017;

namespace CMPE2800_SockGuess_Jkrueckl_JVan
{
    public partial class Form_Client : Form
    {
        //connection to the server
        private Socket _SockConnection = null;

        //recieving thread
        private Thread _T = null;

        //the most recent guess value
        private int _guess = 500;

        public Form_Client()
        {
            InitializeComponent();            
        }

        private void UI_B_ManageConnection_Click(object sender, EventArgs e)
        {
            //there is a connection, terminate the reciever
            if (_SockConnection != null)
            {
                try
                {
                    _SockConnection.Shutdown(SocketShutdown.Both);
                    ReceiverDisconnect();
                }
                catch (Exception exc)
                {
                    UI_TB_Status.Text = "Failed to disconnect. Whodathought?";
                }
                return;
            }

            //create connection
            DLG_Connect connector = new DLG_Connect();
            if (connector.ShowDialog() == DialogResult.OK)
            {
                //save connection
                _SockConnection = connector.Connection;

                //set up game
                ResetGame();

                //connect button now disconnects
                UI_B_ManageConnection.Text = "Disconnect";

                //let user know the game is go
                UI_TB_Status.Text = "Connected to server. Guess the secret number...";

                //allow guessing
                UI_B_Guess.Enabled = true;

                //focus the guess-bar
                UI_TBr_Guess.Focus();

                //spin up reciever
                _T = new Thread(ReceiveThreadMethod);
                _T.IsBackground = true;
                _T.Start(_SockConnection);
            }
        }

        /// <summary>
        /// Packages and sends a guess.
        /// </summary>
        private void UI_B_Guess_Click(object sender, EventArgs e)
        {
            //package guess
            GuessFrame sendFrame = new GuessFrame(UI_TBr_Guess.Value);
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(ms, sendFrame);

                _SockConnection.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);

                //assume success
                _guess = UI_TBr_Guess.Value;
            }
            catch (Exception ex)
            {
                UI_TB_Status.Text = "Failed to send guess.";
            }
        }

        /// <summary>
        /// Displays trackbar value.
        /// </summary>
        private void UI_TBr_Guess_ValueChanged(object sender, EventArgs e)
        {
            UI_LB_TBrValue.Text = UI_TBr_Guess.Value.ToString();
        }

        /// <summary>
        /// Disconnects and dismantles receiver socket.
        /// </summary>
        private void ReceiverDisconnect()
        {
            //socket needs shutdown
            if (_SockConnection != null)
            {
                _SockConnection.Close();
                _SockConnection = null;
            }

            //update connection button and disable guessing
            UI_B_ManageConnection.Text = "Connect";
            UI_B_Guess.Enabled = false;
            ResetGame();
        }

        private void ReceiveThreadMethod(object obj)
        {
            // Possible optimization of how many bytes we need to accept
            byte[] buffer = new byte[2000];
            Socket sock = null;

            try
            {
                sock = (Socket)obj; // Prevent possible cross thread
                sock.ReceiveTimeout = 0;
            }
            catch
            {

            }
            

            while (true)
            {
                int bytes = 0;

                try
                {
                    // blocking receive
                    bytes = sock.Receive(buffer);
                }
                catch (Exception ex)
                {
                    // hard disconnection
                    try
                    {
                        Invoke(new Action(() => UpdateStatus("Disconnected from server.")));
                        Invoke(new Action(() => ReceiverDisconnect()));
                    }
                    catch { } // failed to update UI
                    return; //terminate thread
                }

                // Detection for soft disconnection
                if (bytes == 0)
                {
                    try
                    {
                        Invoke(new Action(() => UpdateStatus("Disconnected from server.")));
                        Invoke(new Action(() => ReceiverDisconnect()));
                    }
                    catch { } // failed to update UI
                    return; //terminate thread
                }

                // Assuming we have the whole information --------------------------------------------------------

                // Recieving
                ReceiveData(buffer);
            }
        }
        
        /// <summary>
        /// In context of receiver thread. Takes in data and performs game updates.
        /// </summary>
        private void ReceiveData(byte[] buffer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            GuessFrame receiveframe = null;

            try
            {
                //attempt serialization
                receiveframe = (GuessFrame)bf.Deserialize(new MemoryStream(buffer));
            }
            catch
            {
                try
                {
                    Invoke(new Action(() => UpdateStatus("Recieved invalid package from server.")));
                    Invoke(new Action(() => ReceiverDisconnect()));
                }
                //failed to update UI
                catch { }

            }

            if (receiveframe != null)
            {
                //update game
                try
                {
                    Invoke(new Action(() => UpdateGame(receiveframe._GuessOrResponse)));
                }
                //failed to update UI
                catch { }
            }
        }

        /// <summary>
        /// Updates game UI elements. UI context.
        /// </summary>
        /// <param name="result">The returned number from the server.</param>
        private void UpdateGame(int result)
        {
            //check return value
            switch (result)
            {
                //guess too low
                case -1:
                    UI_TB_Status.Text = "Your guess was too low!";
                    UI_LB_Min.Text = (_guess + 1).ToString();
                    UI_TBr_Guess.Value = _guess + 1;
                    UI_TBr_Guess.Minimum = _guess + 1;
                    break;

                //guess correct
                case 0:
                    UI_TB_Status.Text = "Correct! Guess a new number...";

                    ResetGame();
                    break;

                //guess too high
                case 1:
                    UI_TB_Status.Text = "Your guess was too high!";
                    UI_LB_Max.Text = (_guess - 1).ToString();
                    UI_TBr_Guess.Value = _guess - 1;
                    UI_TBr_Guess.Maximum = _guess - 1;
                    break;
                default:
                    UI_TB_Status.Text = "Server returned an invalid value.";
                    break;
            }
        }

        /// <summary>
        /// Updates status message.
        /// </summary>
        /// <param name="msg"></param>
        private void UpdateStatus(string msg)
        {
            UI_TB_Status.Text = msg;
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        private void ResetGame()
        {
            //reset guess stuff
            UI_LB_Min.Text = "1";
            UI_LB_Max.Text = "1000";

            UI_TBr_Guess.Minimum = 1;
            UI_TBr_Guess.Maximum = 1000;
            UI_TBr_Guess.Value = 500;
        }
    }
}
