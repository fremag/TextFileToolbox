using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TFT.Tail.Core
{
    public class FileIndexer : IDisposable
    {
        FragmentedList<long> indexes = new FragmentedList<long>();
        const int N = 64 * 1024;

        private StreamReader reader;
        private StringBuilder stringBuilder = new StringBuilder(N);
        private char[] charBuffer = new char[N];
        private long maxPos;
        private bool hasFilter;

        public string FilePath { get; private set; }
        public FilterMode FilterMode { get; private set; }
        public List<RegexConfig> Filters { get; private set; }

        public int Count => indexes.Count;
        public string LastLine => ReadLineFromEnd(0);

        public FileIndexer(string filePath, List<RegexConfig> filters=null, FilterMode filterMode=FilterMode.IgnoreIfMatch)
        {
            FilePath = filePath;
            Filters = filters;
            FilterMode = filterMode;
            var fileReader = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            reader = new StreamReader(fileReader);

            hasFilter = filters != null && filters.Any();
            if (hasFilter)
            {
                FilterIndex(0);
            }
            else
            {
                indexes.Add(0);
                RawIndex(0);
            }
        }

        private void FilterIndex(long startPosition)
        {
            string s;
            long pos = startPosition;
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
                maxPos = Math.Max(pos, maxPos);
            }
        }

        public void Refresh()
        {
            reader.BaseStream.Position = maxPos;

            if (hasFilter)
            {
                FilterIndex(maxPos);
            }
            else
            {
                RawIndex(maxPos);
            }
        }

        private void RawIndex(long startPosition)
        {
            int nbBlock = 0;
            int read;
            while ((read = reader.Read(charBuffer, 0, N)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    if (charBuffer[i] == '\n')
                    {
                        long pos = nbBlock * N + i + 1 + startPosition;
                        indexes.Add(pos);
                        maxPos = Math.Max(pos, maxPos);
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
                        return GetString(stringBuilder);
                    }

                    stringBuilder.Append(value);
                }
            }
            return GetString(stringBuilder);
        }

        public string ReadLineFromEnd(int numLineFromEnd)
        {
            if(numLineFromEnd < Count && Count > 0)
            {
                int idx = Count - numLineFromEnd - 1;
                string s = ReadLine(idx);
                return s;
            }
            return null;
        }

        private string GetString(StringBuilder stringBuilder)
        {
            
            int n = stringBuilder.Length - 1;
            if( n < 0)
            {
                return string.Empty;
            }
            if ( stringBuilder[n] == '\r' )
            {
                stringBuilder.Remove(n, 1);
            }
            string s = stringBuilder.ToString();
            return s;
        }

        public void Dispose()
        {
            reader.Close();
        }
    }
}