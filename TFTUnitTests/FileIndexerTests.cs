using NUnit.Framework;
using TFT.Tail.Core;

namespace TFT.UnitTests
{
    [TestFixture]
    public class FileIndexerWithNoFilterTests : AbstractDummyFileWriterTests
    {
        [Test]
        public void Test_Count()
        {
            const int N = 10;
            for(int i=0; i < N; i++) 
                writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(N+1));
            }
        }

        [Test]
        public void Test_ReadLine()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                string s = writer1.GetLine(0);
                Assert.That(fileIndexer.ReadLine(0), Is.EqualTo(s));
                Assert.That(fileIndexer.ReadLine(N), Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public void Test_ReadLine_NoReturnOnLastLine()
        {
            const int N = 10;
            for (int i = 0; i < N; i++)
                writer1.WriteLine();
            writer1.Write();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                string s = writer1.GetLine(0);
                string t = fileIndexer.ReadLine(0);
                Assert.That(t, Is.EqualTo(s));
                s = writer1.GetLine(N);
                t = fileIndexer.ReadLine(N);
                Assert.That(t, Is.EqualTo(s));
            }
        }

        [Test]
        public void Test_LastLine_1()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                Assert.That(fileIndexer.LastLine, Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public void Test_LastLine_2()
        {
            writer1.Write();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                Assert.That(fileIndexer.LastLine, Is.EqualTo(writer1.GetLine(0)));
            }
        }

        [Test]
        public void Test_Refresh_After_1_WriteLine()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(2));
                Assert.That(fileIndexer.LastLine, Is.EqualTo(string.Empty));
                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(3));
                string t = writer1.GetLine(1);
                Assert.That(fileIndexer.ReadLineFromEnd(1), Is.EqualTo(t));
                Assert.That(fileIndexer.LastLine, Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public void Test_Refresh_After_1_Write()
        {
            writer1.WriteLine();
            using (FileIndexer fileIndexer = new FileIndexer(writer1.FileName))
            {
                Assert.That(fileIndexer.Count, Is.EqualTo(2));
                Assert.That(fileIndexer.LastLine, Is.EqualTo(string.Empty));
                writer1.WriteLine();
                fileIndexer.Refresh();
                Assert.That(fileIndexer.Count, Is.EqualTo(3));
                string t = writer1.GetLine(1);
                Assert.That(fileIndexer.ReadLineFromEnd(1), Is.EqualTo(t));
            }
        }
    }
}