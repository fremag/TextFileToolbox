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
            timerInfo.Tick += LogInfo;
            timerError.Tick += LogError;
            timerDebug.Tick += LogDebug;
        }
        StreamWriter writer;

        private void btnStart_Click(object sender, EventArgs e)
        {
            var fileName = string.Format(tbPath.Text, DateTime.Now);
            writer = new StreamWriter(fileName);
            timerInfo.Interval = (int)nudPeriod.Value;
            timerInfo.Start();
            timerError.Interval = (int)nudErrorPeriod.Value;
            timerError.Start();
            timerDebug.Interval = (int)nudDebugPeriod.Value;
            timerDebug.Start();
        }
        int n = 0;
        Random rand = new Random(0);
        private void LogInfo(object sender, EventArgs e)
        {
            Log($"Request sent: {n}");
            Thread.Sleep(rand.Next(50));
            Log($"Reply received: {n++}");
        }

        string[] users = {"Eric", "Jimi", "Angus", "Allen", "Pete", "Joe", "Kirk" };
        private void LogError(object sender, EventArgs e)
        {
            Log($"Authentication error: {users[rand.Next(users.Length-1)]}", "ERROR");
        }

        private void LogDebug(object sender, EventArgs e)
        {
            Log($"Memory used: {rand.Next(128)}", "DEBUG");
        }

        private void Log(string msg, string type="INFO")
        {
            string line = $"{DateTime.Now:HH:mm:ss.fff} - {type} - {msg}";
            writer.WriteLine(line);
            writer.Flush();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            LogError(null, EventArgs.Empty);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            LogDebug(null, EventArgs.Empty);
        }
    }
}
