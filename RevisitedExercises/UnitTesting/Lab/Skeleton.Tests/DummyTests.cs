using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private int attack = 10;
    private int durability = 100;
    private int health = 100;
    private int experience = 20;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void HealthAndExperienceSetting()
    {
        Assert.AreEqual(health, dummy.Health);
        dummy.TakeAttack(health);
        Assert.AreEqual(experience, dummy.GiveExperience());
    }

    [Test]
    public void DummyShouldBeLosingHealth()
    {
        int attackPoints = 10;

        dummy.TakeAttack(attackPoints);
        Assert.AreEqual(health - attackPoints, dummy.Health);

        axe.Attack(dummy);
        Assert.AreEqual(health - axe.AttackPoints - attackPoints, dummy.Health);
    }

    [Test]
    public void DeadDummyShouldThrowException()
    {
        dummy.TakeAttack(health);

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.TakeAttack(health);
        });

        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyShouldGiveExperience()
    {
        dummy.TakeAttack(health);
        Assert.AreEqual(experience, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyShouldNotGiveExperience()
    {

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        });

        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }

    [Test]
    public void IsDead_WhenHealthBelowOrEqualZero_ShouldReturnTrue()
    {
        dummy.TakeAttack(health);
        Assert.IsTrue(dummy.IsDead());

        dummy = new Dummy(health, experience);

        dummy.TakeAttack(health + attack);
        Assert.IsTrue(dummy.IsDead());
    }
}
