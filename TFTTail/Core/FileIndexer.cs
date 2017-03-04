using System.IO;
using System.Text;

namespace TFT.Tail.Core
{
    public class FileIndexer
    {
        FragmentedList<long> indexes = new FragmentedList<long>();
        const int N = 64 * 1024;
        private StreamReader reader;
        private StringBuilder stringBuilder = new StringBuilder(N);
        private char[] charBuffer = new char[N];

        public int Count => indexes.Count;

        public FileIndexer(string filePath)
        {
            reader = new StreamReader(filePath);
            indexes.Add(0);
            int nbBlock = 0;
            int read;
            while ((read = reader.Read(charBuffer, 0, N)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    if (charBuffer[i] == '\n')
                    {
                        int pos = nbBlock * N + i + 1;
                        indexes.Add(pos);
                    }
                }
                nbBlock++;
            }
        }

        public string ReadLine(int numLine)
        {
            reader.BaseStream.Position = indexes[numLine];
            stringBuilder.Clear();

            int read;
            while ((read = reader.Read(charBuffer, 0, N)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    char value = charBuffer[i];
                    if (charBuffer[i] == '\n')
                    {
                        return stringBuilder.ToString();
                    }

                    stringBuilder.Append(value);
                }
            }
            return stringBuilder.ToString();
        }
    }
}