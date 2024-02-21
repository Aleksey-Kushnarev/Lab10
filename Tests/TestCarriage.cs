using LabLibrary;

namespace Tests
{
    [TestClass]
    public class TestCarriage
    {
        [TestMethod]
        public void CreateCarriage()
        {
            string expected = "Id = 1, Name = Cute, Speed = 25";
            Carriage actual = new Carriage(1, "Cute", 25);
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void CloneCarriage()
        {
            Carriage expected = new Carriage(1, "Cute", 25);
            Carriage actual = (Carriage)expected.Clone();
            expected.Id.Id = 0;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void CopyCarriage()
        {
            Carriage expected = new Carriage(1, "Cute", 25);
            Carriage actual = (Carriage)expected.ShallowCopy();
            expected.Id.Id = 0;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void DefaultCarriage()
        {
            string expected = "Id = 1, Name = default, Speed = 100";
            Carriage actual = new Carriage();
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void ThrowExceptionCarriage()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>new Carriage(1, "Not Cute", 1000));
        }

        [TestMethod]
        public void SortCarriage()
        {
            Carriage[] expected = new[]
                { new Carriage(1, "A", 20), new Carriage(2, "B", 10), new Carriage(0, "C", 30) };
            Carriage[] actual = new[] { new Carriage(2, "B", 10),  new Carriage(0, "C", 30), new Carriage(1, "A", 20) };
            Array.Sort(actual);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void SortBySpeedCarriage()
        {
            Carriage[] expected = new[]
                { new Carriage(2, "B", 10), new Carriage(1, "A", 20),  new Carriage(0, "C", 30) };
            Carriage[] actual = new[] { new Carriage(1, "A", 20), new Carriage(0, "C", 30), new Carriage(2, "B", 10),};
            Array.Sort(actual, new SortBySpeed());
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }
    }
}