using Server.CSharp.Dto;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warcaby.Service.Context;

namespace Server
{
    public partial class ServerStage : Form
    {
        GameService gameService = new GameService();
        public Player playerWhite;
        public Player playerRed;
        public int roomIsFull = 0;

        public ServerStage()
        {
            InitializeComponent();
        }

        public static SimpleTcpServer server;
        private void ServerStage_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }


        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatusServer.Invoke((MethodInvoker)delegate ()
            {
                string id = GetClientID(e);
                txtStatusServer.AppendText(Environment.NewLine);
                String dataFromClient = e.MessageString;
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf('\u0013'));

                if(roomIsFull < 2)
                {
                    CheckIfHostEnter(dataFromClient, e);
                    CheckIfGuestJoin(dataFromClient, e);
                    roomIsFull++;
                }
                else
                {
                    string color = getDataFromClient(dataFromClient, "color");
                    int indexFrom = int.Parse(getDataFromClient(dataFromClient, "indexFrom"));
                    int indexTo = int.Parse(getDataFromClient(dataFromClient, "indexTo"));


                    gameService.GameChooser(indexFrom, indexTo, color, 1);
                }


                UpdateConsoleLogs(dataFromClient, id);
                AssignColorsToClients(e);
            });
        }

        public void AssignColorsToClients(SimpleTCP.Message e)
        {
            if (playerWhite != null && playerWhite.id == GetClientID(e))
            {
                e.Reply(playerWhite.color);
            }
            else if (playerRed != null && playerRed.id == GetClientID(e))
            {
                e.Reply(playerRed.color);
            }
        }




        public void UpdateConsoleLogs(string dataFromClient, string id)
        {
            txtStatusServer.Text += dataFromClient;
            txtStatusServer.SelectionStart = txtStatusServer.Text.Length;
            txtStatusServer.ScrollToCaret();
        }

        public void CheckIfHostEnter(String dataFromHost, SimpleTCP.Message e)
        {
            if (dataFromHost.Contains("HOST"))
            {
                string color = dataFromHost.Substring(dataFromHost.IndexOf('_') + 1);
                string id = ((IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Port.ToString();
                if (color.Equals("white"))
                    playerWhite = new Player(id, color);
                else
                    playerRed = new Player(id, color);
            }
        }

        public void CheckIfGuestJoin(String dataFromGuest, SimpleTCP.Message e)
        {
            if (dataFromGuest.Contains("GUEST"))
            {
                string id = ((IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Port.ToString();
                if (playerWhite == null)
                    playerWhite = new Player(id, "white");
                else if (playerRed == null)
                    playerRed = new Player(id, "red");
            }
        }

        public string GetClientID(SimpleTCP.Message e)
        {
            return ((IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Port.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatusServer.AppendText(Environment.NewLine);
            txtStatusServer.Text += "Server starting...";
            IPAddress ip = IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));
            txtStatusServer.AppendText(Environment.NewLine);
            txtStatusServer.Text += "Server is working...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
            txtStatusServer.AppendText(Environment.NewLine);
            txtStatusServer.Text += "Server is down...";
        }

        public int GetNumberOfConnectedClients()
        {
            return server.ConnectedClientsCount;
        }

        public string getDataFromClient(string dataFromClient, string typeOfData)
        {
            string[] data = dataFromClient.Split('_');

            if (typeOfData.Equals("color"))
                return data[0];
            if (typeOfData.Equals("indexFrom"))
                return data[1];
            if (typeOfData.Equals("indexTo"))
                return data[2];
            return null;
        }

        public static void SendRespondToClient(string respond)
        {
            server.Broadcast("");
            server.BroadcastLine(respond);
        }
    }
}
