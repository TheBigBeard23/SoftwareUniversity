using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 2;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(100, 6);
    }

    [Test]
    public void AxeAttackAndDurabilitySetting()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void ValidAxeAttack()
    {
        axe.Attack(dummy);
        Assert.AreEqual(durability - 1, axe.DurabilityPoints);
    }

    [Test]
    public void AttackWithZeroDurability()
    {
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

    [Test]
    public void AttackWithNegativeDurability()
    {
        axe = new Axe(10, -10);
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            axe.Attack(dummy);
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

}