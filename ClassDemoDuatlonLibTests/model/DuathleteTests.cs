using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassDemoDuatlonLib.model.Tests
{
    [TestClass()]
    public class DuathleteTests
    {
        [TestMethod()]
        [DataRow("1234")]
        [DataRow("Et Meget langt navn")]
        public void CheckNameAcceptTest(String name)
        {
            // arrange 
            // act
            // assert
            Assert.IsTrue(Duathlete.CheckName(name));
        }

        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("123")]
        [DataRow("          ")]
        public void CheckNameFailTest(String name)
        {
            // arrange 
            // act
            // assert
            Assert.ThrowsException<ArgumentException>(
                () => Duathlete.CheckName(name)
                );
        }


        [TestMethod()]
        [DataRow(1)]
        [DataRow(4)]
        public void CheckAgeGroupAcceptTest(int group)
        {
            // arrange 
            // act
            // assert
            Assert.IsTrue(Duathlete.CheckAgeGroup(group));
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(-3)]
        public void CheckAgeGroupFailTest(int group)
        {
            // arrange 
            // act
            // assert
            Assert.ThrowsException<ArgumentException>(
                () => Duathlete.CheckAgeGroup(group)
                );
        }

        [TestMethod()]
        public void CheckConstructorAcceptTest()
        {
            // arrange
            String expectedName1 = "dummy";
            String expectedName2 = "Peter";

            // act
            Duathlete dua1 = new Duathlete();
            Duathlete dua2 = new Duathlete("Peter",4,4,4,4);

            // assert
            Assert.AreEqual(expectedName1, dua1.Name);
            Assert.AreEqual(expectedName2, dua2.Name);
        }

        [TestMethod()]
        [DataRow(null, 3)]
        [DataRow("123", 3)]
        [DataRow("1234", 0)]
        public void CheckConstructorFailTest(String name, int ageGroup)
        {
            // arrange 
            // act
            // assert
            Assert.ThrowsException<ArgumentException>(
                () => new Duathlete(name, ageGroup, 4, 4, 4)
                );
        }

    }
}