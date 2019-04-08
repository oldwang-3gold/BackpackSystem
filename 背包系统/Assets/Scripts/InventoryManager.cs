using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class InventoryManager : MonoBehaviour
{
    
    #region 单例模式
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }      
    }
    #endregion

    void Start()
    {
        ParseItemJson();
    }
    /// <summary>
    /// 物品信息的集合
    /// </summary>
    private List<Item> itemList;

    /// <summary>
    /// 解析物品信息
    /// </summary>
    void ParseItemJson()
    {
        
        itemList=new List<Item>();

        TextAsset itemText = Resources.Load<TextAsset>("Items");
        string itemsJson = itemText.text;//物品信息的Json格式
        JsonData data = JsonMapper.ToObject(itemsJson);
        foreach (JsonData temp in data)
        {
            string typeStr = temp["type"].ToString();
            Item.ItemType type=(Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);
            //解析这个对象里面的公有属性
            int id = int.Parse(temp["id"].ToString());
            string name = temp["name"].ToString();
            Item.ItemQuality quality =
                (Item.ItemQuality) System.Enum.Parse(typeof(Item.ItemQuality), temp["quality"].ToString());
            string description = temp["description"].ToString();
            int capacity = int.Parse(temp["capacity"].ToString());
            int buyPrice = int.Parse(temp["buyPrice"].ToString());
            int sellPrice = int.Parse(temp["sellPrice"].ToString());
            string sprite = temp["sprite"].ToString();
            Item item = null;

            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp = int.Parse(temp["hp"].ToString());
                    int mp = int.Parse(temp["mp"].ToString());
                    item=new Consumable(id,name,type,quality,description,capacity,buyPrice,sellPrice,sprite,hp,mp);
                    break;
                case Item.ItemType.Equipment:
                    break;
                case Item.ItemType.Weapon:
                    break;
                case Item.ItemType.Material:
                    break;
            }
            itemList.Add(item);
            Debug.Log(item);
        }
    }
}
