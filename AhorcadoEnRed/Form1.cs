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

        string msgToServer;
        string msgFromServer;

        string word;
        List<char> letters = new List<char>();
        string records;
        Label lblLetter;
        int posY = 100;
        int posX = 15;
        string timeGame;
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
                        sw.WriteLine(msg.Trim());
                        sw.Flush();

                        if (msg.StartsWith(SEND_RECORD))
                        {
                            msgFromServer = sr.ReadLine();
                            if (msgFromServer == "True")
                            {
                                if (requestNameUserIP())
                                {
                                    msgToServer = SEND_RECORD + " " + timeGame + " " + nameUser + " " + ipUser;
                                    sw.WriteLine(msgToServer);
                                    sw.Flush();
                                }
                            }
                        }else if (msg.StartsWith(SEND_WORD))
                        {
                            string resp = sr.ReadLine();
                            if(resp == "True")
                            {
                                MessageBox.Show("Word(s) added correctly", "Add word(s)");
                            }
                            else
                            {
                                MessageBox.Show("Error adding word(s)", "Error");
                            }
                        }
                        else if (msg.StartsWith(CLOSE_SERVER))
                        {
                            msgFromServer = sr.ReadLine();
                            if(msgFromServer == "True")
                            {
                                MessageBox.Show("Password correct. Server closed.", "Close server");
                            }
                            else
                            {
                                MessageBox.Show("Password incorrect. Server still alive.", "Close server");
                            }
                        }
                        else
                        {
                            switch (msg)
                            {
                                case GET_WORD:
                                    word = sr.ReadLine();
                                    if(word.Length > 0)
                                    {
                                        drawNewWord();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No words in server. Introduce new words", "Error");
                                    }
                                    
                                    break;

                                case GET_RECORDS:
                                    records = sr.ReadLine();
                                    showRecords(records);
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

        private void sendWordMnu_click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.lblError.Text = "";
            bool wordCorrect = false;

            while (!wordCorrect)
            {
                DialogResult res = f2.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (f2.txtWord.Text.Trim().Length > 0)
                    {
                        wordCorrect = true;
                        sendToServer(SEND_WORD + " " + f2.txtWord.Text.ToLower());
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

        void removeLabelsWord()
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is Label && Controls[i].Name != "lblTimer")
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private void drawNewWord()
        {
            removeLabelsWord();
            letters.Clear();
            for (int i = 0; i < word.Length; i++)
            {
                lblLetter = new Label();
                lblLetter.ForeColor = Color.Black;
                lblLetter.Size = new Size(30, 30);
                lblLetter.Location = new Point(posX, posY);
                posX += 40;
                lblLetter.Text = "_";
                lblLetter.Tag = word[i];

                if (!letters.Contains(word[i]))
                {
                    letters.Add(word[i]);
                }

                this.Controls.Add(lblLetter);
            }

            posX = 15;
            start = DateTime.Now;
            timer1.Enabled = true;
        }

        private void getWordMnu_clicl(object sender, EventArgs e)
        {
            sendToServer(GET_WORD);
            dibujoAhorcado1.Errores = 0;
        }

        private void showRecordsMnu_click(object sender, EventArgs e)
        {
            sendToServer(GET_RECORDS);
        }
    
        private void showRecords(string records)
        {
            string rec = records.Replace("____", "\r\n");
            MessageBox.Show(rec, "Records");
        }

        private bool requestNameUserIP()
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
            bool acierto = false;
            foreach (Control c in Controls)
            {
                if (c is Label && c.Name != "lblTimer")
                {
                    if (c.Tag.ToString() == e.KeyChar.ToString().ToLower())
                    {
                        ((Label)c).Text = c.Tag.ToString();
                        letters.Remove((char)c.Tag);
                        acierto = true;
                    }                    
                }
            }
            if (!acierto)
            {
                dibujoAhorcado1.Errores++;
            }

            if (letters.Count == 0)
            {
                timer1.Enabled = false;
                timeGame = lblTimer.Text;
                sendToServer(SEND_RECORD + " " + timeGame);
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dif = DateTime.Now - start;
            lblTimer.Text = string.Format("{0:mm\\:ss}", dif);
        }

        private void closeServerMnu_click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();        
            DialogResult res = f4.ShowDialog();
            if(res == DialogResult.OK)
            {
                if(f4.txtPwd.Text.Length > 0)
                {
                    sendToServer(CLOSE_SERVER + " " + f4.txtPwd.Text);
                }
            }
            
        }

        private void dibujoAhorcado1_Ahorcado(object sender, EventArgs e)
        {
            MessageBox.Show("AHORCADO", "Partida finalizada");
            foreach (Control c in Controls)
            {
                if (c is Label && c.Name != "lblTimer")
                {                    
                    ((Label)c).Text = c.Tag.ToString();
                }
            }
            timer1.Enabled = false;
        }
    }
}
