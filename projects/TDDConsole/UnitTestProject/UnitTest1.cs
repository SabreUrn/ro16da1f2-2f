using System;
using TDDConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void FindOneOccuranceInString() {
            //arrange
            string strCheck = "mysterious";
            char strFind = 'y';
            int expectedResult = 1;

            //act
            var classUnderTest = new StringUtilities();
            int actualResult = classUnderTest.CountOccurances(strCheck, strFind);
            
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindMultOccuranceInString() {
            //arrange
            string strCheck = "mysterious mystery";
            char strFind = 'y';
            int expectedResult = 3;

            //act
            var classUnderTest = new StringUtilities();
            int actualResult = classUnderTest.CountOccurances(strCheck, strFind);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FindOccuranceCaseInsensitive() {
            //arrange
            string strCheck = "mysterious";
            char strFind = 'Y';
            int expectedResult = 1;

            //act
            var classUnderTest = new StringUtilities();
            int actualResult = classUnderTest.CountOccurances(strCheck, strFind);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
