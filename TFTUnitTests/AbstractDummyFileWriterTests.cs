using System.IO;
using NUnit.Framework;

namespace TFT.UnitTests
{
    public abstract class AbstractDummyFileWriterTests
    {
        protected DummyFileWriter writer1;
        protected FileInfo fi1;
        protected const string TEXT_TEST = "TEXT TEST";

        [SetUp]
        public void SetUp()
        {
            writer1 = new DummyFileWriter { Prefix = TEXT_TEST };
            fi1 = new FileInfo(writer1.FileName);
        }

        [TearDown]
        public void TearDown()
        {
            writer1.Dispose();
        }

    }
}