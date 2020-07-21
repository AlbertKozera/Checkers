﻿using System;
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
using Warcaby.Forms;
using System.Runtime.CompilerServices;
using Warcaby.CSharp.Config;

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

        public static void SendDataToServer(string[] data, string color)
        {
            if (color != null)
                client.WriteLine(color + "_" + data[0] + "_" + data[1]);
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
            String respondFromServerToAllClients = e.MessageString;
            if (respondFromServerToAllClients.Contains('\u0013'))
                respondFromServerToAllClients = respondFromServerToAllClients.Substring(0, respondFromServerToAllClients.IndexOf('\u0013'));
            if (myColor == null)
                myColor = e.MessageString;
            else
                UpdateGuiAfterRespondFromServer(respondFromServerToAllClients);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateGuiAfterRespondFromServer(string feedback)
        {
            string[] data = feedback.Split('_');

            lock (data)
            {
                if (data[0].Equals("move"))
                {
                    if (data[1].Equals("pawn"))
                        UpdateGuiAfterMovePawn(data[2], int.Parse(data[3]), int.Parse(data[4]));
                    if (data[1].Equals("dame"))
                        UpdateGuiAfterMovePawn(data[2], int.Parse(data[3]), int.Parse(data[4]));
                }
            } 
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateGuiAfterMovePawn(string color, int indexFrom, int indexTo)
        {
            Extend.GetFieldByIndex(indexFrom).Image = Properties.Resources.empty_field;
            if(color.Equals(Constant.WHITE))
                Extend.GetFieldByIndex(indexTo).Image = Properties.Resources.pawn_white;
            else if (color.Equals(Constant.RED))
                Extend.GetFieldByIndex(indexTo).Image = Properties.Resources.pawn_red;
        }

    }
}
