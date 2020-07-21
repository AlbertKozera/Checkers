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
        public ClientStage()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void ClientStage_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            //client.DataReceived += Client_DataReceived;
        }





        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));
            btnCreateGame.Enabled = false;
            client.WriteLine("_23_46_");
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Int32.Parse(txtPort.Text));
            btnJoin.Enabled = false;
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
