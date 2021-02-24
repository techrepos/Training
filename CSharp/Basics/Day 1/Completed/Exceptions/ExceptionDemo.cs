using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class ExceptionDemo
    {

        public void SimpleExceptionHandling()
        {
            FileStream file = null;
            FileInfo fileInfo = null;

            try
            {
                fileInfo = new FileInfo("./file1.txt");

                file = fileInfo.Open(FileMode.Open);
                file.WriteByte(0xF);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found exception {e.Message}");
                return;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Unauthorized exception {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                file?.Close();
            }
        }

        public string ExceptionFilterDemo()
        {
            
            try
            {
                var client = new HttpClient();
                var streamTask = client.GetStringAsync("http://www.google.com/test1");

                //var responseText =  streamTask.Result;
                return streamTask.Result;
            }
            catch (AggregateException e)  when (e.InnerExceptions.First().Message.Contains("404"))
            {
                return "Not Found";
            }
            catch (HttpRequestException e ) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
            catch (HttpRequestException e) when (e.Message.Contains("404"))
            {
                return "Page Not Found";
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }

        public string CustomExceptionDemo()
        {
           
            try
            {
                var client = new HttpClient();
                var streamTask = client.GetStringAsync("http://www.google.in/");
                var responseText =  streamTask.Result;
                throw new InvalidResponseException(250);
                return responseText;
            }
            catch(InvalidResponseException e)
            {
                return e.Message;
            }
            catch (Exception e) 
            {

                return e.Message;
            }
        }
    }
    public class InvalidResponseException : Exception
    {

        
        public InvalidResponseException(int InputValue)
            : base(String.Format("Invalid response, your response code was {0}", InputValue.ToString()))
        {

        }
    }
}
