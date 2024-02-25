using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestClassDiscipline
    {
        [TestMethod]
        public void TestDisciplineMakeObject()
        {
            //Arrange
            Discipline expected = new Discipline("math", -24, -52);
            //Act
            Discipline actual = new Discipline("math");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDisciplineCreditUnit()
        {
            //Arrange
            Discipline expected = new Discipline("math", 24, 52);
            //Act
            Discipline actual = new Discipline("math", 38, 38);
            //Assert
            Assert.AreEqual(expected.CreditUnit, actual.CreditUnit);
        }

        [TestMethod]
        public void TestDisciplineComparisonIsGreater()
        {
            //Arrange
            Discipline expected = new Discipline("math", 48, 52);
            //Act
            Discipline actual = new Discipline("math", 38, 38);
            //Assert
            Assert.IsTrue(expected > actual);
            Assert.IsFalse(expected <= actual);
        }

        [TestMethod]
        public void TestDisciplineComparisonIsLess()
        {
            //Arrange
            Discipline expected = new Discipline("math", 12, 22);
            //Act
            Discipline actual = new Discipline("math", 38, 38);
            //Assert
            Assert.IsTrue(expected < actual);
            Assert.IsFalse(expected >= actual);
        }

        [TestMethod]
        public void TestDisciplineComparisonIsEqual()
        {
            //Arrange
            Discipline expected = new Discipline("math", 40, 22);
            //Act
            Discipline actual = new Discipline(expected);
            //Assert
            Assert.IsTrue(expected == actual);
            Assert.IsFalse(expected != actual);
        }

        [TestMethod]
        public void TestDisciplineToString()
        {
            //Arrange
            Discipline expected = new Discipline();
            //Act
            string actual = "Discipline default has 0 Contact hours and 0 Self hours.";
            //Assert
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestDisciplineToInt()
        {
            //Arrange
            Discipline expected = new Discipline("math", 40, 22);
            //Act
            int actual = 20;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDisciplineToDouble()
        {
            //Arrange
            Discipline expected = new Discipline("math", 20, 80);
            //Act
            double actual = 0.2d;
            //Assert
            Assert.AreEqual((double)expected, actual);

        }

        [TestMethod]
        public void TestDisciplineFailInc()
        {
            //Arrange
            Discipline expected = new Discipline("Pretty");
            Assert.ThrowsException<Exception>(() => expected++);
        }

        [TestMethod]
        public void TestDisciplineNotFailInc()
        {
            //Arrange
            Discipline expected = new Discipline("Pretty", 12, 24);
            //Act
            int actual = 7;
            Assert.AreEqual(expected++, actual);
        }
        [TestMethod]
        public void TestDisciplineFailAdd()
        {
            //Arrange
            Discipline expected = new Discipline("Pretty");

            Assert.ThrowsException<Exception>(() => expected += 7);
        }

        [TestMethod]
        public void TestDisciplineNotFailAdd()
        {
            //Arrange
            Discipline expected = new Discipline("Pretty", 12, 24);
            //Act
            int actual = 8;
            Assert.AreEqual(expected + 4, actual);
        }

        [TestMethod]
        public void TestDisciplineInterestCalculation()
        {
            //Arrange
            Discipline expected = new Discipline("Pretty", 24, 24);
            //Act
            int actual = 50;
            Assert.AreEqual(!expected, actual);
        }
    }

}
