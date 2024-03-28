using HtmlAgilityPack;
using System;

namespace TestHAP
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.davidgiard.com/Schedule.aspx";
            Console.WriteLine("Getting data from {0}...", url);
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var documentNode = doc.DocumentNode;
            var tableNode = documentNode
                        .SelectSingleNode("//table[@id='talklist']");
            var rowsNodesList = tableNode.SelectNodes("tr");

            var rowCount = 1;
            foreach (var row in rowsNodesList)
            {
                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count > 0)
                {
                    var date = cells[0].InnerText;
                    date = date.Replace("\r\n", "").Trim();
                    var topic = cells[1].InnerText;
                    topic = topic.Replace("\r\n", "").Trim();
                    var eventName = cells[2].InnerText;
                    eventName = eventName.Replace("\r\n", "").Trim();
                    var location = cells[3].InnerText;
                    location = location.Replace("\r\n", "").Trim();

                    Console.WriteLine("Row: {0}", rowCount);
                    Console.WriteLine("Date: {0}", date);
                    Console.WriteLine("Topic: {0}", topic);
                    Console.WriteLine("Event: {0}", eventName);
                    Console.WriteLine("Location: {0}", location);
                    Console.WriteLine("--------------------");
                    rowCount++;
                }
            }

            Console.ReadLine();
        }
    }
}
  