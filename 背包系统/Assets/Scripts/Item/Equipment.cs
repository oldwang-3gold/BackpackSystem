using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item {
    /// <summary>
    /// 力量
    /// </summary>
	public int Strength { get; set; }
    /// <summary>
    /// 智力
    /// </summary>
    public int Intelligence { get; set; }
    /// <summary>
    /// 敏捷
    /// </summary>
    public int Agility { get; set; }
    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType { get; set; }

    public Equipment(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice,string sprite,
        int strength,int intelligence,int agility,int stamina,EquipmentType equipType):base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
        this.Strength = strength;
        this.Intelligence = intelligence;
        this.Agility = agility; 
        this.Stamina = stamina;
        this.EquipType = equipType;
    }

    public enum EquipmentType
    {
        Head,
        Neck,
        Ring,
        Leg,
        Bracer,
        Boots,
        Trinket,
        Shoulder,
        Belt,
        OffHand
    }
}
