namespace Indexers
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Map2DTests
    {
        private readonly int[] seven = new int[] { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };
        private IMap2D<int, int, int> pitagoricTable;

        // Called once before each test after the constructor
        [TestInitialize]
        public void TestInitialize()
        {
            this.pitagoricTable = new Map2D<int, int, int>();
            this.pitagoricTable.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j);
            
        }

        [TestMethod]
        public void FillAndIndexerTest()
        {
            foreach(var i in pitagoricTable.GetElements())
            {
                System.Console.WriteLine(i.ToString());
            }
            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(i * i, this.pitagoricTable[i, i]);
            }
        }

        [TestMethod]
        public void GetRowTest()
        {
            if (!this.pitagoricTable.GetRow(7).Select(t => t.Item2).SequenceEqual(this.seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }

        [TestMethod]
        public void GetColumnTest()
        {
            if (!this.pitagoricTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(this.seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }
    }
}
