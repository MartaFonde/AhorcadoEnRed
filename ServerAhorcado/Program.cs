using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerAhorcado
{
    class Program
    {
        static readonly internal object l = new object();

        static bool running = true;

        static Random random = new Random();
        static List<string> words = new List<string>();

        //comandos
        const string GET_WORD = "getword";
        const string SEND_WORD = "sendword";     //sendword palabra
        const string GET_RECORDS = "getrecords";
        const string SEND_RECORD = "sendrecord";
        const string CLOSE_SERVER = "closeserver";

        static Socket sClient;
        static string path = "C:\\Users\\PC\\Desktop\\words.txt";
        static string pathRecords = "C:\\Users\\PC\\Desktop\\records.txt";

        static void ReadFileWords()
        {
            words.Clear();
            string line;
            //using(StreamReader sr = new StreamReader(ServerAhorcado.Properties.Resources.words))
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine();
                while(line != null)
                {
                    words.Add(line);
                }               
            }                
        }

        static string GetWord()
        {
            ReadFileWords();
            return words[random.Next(0, words.Count-1)];
        }

        static void WriteFileWord(string arg, bool file)
        {
            if (file)
            {
                string line;
                using(StreamReader sr = new StreamReader(arg))
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] newWords = line.Split(',');
                        foreach (string word in newWords)
                        {
                            sw.WriteLine( word.Trim());
                        }                        
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(arg.Trim());
                }
            }            
        }

        static bool ReadRecords(string arg)
        {
            string[] time = arg.Split(':');
            string line;
            int numLines = 0;
            using (StreamReader sr = new StreamReader(pathRecords))           
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    numLines++;
                }
            }

            if(numLines < 10)
            {
                return true;
            }
            else
            {
                numLines = 0;
                using (StreamReader sr = new StreamReader(pathRecords))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {                        
                        string[] timeRecord = line.Substring(0, 4).Split(':');
                        if (Convert.ToInt32(time[0]) <= Convert.ToInt32(timeRecord[0]) &&
                            Convert.ToInt32(time[1]) <= Convert.ToInt32(timeRecord[1]))
                        {                            
                            return true;
                        }
                        numLines++;
                    }
                }
            }
            return false;
 
        }


        static void WriteRecord(string record)
        {
            string line;
            using (StreamReader sr = new StreamReader(pathRecords))
            using (StreamWriter sw = new StreamWriter(pathRecords + "2.txt"))
            {
                line = sr.ReadLine();
                while (line != null)
                {

                }
            }
        }

        static void HiloServer()
        {
            while (running)
            {
                lock (l)
                {
                    using (NetworkStream ns = new NetworkStream(sClient))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        try
                        {
                            string msg = sr.ReadLine();
                            Console.WriteLine(msg);
                            if (msg != null)
                            {
                                if (msg.StartsWith(SEND_WORD))
                                {
                                    string arg = msg.Substring(SEND_WORD.Length + 1);
                                    if (File.Exists(arg))
                                    {
                                        WriteFileWord(arg, true);
                                    }
                                    else
                                    {
                                        WriteFileWord(arg, false);
                                    }                                    
                                }else if (msg.StartsWith(SEND_RECORD) && msg.Length == 16)
                                {
                                    string arg = msg.Substring(SEND_RECORD.Length + 1);
                                    sw.Write(ReadRecords(arg));
                                    sw.Flush();
                                }else if(msg.StartsWith(SEND_RECORD) && msg.Length > 16)
                                {

                                }
                                else
                                {
                                    switch (msg)
                                    {
                                        case GET_WORD:
                                            string w = GetWord();
                                            Console.WriteLine(w);
                                            sw.WriteLine(w);
                                            sw.Flush();
                                            break;
                                        //case :
                                        //    break;

                                    }
                                }
                                
                                
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                     
                    }                    
                }                
            }

        }

        static void Main(string[] args)
        {
            int port = 31416;
            bool portFree = false;


            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                while (!portFree)
                {
                    try
                    {
                        portFree = true;
                        IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
                        s.Bind(ie);
                        s.Listen(5);

                        Console.WriteLine("Server waiting at port {0}", ie.Port);

                        while (true)
                        {
                            sClient = s.Accept();
                            Thread thread = new Thread(HiloServer);
                            thread.Start();
                            Console.WriteLine("Lanza hilo");
                            //SERVER Envia palabra CLIENTE recibe palabra -- recibe comando GETWORD
                            //Leer archivo
                        }

                    }
                    catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                    {
                        Console.WriteLine($"Port {port} in use");
                        portFree = false;
                        port++;
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }

                }
            }
        }
    }             
}
