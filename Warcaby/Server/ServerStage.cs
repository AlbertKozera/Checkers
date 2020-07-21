using Server.CSharp.Dto;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerStage : Form
    {
        public Player playerWhite;
        public Player playerRed;

        public ServerStage()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        private void ServerStage_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; //enter
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

                
                CheckIfHostEnter(dataFromClient, e);
                CheckIfGuestJoin(dataFromClient, e);

                UpdateConsoleLogs(dataFromClient, id);


                //  e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        public void UpdateConsoleLogs(string dataFromClient, string id)
        {
            if (id.Equals(playerWhite.id))
                txtStatusServer.Text += "white - ";
            else
                txtStatusServer.Text += "red - ";
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
                string id = ((System.Net.IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Port.ToString();
                if (playerWhite.Equals("null"))
                    playerWhite = new Player(id, "white");
                else
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
            // server.BroadcastLine("aaa");
        }
    }
}
