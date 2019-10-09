using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PipeLinesDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async Task ProcessLinesAsync(Socket socket)
        {
            var pipe = new Pipe();
            Task writing = FillPipeAsync(socket, pipe.Writer);
            Task reading = ReadPipeAsync(pipe.Reader);

            await Task.WhenAll(reading, writing);
        }

        async Task FillPipeAsync(Socket socket, PipeWriter writer)
        {

        }

        async Task ReadPipeAsync(PipeReader reader)
        {

        }
    }
}
