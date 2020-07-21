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
                txtStatusServer.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatusServer.Text += "Server starting...";
            IPAddress ip = IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
            // server.BroadcastLine("maaaaaaaar");
        }
    }
}
