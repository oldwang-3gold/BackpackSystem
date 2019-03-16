using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {

    public int HP { get; set; }
    public int MP { get; set; }
    public Consumable(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, int hp, int mp)
        :base(id, name, type, quality, des, capacity, buyPrice, sellPrice)
    {
        this.HP = hp;
        this.MP = mp;
    }

}
