using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLibrary;
namespace Tests
{
    [TestClass]
    public class TestFreight
    {
        [TestMethod]
        public void CreateFreight()
        {
            Freight actual = new Freight(1, "Pretty", 12, "Wood", 24);
            string expected = "Id = 1, Name = Pretty, Speed = 12, Type of cargo = Wood, Weight = 24";
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void CloneFreight()
        {
            Freight expected = new Freight();
            Freight actual = (Freight)expected.Clone();
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualFalseFreight()
        {
            Freight expected = new Freight();
            string actual = "Not Freight";

            Assert.AreNotEqual(expected, actual);
        }
    }
}
