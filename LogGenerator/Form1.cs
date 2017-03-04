using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LogGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamWriter writer;

        private void btnStart_Click(object sender, EventArgs e)
        {
            var fileName = string.Format(tbPath.Text, DateTime.Now);
            writer = new StreamWriter(fileName);
            timer1.Tick += LogInfo;
            timer1.Interval = (int)nudPeriod.Value;
            timer1.Start();
        }
        int n = 0;
        Random rand = new Random(0);
        private void LogInfo(object sender, EventArgs e)
        {
            Log($"Request sent: {n++}");
            Thread.Sleep(rand.Next(50));
            Log($"Reply received: {n}");
        }

        private void Log(string msg, string type="INFO")
        {
            string line = $"{DateTime.Now:HH:mm:ss.fff} - {type} - {msg}";
            writer.WriteLine(line);
            writer.Flush();

        }
    }
}
