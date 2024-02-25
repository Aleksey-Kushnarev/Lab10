using LabLibrary;


namespace Tests
{
    [TestClass]
    public class TestCoach
    {
        [TestMethod]
        public void CreateCoach()
        {
            Coach actual = new Coach(1, "Pretty", 12, 12, 4);
            string expected = "Id = 1, Name = Pretty, Speed = 12, Seats = 12, Beds = 4";
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void CloneCoach()
        {
            Coach expected = new Coach();
            Coach actual = (Coach)expected.Clone();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualFalseCoach()
        {
            Coach expected = new Coach();
            string actual = "Not Coach";

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void NotValidCoach()
        {
            Coach expected = new Coach();

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>expected.Beds = 200);
        }
    }
}
