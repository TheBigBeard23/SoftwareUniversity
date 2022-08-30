namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void SetUp()
        {
            name = "Pesho";
            damage = 100;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void When_NameDamageAndHpProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void When_NameIsEmptyOrWhitespace_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", damage, hp));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", damage, hp));
        }

        [Test]
        public void When_DamageValueIsNegativeOrZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 0, hp));
            Assert.Throws<ArgumentException>(() => new Warrior(name, -1, hp));
        }

        [Test]
        public void When_HpIsNegative_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, -1));
        }
        [Test]
        public void When_WarriorAttackAndHpIsLessThanOrEqualToMinAttackHp_ShouldThrowException()
        {
            warrior = new Warrior("Pesho", 100, 30);
            var enemy = new Warrior("Ivan", 10, 100);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));

            warrior = new Warrior("Pesho", 100, 20);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void When_EnemyHpIsLessThanOrEqualToMinAttackHp_ShouldThrowException()
        {
            var secondWarrior = new Warrior("Ivan", 10, 30);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior));

            secondWarrior = new Warrior("Ivan", 10, 10);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior));
        }

        [Test]
        public void When_WarriorAttackAndEnemyDamageIsGreaterThanWarriorHp_ShouldThrowException()
        {
            var enemy = new Warrior("Ivan", 1000, 100);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void When_WarriorAttack_ShouldLoosHp()
        {
            var enemy = new Warrior("Ivan", 10, 100);
            int hp = warrior.HP - enemy.Damage;
            warrior.Attack(enemy);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void When_WarriorAttackEnemy_ShouldLoosHp()
        {
            var enemy = new Warrior("Ivan", 10, 90);
            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);

            enemy = new Warrior("Ivan", 10, 120);
            int hp = enemy.HP - warrior.Damage;
            warrior.Attack(enemy);
            Assert.AreEqual(hp, enemy.HP);
        }
    }
}