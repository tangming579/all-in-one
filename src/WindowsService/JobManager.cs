using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public partial class JobManager : ServiceBase
    {
        public JobManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var path = Path.Combine("d://service.txt");
            File.AppendAllText(path, "Start " + DateTime.Now.ToString() + "\r\n");
            WriteAsync();
        }

        protected override void OnStop()
        {
            var path = Path.Combine("d://service.txt");
            File.AppendAllText(path, "Stop " + DateTime.Now.ToString() + "\r\n");
        }

        public async Task WriteAsync()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
                var path = Path.Combine("d://service.txt");
                File.AppendAllText(path, "Process " + DateTime.Now.ToString() + "\r\n");
            }
        }
    }
}
