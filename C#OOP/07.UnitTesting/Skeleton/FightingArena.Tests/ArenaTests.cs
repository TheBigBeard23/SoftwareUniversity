namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            attacker = new Warrior("Jon", 100, 100);
            defender = new Warrior("Dc", 90, 100);
            arena.Enroll(attacker);

        }
        [Test]
        public void When_ArenaProvided_ShouldBeSetCorrectly()
        {
            IReadOnlyCollection<Warrior> warriors = new List<Warrior>();
            Assert.AreEqual(warriors.GetType(), arena.Warriors.GetType());
        }

        [Test]
        public void When_ArenaProvidedCount_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void When_WarriorExistEnrollMethod_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(attacker));
        }

        [Test]
        public void When_WarriorDoesNotExistEnrollMethod_ShouldAddWarrior()
        {
            var foundWarrior = arena.Warriors.Where(w => w.Name == attacker.Name).FirstOrDefault();
            Assert.AreEqual(attacker.Name,foundWarrior.Name);
        }

        [Test]
        public void FightMethod_ShouldWorkCorrectly()
        {
            int hp = attacker.HP - defender.Damage;
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(hp, attacker.HP);

        }

        [Test]
        public void When_OneOfWarriorsDoNotExistFightMethod_ShouldThrowException()
        {
            int hp = attacker.HP - defender.Damage;

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

        }

    }
}
