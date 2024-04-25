using GratulateBirthDay;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GratulateBirthDayTests
{
    public class Tests
    {
        private Mock<IPeopleRegister> _registermock;
        private FamousPeopleFinder _peopleFinder;
        [SetUp]
        public void Setup()
        {
            _registermock = new Mock<IPeopleRegister>();
            _peopleFinder = new FamousPeopleFinder(
               _registermock.Object);
        }

        [Test]
        public void FindNamesFromBirthDayAt_OrNullShouldReturnNullWhenDateIsMissing()
        {
            //var registermock = new Mock<IPeopleRegister>();

            IReadOnlyDictionary<DateTime, string[]> dictionary =
               new Dictionary<DateTime, string[]>()
           {
                    { new DateTime(1930, 5, 31)
                    , new string[] { "Clint EastWood" }
                    }
           };
            
            _registermock.Setup(mock => mock.NameByBirthDate)
                .Returns(dictionary);
            
            #nullable enable
            string?[] actualResult = _peopleFinder
                .FindNamesFromBirthDayAt_OrNull(new DateTime(2010, 1, 1));
              

            Assert.IsNull(actualResult);
                

        }

        [Test]
        public void FindNamesFromBirthDayAt_OrNull_ShouldReturnClintEastWoodWhenHisBirtdDayDateIsGivenAsArgument()
        {
           
            IReadOnlyDictionary<DateTime, string[]> dictionary =
               new Dictionary<DateTime, string[]>()
           {
                    { new DateTime(1930, 5, 31)
                    , new string[] { "Clint EastWood" }
                    }
           };

            _registermock.Setup(mock => mock.NameByBirthDate)
                .Returns(dictionary);

            #nullable enable
            string?[] actualResult = _peopleFinder
                .FindNamesFromBirthDayAt_OrNull(new DateTime(1930, 5, 31));


            Assert.AreEqual("Clint EastWood",actualResult[0]);


        }
    }
}