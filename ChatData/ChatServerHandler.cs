using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ChatData
{
    public static class ChatServerHandler
    {
        //path to the text file we will be using to write to
        //could be set up in a config
        //ideally this should be a database (sql server/mysql/postgres/sqllite this was used for a simple test)
        private const string filepath = "C:\\temp\\messages.txt";

        /// <summary>
        /// Post a message to the text file
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="message"></param>
        public static long postMessage(string user, string pass, string message)
        {
            Message msg = new Message();
            List<string> file = new List<string>();
            string lastLine;

            msg.login = user;
            msg.password = pass;
            msg.message = message;

            if (File.Exists(filepath))
            {
                while(IsFileLocked(filepath) == false)
                {
                    Thread.Sleep(100);
                }
                file = File.ReadAllLines(filepath).ToList();
            }

            //get the last id of the message from file
            if (file.Count == 0)
            {
                msg.messageId = 0;
            }
            else
            {
                lastLine = file[file.Count - 1];
                msg.messageId = Convert.ToInt64(lastLine.Split('|')[0]);
                msg.messageId++;
            }

            //store the message into a file
            file.Add(msg.messageId + "|" + msg.login + ": " + msg.message);

            //save to file
            while (IsFileLocked(filepath) == false)
            {
                Thread.Sleep(100);
            }
            File.WriteAllLines(filepath, file);

            return msg.messageId;

        }

        /// <summary>
        /// return all or part of the message file
        /// </summary>
        /// <param name="start">optional parameter will return messages from start to the last message</param>
        /// <returns></returns>
        public static List<string> returnMessages(long start = 0)
        {
            List<string> file = new List<string>();
            List<string> partial = new List<string>();

            if (File.Exists(filepath))
            {
                while (IsFileLocked(filepath) == false)
                {
                    Thread.Sleep(100);
                }
                file = File.ReadAllLines(filepath).ToList();
            }

            if(start > 0)
            {
                string[] linenum;
                int num;

                foreach(string s in file)
                {
                    linenum = s.Split('|');

                    try
                    {
                        Int32.TryParse(linenum[0],out num);
                        if(num >= start)
                        {
                            partial.Add(s);
                        }
                    }
                    catch
                    {

                    }

                }

            }

            if(partial.Count > 0)
            {
                file = partial;
            }

            return file;
        }

        /// <summary>
        /// Check to see if the file is locked, not ideal (ideally this would all be stored in a database this is just a test)
        /// </summary>
        /// <param name="sFilename"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string sFilename)
        {
            try
            {
                using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (inputStream.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
