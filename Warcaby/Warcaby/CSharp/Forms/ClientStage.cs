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

namespace Warcaby.CSharp.Forms
{
    public partial class ClientStage : UserControl
    {
        UCTypeOfGame uCTypeOfGame = new UCTypeOfGame();

        public ClientStage()
        {
            InitializeComponent();
        }

        public static SimpleTcpClient client;
        private void ClientStage_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            //client.DataReceived += Client_DataReceived;
        }



        public static void SendDataToServer(string []data)
        {
            client.WriteLine(data[0] + "_" + data[1]);
            
        }




        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));
            //btnCreateGame.Enabled = false;
            Controls.Clear();
            UCNewGame ucNewGame = new UCNewGame(1);
            Controls.Add(ucNewGame);
            ucNewGame.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));
            //btnJoin.Enabled = false;
            uCTypeOfGame.GoToNewGame(2);
        }


        /*        private void Client_DataReceived(object sender, SimpleTCP.Message e)
                {

                    txtStatus.Invoke((MethodInvoker)delegate ()
                    {
                        txtStatus.Text += e.MessageString;
                    });
                }

                private void btnSend_Click(object sender, EventArgs e)
                {
                    client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
                }*/








    }
}
