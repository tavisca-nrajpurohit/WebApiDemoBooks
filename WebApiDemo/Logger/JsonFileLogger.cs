using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebApiDemo.Logger
{
    public static class JsonFileLogger
    {

        public static void WriteLog(Log log)
        {
            string path = @"C:\Users\nrajpurohit\source\repos\WebApiDemo\WebApiDemo\Logger\log.json";
            string json = File.ReadAllText(path);
            List<Log> logs = JsonConvert.DeserializeObject<List<Log>>(json);
            logs.Add(log);
            string newJson = JsonConvert.SerializeObject(logs);
            File.WriteAllText(path, newJson);
        }
    }

    public class Log
    {
        public Log(object request, object response)
        {
            Time = DateTime.Now.ToString();
            Request = request;
            Response = response;
        }

        public string Time { get; set; }
        public object Request { get; set; }

        public object Response { get; set; }
    }
}
