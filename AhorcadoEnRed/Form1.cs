using System;
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
        static readonly internal object l = new object();
        const string IP_SERVER = "127.0.0.1";
        IPAddress ip = IPAddress.Parse(IP_SERVER);
        int port = 31416;
        Socket sServer;

        //comandos
        const string GET_WORD = "getword";
        const string SEND_WORD = "sendword";     //sendword palabra
        const string GET_RECORDS = "getrecords";
        const string SEND_RECORD = "sendrecord";
        const string CLOSE_SERVER = "closeserver";

        string msgPaServer;
        string msgDeServer;

        string palabra;
        List<char> letras = new List<char>();

        bool running = true;
        Label lblLetra;
        int posYLetra = 100;
        int posXLetra = 15;

        bool palabraNueva = false;
        DateTime start;
        int numAciertos = 0;
        int numLetras;

        public Form1()
        {
            InitializeComponent();            
        }

        void HiloClient()
        {
            while (running)
            {
                lock (l)
                {                    
                    using (NetworkStream ns = new NetworkStream(sServer))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        try
                        {
                            if (msgPaServer != null)
                            {
                                sw.WriteLine(msgPaServer);
                                sw.Flush();

                                if (msgPaServer.StartsWith(SEND_RECORD))
                                {
                                    msgDeServer = sr.ReadLine();

                                    MessageBox.Show(msgDeServer);

                                    if(msgDeServer == "True")
                                    {
                                        msgPaServer = SEND_RECORD +" "+ lblTimer.Text + " AAA " + "192.168.0.1";     //pedir nombre
                                        sw.WriteLine(msgPaServer);
                                        sw.Flush();
                                        //pedir palabra nueva
                                    }
                                }
                                else
                                {
                                    switch (msgPaServer)
                                    {
                                        case GET_WORD:
                                            palabra = sr.ReadLine();
                                            palabraNueva = true;
                                            Monitor.Pulse(l);
                                            break;

                                            //case SEND_RECORD:

                                            //    break;

                                    }
                                }

                                

                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Error de conexión", "Error");
                            running = false;
                        }                                               
                    }
                    
                    Monitor.Wait(l);        //PROBLEMA se se cerra o server queda en Wait
                }                               
            }           
        }

        private void pintarNuevaPalabra()
        {
            eliminaLabel();
            lock (l)
            {
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
                numLetras = palabra.Length;
                palabraNueva = true;
                numAciertos = 0;

            }
            posXLetra = 15;
            start = DateTime.Now;
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

        private void nuevoJuego(object sender, EventArgs e)
        {
            msgPaServer = GET_WORD;
            lock (l)
            {
                Monitor.Pulse(l);
                while (!palabraNueva)
                {                    
                    Monitor.Wait(l);
                    pintarNuevaPalabra();                    
                }
                palabraNueva = false;
            }
        }

        private void nuevaPalabraMnu_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
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
                        msgPaServer = SEND_WORD+" "+f2.txtWord.Text;
                        lock (l)
                        {
                            Monitor.Pulse(l);
                        }
                    }
                }
                else
                {
                    f2.lblError.Text = "Introduce new word";
                }
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint ie = new IPEndPoint(ip, port);
            sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sServer.Connect(ie);
                msgPaServer = GET_WORD;                
                Thread threadClient = new Thread(HiloClient);
                threadClient.Start();

                while (!palabraNueva)
                {
                    lock (l)
                    {                                            
                        Monitor.Wait(l);
                        pintarNuevaPalabra();
                        palabraNueva = true;
                    }
                }
                
                timer1.Enabled = true;
                lock (l)
                {
                    palabraNueva = false;
                }
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
                    if ((char)c.Tag == e.KeyChar)
                    {
                        ((Label)c).Text = c.Tag.ToString();
                        letras.Remove((char)c.Tag);
                    }
                }
            }
            lock (l)
            {
                if (letras.Count == 0)
                {
                    msgPaServer = SEND_RECORD + " " + lblTimer.Text;
                    Monitor.Pulse(l);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dif = DateTime.Now - start;
            lblTimer.Text = string.Format("{0:mm\\:ss}", dif);
        }
    }
}
