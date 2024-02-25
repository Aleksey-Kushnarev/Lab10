using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestRestaurant
    {
        [TestMethod]
        public void CreateRestaurant()
        {
            Restaurant actual = new Restaurant(1, "Pretty", 12, 12, "Test");
            string expected = "Id = 1, Name = Pretty, Speed = 12, Seats = 12, Beds = 0, Work Time = Test";
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void CloneRestaurant()
        {
            Restaurant expected = new Restaurant();
            Restaurant actual = (Restaurant)expected.Clone();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualFalseRestaurant()
        {
            Restaurant expected = new Restaurant();
            string actual = "Not Restaurant";

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void NotValidRestaurant()
        {
            Restaurant expected = new Restaurant();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => expected.Seats = 200);
        }

        [TestMethod]
        public void GetHashRestaurant()
        {
            Restaurant expected = new Restaurant();
            int a = expected.GetHashCode();
            Assert.AreEqual(expected.GetHashCode(), a);
        }
    }
}