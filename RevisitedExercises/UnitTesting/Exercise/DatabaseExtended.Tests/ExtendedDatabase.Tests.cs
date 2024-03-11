using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Diagnostics.Contracts;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase db;
        private Person[] people;
        private int count = 3;
        private string defaultName = "Ivan";

        [SetUp]
        public void Setup()
        {
            people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                people[i] = new Person(i, defaultName + i);
            }

            db = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void Person_Constructor_SetsIdAndUserName()
        {
            Person person = new Person(count, defaultName);

            Assert.AreEqual(count, person.Id);
            Assert.AreEqual(defaultName, person.UserName);
        }

        [Test]
        public void ExtendedDatabase_InitializeWithPersons()
        {
            for (int i = 0; i < people.Length; i++)
            {
                Assert.AreEqual(people[i], db.FindById(people[i].Id));
            }
        }

        [Test]
        public void ExtendedDatabase_Count_Property_ReturnsCorrectCount()
        {
            Assert.AreEqual(count, db.Count);
        }

        [Test]
        public void AddRange_ThrowsArgumentExceptionWhenDataLengthExceedsCapacity()
        {
            people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i + 1, "Mr." + defaultName);
            }

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                db = new ExtendedDatabase.ExtendedDatabase(people);
            });

            Assert.That(ex.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Add_WhenArrayIsNotFull_AddsPerson()
        {
            int id = 33;
            string name = "Pesho";

            Person person = new Person(id, name);

            db.Add(person);

            Assert.AreEqual(count + 1, db.Count);
            Assert.AreEqual(person, db.FindById(id));
        }

        [Test]
        public void Add_WhenArrayIsFull_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 1; i < 20; i++)
                {
                    db.Add(new Person(i * 10, "Pesho" + i));
                }

            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [Test]
        public void Add_WhenPersonWithSameUserNameExists_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(0, defaultName + "0"));

            });
            Assert.AreEqual("There is already user with this username!", ex.Message);
        }

        [Test]
        public void Add_WhenPersonWithSameIdExists_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(0, defaultName));

            });
            Assert.AreEqual("There is already user with this Id!", ex.Message);
        }

        [Test]
        public void Remove_WhenDbIsEmpty_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= count; i++)
                {
                    db.Remove();
                }

            });
        }

        [Test]
        public void Remove_WhenArrayIsNotEmpty_RemovesLastPerson()
        {
            Person person = new Person(count, defaultName);

            db.Add(person);
            db.Remove();

            Assert.AreEqual(count, db.Count);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(person.Id);
            });
        }
    }
}