using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static Stopwatch stopWatch = new Stopwatch();
       /* static void Main(string[] args )
        {
            stopWatch.Start();
            Console.WriteLine("Issue the request");
             DownloadString();
            stopWatch.Stop();
            Console.WriteLine("Time taken to complete request:" + stopWatch.ElapsedMilliseconds);
            Console.Read();
        }
        public static void DownloadString()
        {
            string task = NewMethod();
            DoIndependentWork();

          
            Console.WriteLine(task);

        }
        private static void DoIndependentWork()
        {
            Console.WriteLine("Working independently");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"Independent{i}");
            }
        }

        private static string NewMethod()
        {
            using (WebClient webCleint = new WebClient())
            {
                string siteContent = webCleint.DownloadString("http://www.google.com");
                for (int i = 0; i < 10000; i++)
                {
                    Debug.Write($"Test{i}");
                }
                return siteContent.Substring(1, 100);
            }
            
        }*/

        static async Task  Main(string[] args)
       {
           stopWatch.Start();
           Console.WriteLine("Issue the request");
           await DownloadStringAsyncAwait();
           stopWatch.Stop();
           Console.WriteLine("Time taken to complete request:" + stopWatch.ElapsedMilliseconds);
           Console.Read();
       }

       public async static Task DownloadStringAsyncAwait()
       {
           Task<string> task =  NewMethod();
           DoIndependentWork();

           var stringVal = await task;
               Console.WriteLine(stringVal);

       }

       private static void DoIndependentWork()
       {
           Console.WriteLine("Working independently");
           for (int i = 0; i < 100; i++)
           {
               Console.Write($"Independent{i}");
           }
       }

       private static async Task<string> NewMethod()
       {
           HttpClient httpClient = new HttpClient();
           var request = await httpClient.GetAsync("http://www.google.com");
           for(int i=0; i<10000;i++)
           {
               Debug.Write($"Test{i}");
           }
           var download = await request.Content.ReadAsStringAsync();
           return download.Substring(1,100);

       }

    }
}
