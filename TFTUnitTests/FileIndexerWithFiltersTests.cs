using NUnit.Framework;
using TFT.Tail.Core;
using System.Linq;
using System.Collections.Generic;

namespace TFT.UnitTests
{
    [TestFixture]
    public class FileIndexerWithFiltersTests : AbstractDummyFileWriterTests
    {
        RegexConfig rex0 = new RegexConfig() { Name = nameof(rex1), IgnoreCase = true, Regex = ".*" };
        RegexConfig rex1 = new RegexConfig() { Name = nameof(rex1), IgnoreCase = true, Regex = ".*1.*" };
        RegexConfig rex5 = new RegexConfig() { Name = nameof(rex1), IgnoreCase = true, Regex = ".*5.*" };

        public List<RegexConfig> GetFilters(params RegexConfig[] filters) => filters.ToList();
#region Basictests
        [Test]
        public void Test_Count_EmptyFilter_IgnoreIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex0), FilterMode.IgnoreIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(0));
            }
        }

        [Test]
        public void Test_Count_SingleFilter_IgnoreIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.IgnoreIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(N - 1));
            }
        }


        [Test]
        public void Test_Count_ManyFilter_IgnoreIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1, rex5), FilterMode.IgnoreIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(N - 2));
            }
        }

        [Test]
        public void Test_Count_EmptyFilter_KeepIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex0), FilterMode.KeepIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(N));
            }
        }

        [Test]
        public void Test_Count_SingleFilter_KeepIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.KeepIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void Test_Count_ManyFilter_KeepIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1, rex5), FilterMode.KeepIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(2));
            }
        }
        #endregion

#region ReadLine
        [Test]
        public void Test_ReadLine_KeepIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.KeepIfMatch))
            {
                string s = writer1.GetLine(1);
                Assert.That(fileIndexer.ReadLine(0), Is.EqualTo(s));
            }
        }
        [Test]
        public void Test_ReadLine_IgnoreIfMatch()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();

            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.IgnoreIfMatch))
            {
                string s = writer1.GetLine(0);
                string t = fileIndexer.ReadLine(0);
                Assert.That(t, Is.EqualTo(s));
                s = writer1.GetLine(2);
                t = fileIndexer.ReadLine(1);
                Assert.That(t, Is.EqualTo(s));
            }
        }
        #endregion

        #region UpdateFile
        [Test]
        public void Test_Refresh_After_1_Write_KeepIfMatch()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex0), FilterMode.KeepIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(1));

                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(2));

                string s = writer1.GetLine(1);
                string t = fileIndexer.ReadLine(1);
                Assert.That(t, Is.EqualTo(s));
            }
        }
        [Test]
        public void Test_Refresh_After_1_Write_IgnoreIfMatch()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex0), FilterMode.IgnoreIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(0));

                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(0));
            }
        }

        [Test]
        public void Test_Refresh_After_2_Write_KeepIfMatch()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.KeepIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(0));

                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(1));
            }
        }
        [Test]
        public void Test_Refresh_After_2_Write_IgnoreIfMatch()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName, GetFilters(rex1), FilterMode.IgnoreIfMatch))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(1));

                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(1));
            }
        }

        #endregion
    }
}
