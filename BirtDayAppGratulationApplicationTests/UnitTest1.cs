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
        private Mock<IUserInteractor> _uimock;
        private BirthDayApplication _cut;
        private IReadOnlyDictionary<DateTime, string[]> _dictionary;
        
        [SetUp]
        public void Setup()
        {
            _registermock = new Mock<IPeopleRegister>();
            _peopleFinder = new FamousPeopleFinder(
               _registermock.Object);
            _uimock = new Mock<IUserInteractor>();

            IReadOnlyDictionary<DateTime, string[]> _dictionary =
            new Dictionary<DateTime, string[]>()
        {
                    { new DateTime(1930, 5, 31)
                    , new string[] { "Clint EastWood" }
                    }
        };
            _cut = new BirthDayApplication(_dictionary, _uimock.Object);
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
                    },
                    { new DateTime(1964, 4, 18)
                    , new string[] { "Conan O'Brien" }
                    }
           };

            _registermock.Setup(mock => mock.NameByBirthDate)
                .Returns(dictionary);

            #nullable enable
            string?[] actualResult = _peopleFinder
                .FindNamesFromBirthDayAt_OrNull(new DateTime(1930, 5, 31));


            Assert.AreEqual("Clint EastWood",actualResult[0]);
        }

        [Test]
        public void ToStringShouldReturnCongratulationStringOnPerson()
        {
            var name = "George Clooney";
            Person person = new Person(name);
            string expected = $"It's {name}'s birthday!.";
            var actual = person.ToString();
            Assert.AreEqual(expected, actual);
            
        }

        [Test]

        public void ShouldGiveMessageWhenStartingTheApplication()
        {
            _cut.Run();
            _uimock.Verify(mock => 
            mock.ShowMessage(
                "Find out a birthday of a famous person. (Return)"));
                
        }

        [Test]

        public void ShouldShowCorrectCongratulationMessageForConanThatIsIncludedInRegister()
        {
            _registermock.Setup(mock => mock.NameByBirthDate)
               .Returns(_dictionary);

            _cut.Run();
            var expectedforeName = "Conan";
            _uimock.Verify(mock =>
            mock.ShowMessage("Happy birthday " + expectedforeName + "!. And all of you!."));
            
        }

        
        


    }
}