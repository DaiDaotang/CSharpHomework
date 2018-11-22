using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace program
{
    public class Crawler
    {
        private Queue<String> urls = new Queue<string>();//队列确认没爬过的网页
        private int count = 0;
        private string html;

        public Crawler(string url)//构造函数
        {
            html = "";
            if (url.Length > 0)
            {
                urls.Enqueue(url);
            }
        }

        public void Crawl()
        {
            Console.WriteLine("开始爬行了。。。");
            while (true)
            {
                if (urls.Count == 0)
                {
                    continue;
                }//等待下载完成后在开始解析
                string current = urls.Peek();
                if (current == null || count > 10) break;
                DownLoad(current);
                Thread thread = new Thread(Parse);
                thread.Start();
            }
            Console.WriteLine("爬行结束");
        }

        public void DownLoad(String url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string content = webClient.DownloadString(url);
                string fileName = count.ToString();
                urls.Dequeue();
                count++;
                File.WriteAllText(fileName + ".html", content, Encoding.UTF8);
                lock (html)
                {
                    html = content;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                urls.Dequeue();
            }
        }

        private void Parse()
        {
            lock (html)
            {
                string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ' ', '>');
                    if (strRef.Length == 0)
                    {
                        continue;
                    }
                    urls.Enqueue(strRef);
                }
            }
        }
    }
}
