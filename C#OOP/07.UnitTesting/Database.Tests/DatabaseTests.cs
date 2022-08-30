namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] array;

        [SetUp]
        public void SetUp()
        {
            array = new int[] { 1, 2, 3, 4, 5, 6 };
            database = new Database(array);
        }

        [Test]
        public void When_ParamsProvidedCount_ShouldBeSetCorrectly()
        {
            Assert.That(database.Count, Is.EqualTo(array.Length));
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void DatabaseAddMethod_ShouldAddElementsCorrectly(int element)
        {
            database.Add(element);
            Assert.That(database.Count, Is.EqualTo(array.Length + 1));
        }

        [Test]
        public void When_DatabaseIsFullAndAddElement_ShouldThrowException()
        {
            for (int i = 0; i < 10; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void When_RemoveElement_ShouldDecreaseCount()
        {
            int count = database.Count;
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(count - 1));
        }

        [Test]
        public void When_RemoveElementAndCountIsZero_ShouldThrowException()
        {
            for (int i = 0; i < 6; i++)
            {
                database.Remove();
            }
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethod_ShouldReturnCorrectArray()
        {
            var elements = database.Fetch();
            Assert.That(elements.Length, Is.EqualTo(database.Count));
            Assert.That(elements, Is.InstanceOf(typeof(int[])));
        }

    }
}
