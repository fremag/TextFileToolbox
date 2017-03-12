using NUnit.Framework;

namespace TFT.UnitTests
{
    [TestFixture]
    public class DummyFileWriterTests : AbstractDummyFileWriterTests
    {
        [Test]
        public void TestDummyFileWriter()
        {
            Assert.True(fi1.Exists);
            Assert.That(fi1.Length, Is.EqualTo(0));
        }

        [Test]
        public void TestDummyFileWriter_SingleWrite()
        {
            Assert.That(fi1.Length, Is.EqualTo(0));
            writer1.Write();
            fi1.Refresh();
            Assert.That(fi1.Length, Is.Not.EqualTo(0));
        }
    }
}