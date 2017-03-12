using System;
using System.IO;

namespace TFT.UnitTests
{
    public class DummyFileWriter : IDisposable
    {
        public bool Enabled { get; set; }
        public string FileName { get; set; }
        public int  Period { get; set; }
        public string Prefix { get; set; }
        public int N { get; set; }
        private TextWriter writer;

        public DummyFileWriter()
        {
            FileName = Path.GetTempFileName();
            var stream = File.Open(FileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            writer = new StreamWriter(stream);
        }

        public void Write()
        {
            writer.Write(GetLine(N++));
            writer.Flush();
        }

        public void WriteLine()
        {
            Write();
            writer.Write("\r\n");
            writer.Flush();
        }

        public string GetLine(int n)
        {
            return $"{Prefix}: {n}";
        }

        public void Dispose()
        {
            writer.Dispose();
            File.Delete(FileName);
        }
    }
}