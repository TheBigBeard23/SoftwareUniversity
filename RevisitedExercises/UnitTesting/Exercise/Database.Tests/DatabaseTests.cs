using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] arr;
        private int dbDefaultCount = 16;
        private int element = 1;

        [SetUp]
        public void Setup()
        {
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 56, 34, 54, 45, 2 };

            database = new Database.Database(arr);
        }

        [Test]
        public void Database_Constructor_InitializesDataArrayWithGivenParameters()
        {
            int[] dbArr = database.Fetch();

            Assert.IsTrue(arr.SequenceEqual(dbArr));
            Assert.AreEqual(arr.Length, database.Count);
        }

        [Test]
        public void Add_ValidElement_IncreasesCount()
        {
            database.Add(element);
            Assert.AreEqual(arr.Length + 1, database.Count);
        }

        [Test]
        public void Add_WhenArrayNotFull_AddsElement()
        {
            database.Add(element);
            int[] dbArr = database.Fetch();

            Assert.AreEqual(arr.Length + 1, database.Count);
            Assert.AreEqual(element, dbArr.Last());
        }

        [Test]
        public void Add_ThrowsExceptionWhenCapacityReached()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(element);
                database.Add(element);
                database.Add(element);
            });

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_ThrowsExceptionWhenCapacityReached_WithFullArray()
        {
            database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(element);
            });

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityExceeded()
        {
            int[] newArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database.Database(newArr);
            });

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_DecreasesCount()
        {
            database.Remove();
            Assert.AreEqual(arr.Length - 1, database.Count);
        }

        [Test]
        public void Remove_RemovesLastElement()
        {
            int lastElement = database.Fetch().Last();
            database.Remove();
            int[] dbArr = database.Fetch();

            Assert.AreNotEqual(lastElement, dbArr.Last());
        }

        [Test]
        public void Remove_ThrowsExceptionWhenCollectionEmpty()
        {
            database = new Database.Database();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

            Assert.That(ex.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Fetch_ReturnsCorrectArray()
        {
            arr = new int[] { 1, 2, 3 };
            database = new Database.Database(arr);

            int[] dbArr = database.Fetch();

            Assert.IsTrue(arr.SequenceEqual(dbArr));
        }

        [Test]
        public void Fetch_ReturnsEmptyArrayWhenCollectionEmpty()
        {
            arr = new int[0];
            database = new Database.Database(arr);

            int[] dbArr = database.Fetch();

            Assert.IsEmpty(dbArr);

        }

        [Test]
        public void Fetch_ReturnsCopyOfDataArrayWithMultipleElements()
        {
            arr = new int[] { 1, 2, 3 };
            database = new Database.Database(arr);

            int[] dbArr = database.Fetch();

            Assert.IsFalse(object.ReferenceEquals(dbArr, arr));
            Assert.AreEqual(arr, dbArr);
        }
    }
}