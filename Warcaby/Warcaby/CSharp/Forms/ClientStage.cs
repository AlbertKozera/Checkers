using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;
using System.Net;

namespace Warcaby.CSharp.Forms
{
    public partial class ClientStage : UserControl
    {
        UCTypeOfGame uCTypeOfGame = new UCTypeOfGame();
        public static string myColor;

        public ClientStage()
        {
            InitializeComponent();
        }

        public static SimpleTcpClient client;
        private void ClientStage_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        public static void SendDataToServer(string[] data)
        {
            client.WriteLine(data[0] + "_" + data[1]);
        }

        public static void SendMessageToServer(string message)
        {
            client.WriteLine(message);
        }

        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));

            string color;
            if (checkBoxWhiteTurn.Checked)
                color = "white";
            else
                color = "red";
            client.WriteLine("HOST" + "_" + color);

            Controls.Clear();
            UCNewGame ucNewGame = new UCNewGame(1);
            Controls.Add(ucNewGame);
            ucNewGame.Show();

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {


            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));
            client.WriteLine("GUEST");


            Controls.Clear();
            UCNewGame ucNewGame = new UCNewGame(1);
            Controls.Add(ucNewGame);
            ucNewGame.Show();

        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            myColor = e.MessageString;
        }

  

    }
}
