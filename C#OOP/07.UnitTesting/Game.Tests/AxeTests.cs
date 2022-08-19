using NUnit.Framework;
using System;

namespace Game.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attack = 5;
        private int durability = 6;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(5, 6);
        }
        [Test]
        public void When_DurabilityAndAttackProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(attack, axe.AttackPoints);
            Assert.AreEqual(durability, axe.DurabilityPoints);
        }
        [Test]
        public void When_AxeAttacks_ShouldLooseDurabilityPoints()
        {
            axe.Attack(dummy);
            Assert.AreEqual(durability - 1, axe.DurabilityPoints);
        }
        [Test]
        public void When_AxeAttackWithDurabilityPointsAreZero_ShouldThrowException()
        {
            axe = new Axe(5, 0);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });

            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}