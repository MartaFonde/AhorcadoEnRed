﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhorcadoEnRed
{
    public partial class Form1 : Form
    {
        const string IP_SERVER = "127.0.0.1";
        IPAddress ipServer = IPAddress.Parse(IP_SERVER);
        int port = 31416;
        static internal Socket sServer;

        //comandos
        const string GET_WORD = "getword";
        const string SEND_WORD = "sendword";     //sendword palabra
        const string GET_RECORDS = "getrecords";
        const string SEND_RECORD = "sendrecord";        //sendrecord 00:00 ó sendrecord 00:00 NOM 192.168.0.X
        const string CLOSE_SERVER = "closeserver";      //closeserver clave

        static internal string msgPaServer;
        static internal string msgDeServer;

        static internal string palabra;
        List<char> letras = new List<char>();
        string records;

        Label lblLetra;
        int posYLetra = 100;
        int posXLetra = 15;

        static internal bool palabraNueva = false;
        static internal string tiempoPartida;

        DateTime start;

        string nameUser = "";
        string ipUser;

        public Form1()
        {
            InitializeComponent();            
        }

        private void sendToServer(string msg)
        {
            try
            {                
                using (NetworkStream ns = new NetworkStream(sServer))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    if (msg != null)
                    {
                        sw.WriteLine(msg);
                        sw.Flush();

                        if (msg.StartsWith(SEND_RECORD))
                        {
                            msgDeServer = sr.ReadLine();
                            if (msgDeServer == "True")
                            {
                                if (RequestNameUser())
                                {
                                    msgPaServer = SEND_RECORD + " " + tiempoPartida + " " + nameUser + " " + ipUser;
                                    sw.WriteLine(msgPaServer);
                                    sw.Flush();
                                }
                            }
                        }
                        else
                        {
                            switch (msg)
                            {
                                case GET_WORD:
                                    palabra = sr.ReadLine();
                                    pintarNuevaPalabra();
                                    break;

                                case GET_RECORDS:
                                    records = sr.ReadLine();
                                    MostrarRecords(records);
                                    break;
                            }
                        }

                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error de conexión", "Error");
            }                                                 
        }


        private void MostrarRecords(string records)
        {
            string rec = records.Replace("____", "\r\n");
            MessageBox.Show(rec, "Records");
        }

        private void pintarNuevaPalabra()
        {
            eliminaLabel();            
            letras.Clear();
            for (int i = 0; i < palabra.Length; i++)
            {
                lblLetra = new Label();
                lblLetra.ForeColor = Color.Black;
                lblLetra.Size = new Size(30, 30);
                lblLetra.Location = new Point(posXLetra, posYLetra);
                posXLetra += 40;
                lblLetra.Text = "_";
                lblLetra.Tag = palabra[i];

                if (!letras.Contains(palabra[i]))
                {
                    letras.Add(palabra[i]);
                }

                this.Controls.Add(lblLetra);
            }
            
            posXLetra = 15;
            start = DateTime.Now;
            timer1.Enabled = true;
        }

        void eliminaLabel()
        {
            for (int i = Controls.Count -1 ; i >= 0; i--)
            {
                if(Controls[i] is Label && Controls[i].Name != "lblTimer")
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private bool RequestNameUser()
        {
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.lblErrorName.Text = "";
            bool nameCorrect = false;
            while (!nameCorrect)
            {                
                DialogResult res = f3.ShowDialog();
                if(res == DialogResult.OK)
                {                    
                    if(f3.txtName.Text.Length == 0)
                    {
                        f3.lblErrorName.Text = "Introduce name";
                    }
                    else
                    {                        
                        nameUser = f3.txtName.Text;
                        getIP();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void getIP()
        {
            string localhost = Dns.GetHostName();
            IPHostEntry hostInfo = Dns.GetHostEntry(localhost);
            foreach (IPAddress ip in hostInfo.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipUser = ip.ToString();
                }
            }            
        }

        private void nuevoJuego(object sender, EventArgs e)
        {
            sendToServer(GET_WORD);                                                             
        }

        private void nuevaPalabraMnu_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.lblError.Text = "";
            bool wordCorrect = false;

            while (!wordCorrect)
            {
                DialogResult res = f2.ShowDialog();
                if(res == DialogResult.OK)
                {
                    if(f2.txtWord.Text.Trim().Length > 0)
                    {
                        wordCorrect = true;
                        sendToServer(SEND_WORD + " " + f2.txtWord.Text);
                    }
                    else
                    {
                        f2.lblError.Text = "Introduce new word";
                    }
                }
                else
                {
                    break;
                }
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint ie = new IPEndPoint(ipServer, port);
            sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sServer.Connect(ie);
                sendToServer(GET_WORD);                                
                timer1.Enabled = true;                
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("No connection available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Label && c.Name != "lblTimer")
                {
                    if (c.Tag.ToString() == e.KeyChar.ToString().ToLower())
                    {
                        ((Label)c).Text = c.Tag.ToString();
                        letras.Remove((char)c.Tag);
                    }
                }
            }            
            if (letras.Count == 0)
            {
                timer1.Enabled = false;
                tiempoPartida = lblTimer.Text;
                sendToServer(SEND_RECORD + " " + tiempoPartida);
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dif = DateTime.Now - start;
            lblTimer.Text = string.Format("{0:mm\\:ss}", dif);
        }

        private void showRecordsMnu_click(object sender, EventArgs e)
        {
            sendToServer(GET_RECORDS);
        }
    }
}
