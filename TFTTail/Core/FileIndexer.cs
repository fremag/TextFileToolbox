using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public string FilePath { get; private set; }
        public FilterMode FilterMode { get; private set; }
        public List<RegexConfig> Filters { get; private set; }

        public int Count => indexes.Count;

        public FileIndexer(string filePath, List<RegexConfig> filters=null, FilterMode filterMode=FilterMode.IgnoreIfMatch)
        {
            FilePath = filePath;
            Filters = filters;
            FilterMode = filterMode;

            if (filters == null || ! filters.Any())
            {
                RawIndex();
            }
            else
            {
                FilterIndex();
            }
        }

        private void FilterIndex()
        {
            reader = new StreamReader(FilePath);
            string s;
            long pos = 0;
            while ( (s = reader.ReadLine()) != null)
            {
                bool match = Filters.Any(regexConfig => regexConfig.CompiledRegex.IsMatch(s));
                bool keep = (FilterMode == FilterMode.KeepIfMatch && match)
                    || (FilterMode == FilterMode.IgnoreIfMatch && ! match);
                if( keep )
                {
                    indexes.Add(pos);
                }
                pos = reader.GetPosition();
            }
        }

        private void RawIndex()
        {
            reader = new StreamReader(FilePath);
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