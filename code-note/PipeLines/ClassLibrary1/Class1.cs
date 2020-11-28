using System;
using System.IO.Pipelines;
using System.Text;

namespace ClassLibrary1
{
    public class Class1
    {
        public void Test1()
        {
            var pipe = new Pipe();
            var writer = pipe.Writer;
            var reader = pipe.Reader;

            var content = Encoding.Default.GetBytes("hello world");
            var data = new Memory<byte>(content);
            var result = await writer.WriteAsync(data);
        }
    }
}
