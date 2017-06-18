namespace _09.HTTPServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    public class HTTPServer
    {
        private static int PortNumber = 8081;

        public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();

            Console.WriteLine($"Listening at port... {PortNumber}");

            var client = tcpListener.AcceptTcpClient();

            while (true)
            {
                using (var reader = new StreamReader(client.GetStream()))
                {
                    using (var writer = new StreamWriter(client.GetStream()))
                    {
                        try
                        {
                            var request = reader.ReadLine();
                            Console.WriteLine(request);
                            var tokens = request.Split(' ');
                            var page = tokens[1];

                            if (page == "/")
                            {
                                page = "index.html";
                            }
                            else if (page == "/info")
                            {
                                page = "info.html";
                            }
                            else
                            {
                                page = "error.html";
                            }

                            using (var file = new StreamReader("../../" + page))
                            {
                                writer.WriteLine("HTTP/1.0 200 OK\n");

                                var data = file.ReadLine();

                                while (data != null)
                                {
                                    if (data == "\t<h2>Current Time: {0}</h2>")
                                    {
                                        //string invariantCulture = DateTime.Now.Date.ToString(CultureInfo.InvariantCulture);
                                        var date = string.Format("{0}", DateTime.Now);
                                        data = data.Replace("{0}", date);
                                        writer.WriteLine(data);
                                        writer.Flush();
                                    }
                                    else if (data == "\t<h2>Logical Processors: {1}<h2>")
                                    {
                                        var processor = string.Format("{0}", Environment.ProcessorCount);
                                        data = data.Replace("{1}", processor);
                                        writer.WriteLine(data);
                                        writer.Flush();
                                    }
                                    else
                                    {
                                        writer.WriteLine(data);
                                        writer.Flush();
                                    }

                                    data = file.ReadLine();
                                }
                            }
                        }
                        catch 
                        {

                        }
                    }
                }

                client.Close();
                client = tcpListener.AcceptTcpClient();
            }
        }
    }
}
