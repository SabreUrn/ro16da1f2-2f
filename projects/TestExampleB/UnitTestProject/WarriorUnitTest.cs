using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExampleB;
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable RedundantAssignment

namespace UnitTestProject {
    [TestClass]
    public class WarriorUnitTest {
        [TestMethod]
        public void TestWarrior_Constructor_NameTooShort_Exception() {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("A", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsMinimal_NoException() {
            // Arrange
            Warrior unexpectedResult = null;

            // Act
            Warrior actualResult = new Warrior("Rolf", 1);

            // Arrange, Act & Assert
            Assert.AreNotEqual(unexpectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Name_GetOnce() {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            string expectedResult = "Rolf";

            // Act
            string actualResult = testSubject.Name;

            // Arrange, Act & Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamageNegative_Exception() {
            //arrange
            Warrior testSubject = new Warrior("Rolf", 100);

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => { testSubject.ReceiveDamage(-5); });
        }

        [TestMethod]
        public void TestWarrior_HitPoints_GetOnce() {
            //arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            int expectedResult = 100;

            //act
            int actualResult = testSubject.HitPoints;

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_HitPoints_GetAfterDamage() {
            //arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            int expectedResult = 50;

            //act
            testSubject.ReceiveDamage(50);
            int actualResult = testSubject.HitPoints;

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetInitial() {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetAfterDamage() {
            //arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            bool expectedResult = true;

            //act
            testSubject.ReceiveDamage(100);
            bool actualResult = testSubject.IsDead;

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
