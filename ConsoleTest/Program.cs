using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        public static string url;

        static void Main(string[] args)
        {
            string selection;
            int sel = 1;
            long id = 0;
            string user = "";
            string message = "";

            Console.WriteLine("Enter url for service: note must be in the form of http:/domainname/");
            url = Console.ReadLine();

            while (true)
            {

                Console.WriteLine("Enter 1) Return all messages, 2) Return partial messages, 3) post a message 4) exit.");
                selection = Console.ReadLine();
                try
                {
                    Int32.TryParse(selection, out sel);
                }
                catch
                {
                    Console.WriteLine("invalid selection");
                    Environment.Exit(1);
                }

                switch (sel)
                {
                    case 1:
                        Console.WriteLine(GetAllMessages());
                        break;
                    case 2:
                        Console.WriteLine("Enter message number to return");
                        try
                        {
                            Int64.TryParse(Console.ReadLine(), out id);
                        }
                        catch
                        {
                            id = 0;
                        }
                        Console.WriteLine(GetSomeMessages(id));
                        break;
                    case 3:
                        Console.WriteLine("Enter username");
                        user = Console.ReadLine();
                        Console.WriteLine("Enter message");
                        message = Console.ReadLine();
                        Post(user, "TEST", message);
                        Console.WriteLine(GetAllMessages());
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// return all messages
        /// </summary>
        /// <returns></returns>
        static string GetAllMessages()
        {
            string servie = url + "api/Chat";
            return GetFromWeb(servie);
        }

        /// <summary>
        /// test of return partial messages
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static string GetSomeMessages(long id)
        {
            string service = url + "api/Chat/" + id.ToString();
            return GetFromWeb(service);
        }

        /// <summary>
        /// test of post
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static string Post(string user, string pass, string message)
        {
            string service = url + "api/Post/" + user + "/" + pass + "/" + message;
            return GetFromWeb(service);
        }

        /// <summary>
        /// pull down via rest
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static String GetFromWeb(string Url)
        {
            Console.WriteLine(url);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);

            //note this will tell the service what to return
            req.ContentType = "text/xml; encoding='utf-8'";
            //req.ContentType = "text/json; encoding='utf-8'";

            req.Method = "GET";
            WebResponse response = req.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return result;
        }
      
    }
}
