using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Tests
{
    [TestClass()]
    public class FootbalPlayerTests
    {
        FootbalPlayer player = new FootbalPlayer {Id=1, Name = "Szymon", Age = 54, ShirtNumber = 99 };

        [TestMethod()]
        public void ValidateNameTest()
        {
            player.ValidateName();

            FootbalPlayer playerNoName = new FootbalPlayer() {Id=2, Name = null, Age = 54, ShirtNumber = 99 };
            Assert.ThrowsException<ArgumentNullException>(() =>playerNoName.ValidateName());

            FootbalPlayer playerShortName = new FootbalPlayer() { Id = 2, Name = "a", Age = 54, ShirtNumber = 99 };
            Assert.ThrowsException<ArgumentException>(() => playerShortName.ValidateName());

            FootbalPlayer playerBorderName = new FootbalPlayer() { Id = 2, Name = "ab", Age = 54, ShirtNumber = 99 };
            playerBorderName.ValidateName();
        }

        [TestMethod()]
        public void ValidateAgeTest()
        {
            player.ValidateAge();

            FootbalPlayer playerWrongAge = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = 0, ShirtNumber = 99 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>playerWrongAge.ValidateAge());

            FootbalPlayer playerBorderAge = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = 1, ShirtNumber = 99 };
            playerBorderAge.ValidateAge();

            FootbalPlayer playerNegativeAge = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = -2, ShirtNumber = 99 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerNegativeAge.ValidateAge());
        }

        [TestMethod()]
        public void ValidateShirtNumberTest()
        {
            player.ValidateShirtNumber();

            FootbalPlayer playerLowShirtNr = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = 0, ShirtNumber = 0 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerLowShirtNr.ValidateShirtNumber());

            FootbalPlayer playerHighShirtNr = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = 3, ShirtNumber = 100 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerHighShirtNr.ValidateShirtNumber());

            FootbalPlayer playerBorderShirtNr = new FootbalPlayer() { Id = 2, Name = "Szymon", Age = 1, ShirtNumber = 2 };
            playerBorderShirtNr.ValidateShirtNumber();
        }
    }
}