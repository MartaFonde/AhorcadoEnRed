using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerAhorcado
{
    class Server
    {
        static readonly internal object l = new object();

        private Socket s;
        private Socket sClient;

        bool running = true;
        Random random = new Random();
        List<string> words = new List<string>();

        //comandos
        const string GET_WORD = "getword";
        const string SEND_WORD = "sendword";     //sendword word
        const string GET_RECORDS = "getrecords";
        const string SEND_RECORD = "sendrecord";        //sendrecord time ---- sendrecord time name ip
        const string CLOSE_SERVER = "closeserver";      //closeserver clave --- A clave será "clave"

        private string psw = "clave";        

        string pathWords = "..\\..\\words.txt";
        string pathRecords = "..\\..\\records.txt";
        string pahtRecordsTemp = "..\\..\\recordsTemp.txt";
        string pahtRecordsBackUp = "..\\..\\recordsTempBackUp.txt";

        public Server()
        {
            int port = 31416;
            bool portFree = false;

            //using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                while (!portFree)
                {
                    try
                    {
                        portFree = true;
                        IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
                        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        s.Bind(ie);
                        s.Listen(5);

                        Console.WriteLine("Server waiting at port {0}", ie.Port);

                        while (true)  
                        {
                            sClient = s.Accept();
                            Thread thread = new Thread(ThreadServer);
                            thread.Start();
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

        private void ThreadServer()
        {
            while (running)
            {
                lock (l)
                {
                    try
                    {
                        using (NetworkStream ns = new NetworkStream(sClient))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            string msg = sr.ReadLine();
                            Console.WriteLine(msg);
                            if (msg != null)
                            {
                                if (msg.StartsWith(SEND_WORD))
                                {
                                    string arg = msg.Substring(SEND_WORD.Length + 1);
                                    sw.WriteLine(WriteFileWord(arg));
                                    sw.Flush();                                    
                                }

                                else if (msg.StartsWith(SEND_RECORD))
                                {
                                    if (msg.Length == 16)    //só record tiempo
                                    {
                                        string arg = msg.Substring(SEND_RECORD.Length + 1);
                                        string rdo = ReadRecordsToIncorpore(arg).ToString(); //comprobo se ten que entrar na lista
                                        sw.WriteLine(rdo);
                                        sw.Flush();
                                    }
                                    else
                                    {
                                        WriteRecord(msg);
                                    }
                                }else if (msg.StartsWith(CLOSE_SERVER))
                                {
                                    Console.WriteLine("'"+ msg.Substring(CLOSE_SERVER.Length + 1)+"'");
                                    if (msg.Substring(CLOSE_SERVER.Length+1) == psw)
                                    {
                                        sw.WriteLine("True");
                                        sw.Flush();
                                        running = false;
                                        s.Close();
                                        //throw new IOException();
                                    }                                    
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
                                        case GET_RECORDS:
                                            string rec = ReadRecordsToSend();
                                            sw.WriteLine(rec);
                                            sw.Flush();
                                            break;

                                    }
                                }
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        running = false;
                        sClient.Close();
                    }
                }
            }

        }

        private bool ReadFileWords()
        {
            if (File.Exists(pathWords))
            {
                words.Clear();
                string line;
                using (StreamReader sr = new StreamReader(pathWords))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        words.Add(line);
                        line = sr.ReadLine();
                    }
                }
                return true;
            }
            else
            {
                File.Create(pathWords);
                return false;
            }
        }

        private string GetWord()
        {
            if (ReadFileWords())
            {
                return words[random.Next(0, words.Count - 1)];
            }
            else
            {
                return "No words";
            }
        }

        private bool WriteFileWord(string arg)
        {
            if (File.Exists(arg))
            {
                string line;
                try
                {
                    using (StreamReader sr = new StreamReader(arg))
                    using (StreamWriter sw = new StreamWriter(pathWords, true))
                    {
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            string[] newWords = line.Split(',');
                            foreach (string word in newWords)
                            {
                                sw.WriteLine(word.Trim());
                                line = sr.ReadLine();
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    return false;
                }
                
                return true;
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathWords, true))
                    {
                        sw.WriteLine(arg.Trim());
                    }                    
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }
        }

        private bool ReadRecordsToIncorpore(string arg)
        {
            string[] time = arg.Split(':');
            string line;
            int numLines = 0;
            if (File.Exists(pathRecords))
            {
                using (StreamReader sr = new StreamReader(pathRecords))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        numLines++;
                        line = sr.ReadLine();
                    }
                }
                if (numLines < 10)       //writeline escribe retorno de carro != null vai haber unha liña máis
                {
                    return true;
                }
                else if (numLines == 10)     //comprobamos a ver se podería entrar
                {
                    using (StreamReader sr = new StreamReader(pathRecords))
                    {
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            string[] timeRecord = line.Substring(0, 5).Split(':');

                            if (Convert.ToInt32(timeRecord[0]) > Convert.ToInt32(time[0]))
                            {
                                return true;
                            }
                            else if (Convert.ToInt32(timeRecord[0]) == Convert.ToInt32(time[0]) &&
                               Convert.ToInt32(timeRecord[1]) >= Convert.ToInt32(time[1]))
                            {
                                return true;
                            }
                            line = sr.ReadLine();
                        }
                    }
                }
                return false;       //non mellora ningún record
            }
            else
            {
                File.Create(pathRecords);
                return true;
            }
        }

        private void WriteRecord(string record)
        {
            string[] timeRecord = record.Substring(SEND_RECORD.Length + 1, 5).Split(':');
            string line;
            int numLines = 0;
            bool anhadido = false;

            using (StreamReader sr = new StreamReader(pathRecords))
            using (StreamWriter sw = new StreamWriter(pahtRecordsTemp))
            {
                line = sr.ReadLine();

                if (line == null)        //se o fich está baleiro escribimos directamente
                {
                    sw.WriteLine(record.Substring(SEND_RECORD.Length + 1));
                }

                else
                {
                    while (line != null && numLines <= 9)       // 9 liñas fich + novo record
                    {
                        if (!anhadido)  //se non está engadido record ---- comprobacións
                        {
                            string[] timeFileRecord = line.Substring(0, 5).Split(':');

                            if (Convert.ToInt32(timeFileRecord[0]) < Convert.ToInt32(timeRecord[0]) &&
                                Convert.ToInt32(timeFileRecord[1]) < Convert.ToInt32(timeRecord[1]))
                            {
                                sw.WriteLine(line);
                            }
                            else if (Convert.ToInt32(timeFileRecord[0]) == Convert.ToInt32(timeRecord[0]))
                            {
                                if (Convert.ToInt32(timeFileRecord[1]) < Convert.ToInt32(timeRecord[1]))
                                {
                                    sw.WriteLine(line);
                                }
                                else
                                {
                                    sw.WriteLine(record.Substring(SEND_RECORD.Length + 1));
                                    numLines++;
                                    anhadido = true;
                                    if (numLines < 10)
                                    {
                                        sw.WriteLine(line);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }

                        line = sr.ReadLine();
                        numLines++;

                        if (!anhadido && line == null && numLines <= 10)  //se non se escribiu o record ata a última linea --- ultimo posto
                        {
                            sw.WriteLine(record.Substring(SEND_RECORD.Length + 1));
                        }
                    }
                }
            }
            File.Replace(pahtRecordsTemp, pathRecords, pahtRecordsBackUp);
        }

        private string ReadRecordsToSend()
        {
            string records = "";
            try
            {
                using (StreamReader sr = new StreamReader(pathRecords))
                {
                    records = sr.ReadToEnd().Replace("\r\n", "____");
                    //4 _ porque non podería ser name user (lenght max3) nin ningún outro dato do archivo records
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            return records;
        }
    }
}

