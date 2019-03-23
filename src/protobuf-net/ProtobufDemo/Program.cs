using Google.Protobuf;
using System;
using System.IO;

namespace ProtobufDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes;
            SearchRequest request = new SearchRequest();
            request.PageNumber = 1;
            request.ResultPerPage = 10;
            request.Query = "最新";


            using (MemoryStream stream = new MemoryStream())
            {
                // Save the person to a stream
                request.WriteTo(stream);
                bytes = stream.ToArray();
            }

            SearchRequest copy = SearchRequest.Parser.ParseFrom(bytes);

            Console.WriteLine("Hello World!");
        }
    }
}
