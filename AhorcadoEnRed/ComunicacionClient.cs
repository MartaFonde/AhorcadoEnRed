//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AhorcadoEnRed
//{
//    class ComunicacionClient
//    {

//        void HiloClient()
//        {
//            while (running)
//            {
//                lock (l)
//                {
//                    using (NetworkStream ns = new NetworkStream(sServer))
//                    using (StreamReader sr = new StreamReader(ns))
//                    using (StreamWriter sw = new StreamWriter(ns))
//                    {
//                        try
//                        {
//                            if (msgPaServer != null)
//                            {
//                                sw.WriteLine(msgPaServer);
//                                sw.Flush();

//                                if (msgPaServer.StartsWith(SEND_RECORD))
//                                {
//                                    msgDeServer = sr.ReadLine();

//                                    MessageBox.Show(msgDeServer);

//                                    if (msgDeServer == "True")
//                                    {
//                                        msgPaServer = SEND_RECORD + " " + lblTimer.Text + " AAA " + "192.168.0.1";     //pedir nombre
//                                        sw.WriteLine(msgPaServer);
//                                        sw.Flush();
//                                    }
//                                }
//                                else
//                                {
//                                    switch (msgPaServer)
//                                    {
//                                        case GET_WORD:
//                                            palabra = sr.ReadLine();
//                                            palabraNueva = true;
//                                            Monitor.Pulse(l);
//                                            break;

//                                            //case SEND_RECORD:

//                                            //    break;

//                                    }
//                                }



//                            }
//                        }
//                        catch (IOException)
//                        {
//                            MessageBox.Show("Error de conexión", "Error");
//                            running = false;
//                        }
//                    }

//                    Monitor.Wait(l);        //PROBLEMA se se cerra o server queda en Wait
//                }
//            }
//        }



//    }
//}
