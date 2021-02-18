using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhorcadoEnRed
{
    class ComunicacionClient
    {
        readonly internal object l = new object();
        static Socket sServer;

        const string GET_WORD = "getword";
        const string SEND_WORD = "sendword";     //sendword palabra
        const string GET_RECORDS = "getrecords";
        const string SEND_RECORD = "sendrecord";
        const string CLOSE_SERVER = "closeserver";

        internal bool Running { set; get;}

        void HiloClient()
        {
            while (Running)
            {
                lock (l)
                {
                    Monitor.Wait(l);

                    using (NetworkStream ns = new NetworkStream(sServer))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        try
                        {
                            if (Form1.msgPaServer != null)
                            {
                                sw.WriteLine(Form1.msgPaServer);
                                sw.Flush();

                                if (Form1.msgPaServer.StartsWith(SEND_RECORD))
                                {
                                    Form1.msgDeServer = sr.ReadLine();

                                    MessageBox.Show(Form1.msgDeServer);

                                    if (Form1.msgDeServer == "True")
                                    {
                                        Form1.msgPaServer = SEND_RECORD + " " + Form1.tiempoPartida + " AAA " + "192.168.0.1";     //pedir nombre
                                        sw.WriteLine(Form1.msgPaServer);
                                        sw.Flush();
                                    }
                                }
                                else
                                {
                                    switch (Form1.msgPaServer)
                                    {
                                        case GET_WORD:
                                            Form1.palabra = sr.ReadLine();
                                            Form1.palabraNueva = true;
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
                            Running = false;
                        }
                    }                    
                }
            }
        }
       

        public ComunicacionClient(Socket server)
        {
            sServer = server;
            Thread threadClient = new Thread(HiloClient);
            Running = true;
            threadClient.Start();
        }

    }
}
