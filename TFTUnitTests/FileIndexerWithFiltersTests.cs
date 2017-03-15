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

    }
}
