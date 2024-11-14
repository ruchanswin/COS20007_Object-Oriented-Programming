﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Iteration4
{
    public class Player(string name, string desc) : GameObject(idents, name, desc), IHaveInventory
    {
        private readonly Inventory _inventory = new();
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + Name + ", " + base.FullDescription + ".\nYou are carrying:\n" + _inventory.ItemList;
            }
        }
   
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        private static readonly string[] idents = ["me", "inventory"];
    }
}