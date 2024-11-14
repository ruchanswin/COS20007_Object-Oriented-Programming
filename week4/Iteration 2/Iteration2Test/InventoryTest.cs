﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Iteration2
{
    [TestFixture]
    public class TestInventory
    {
        Inventory inventory;
        Item sword;
        Item shield;
        Item potion;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
          
            sword = new Item(["sword"], "diamond", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold", "a gold shield that lasts a lifetime");
            potion = new Item(["potion"], "healing", "a healing potion which is needed for the adventurers");
           
            inventory.Put(sword);
            inventory.Put(shield);
        }
        [Test]
        public void TestFindItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.HasItem("sword"), Is.True);
                Assert.That(inventory.HasItem("shield"), Is.True);
            });
        }
        [Test]
        public void TestNoItemFind()
        {
            Assert.That(inventory.HasItem("potion"), Is.False);
        }
        [Test]
        public void TestFetchItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.Fetch("sword"), Is.EqualTo(sword));
                Assert.That(inventory.HasItem("sword"), Is.True);
            });
        }
        [Test]
        public void TestTakeItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.Take("sword"), Is.EqualTo(sword));
                Assert.That(inventory.HasItem("sword"), Is.False);
                Assert.That(inventory.HasItem("shield"), Is.True);
                Assert.That(inventory.HasItem("potion"), Is.False);
            });

        }
        [Test]
        public void TestItemList()
        {
            Assert.That(inventory.ItemList, Is.EqualTo("\ta diamond (sword)\n\ta gold (shield)\n"));
        }
    }
}
