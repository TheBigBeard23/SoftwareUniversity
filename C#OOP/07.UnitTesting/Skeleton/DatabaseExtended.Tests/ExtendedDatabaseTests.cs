namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private long id;
        private string userName;
        private Database database;
        private Person[] people;
        [SetUp]
        public void SetUp()
        {
            id = 22;
            userName = "Pesho";
            person = new Person(id, userName);

            people = new Person[15];
            for (int i = 0; i < 15; i++)
            {
                people[i] = new Person(i, $"Pesho{i}");
            }
            database = new Database(people);
        }

        [Test]
        public void When_UserNameAndIdProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(userName, person.UserName);
        }

        [Test]
        public void When_DatabaseProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void When_DataIsBiggerThanCapacity_ShouldThrowException()
        {
            people = new Person[17];
            Assert.Throws<ArgumentException>(() => new Database(people));
        }
        [Test]
        public void When_DatabaseIsFull_ShouldThrowException()
        {
            database.Add(new Person(15, "Pesho15"));
            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(17, "Pesho")));
        }
        [Test]
        public void When_DatabaseContainsTheUserName_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(15, "Pesho0")));
        }
        [Test]
        public void When_DatabaseContainsTheId_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(14, "Pesho15")));
        }
        [Test]
        public void When_RemoveCount_ShouldDecrease()
        {
            int count = database.Count;
            database.Remove();
            Assert.AreEqual(count - 1, database.Count);
        }
        [Test]
        public void When_CountIsZeroAndRemove_ShouldThrowException()
        {
            database = new Database();
            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }
        [Test]
        public void When_ProvidedEmptyUserNameFindByUsernameMethod_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(string.Empty));
        }
        [Test]
        public void When_UserNameDoesNotExistNameFindByUsernameMethod_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername("Ivan"));
        }
        [Test]
        public void FindByUsernameMethod_ShouldReturnPersonCorrectly()
        {
            database.Add(person);
            var foundPerson = database.FindByUsername(person.UserName);
            Assert.AreEqual(person.UserName, foundPerson.UserName);
        }
        [Test]
        public void When_ProvidedNegativeIdFindByIdMethod_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(-2));
        }
        [Test]
        public void When_IdDoesNotExistNameFindByIdMethod_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.FindById(33));
        }
        [Test]
        public void FindByIdMethod_ShouldReturnPersonCorrectly()
        {
            database.Add(person);
            var foundPerson = database.FindById(person.Id);
            Assert.AreEqual(person.Id, foundPerson.Id);
        }
    }
}