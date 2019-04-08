﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Consumable : Item {

    public int HP { get; set; }
    public int MP { get; set; }
    public Consumable(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice,string sprite, int hp, int mp)
        :base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
        this.HP = hp;
        this.MP = mp;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(ID.ToString());
        stringBuilder.Append(Name);
        stringBuilder.Append(Type);
        stringBuilder.Append(Quality);
        stringBuilder.Append(Description);
        stringBuilder.Append(Capacity);
        stringBuilder.Append(BuyPrice);
        stringBuilder.Append(SellPrice);
        stringBuilder.Append(HP);
        stringBuilder.Append(MP);
        stringBuilder.Append(Sprite);
        return stringBuilder.ToString();
    }

}
