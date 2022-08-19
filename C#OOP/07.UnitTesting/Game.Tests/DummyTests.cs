using NUnit.Framework;

namespace Game.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int health = 10;
        private int experience = 100;
        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(0, experience);
        }

        [Test]
        public void When_HealthProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void When_DummyTakeAttack_ShouldLooseHealth()
        {
            int attackPoints = 5;
            dummy.TakeAttack(attackPoints);
            Assert.AreEqual(health - attackPoints, dummy.Health);
        }
        [Test]
        public void When_DummyHealthIsZero_ShouldBeDead()
        {
            Assert.AreEqual(true, deadDummy.IsDead());
        }

        [Test]
        public void When_DummyHealthIsNegative_ShouldBeDead()
        {
            dummy = new Dummy(-3, experience);
            Assert.AreEqual(true, dummy.IsDead());
        }

        [Test]
        public void When_DummyHealthIsPositive_ShouldBeAlive()
        {
            Assert.AreEqual(false, dummy.IsDead());
        }

        [Test]
        public void When_DummyIsDeadAndTakeAttack_ShouldThrowException()
        {
            Assert.That(() =>
            {
                deadDummy.TakeAttack(10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void When_GiveExperienceAndDummyIsNotDead_ShouldThrowException()
        {
            Assert.That(() =>
            {
                dummy.GiveExperience();
            }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        [Test]
        public void When_GiveExperienceAndDummyIsDead_ShouldReturnExperience()
        {
            Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
        }

    }
}