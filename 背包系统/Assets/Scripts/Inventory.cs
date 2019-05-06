using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Slot[] slotList;

    public virtual void Awake ()
    {
        slotList = GetComponentsInChildren<Slot>();
        Debug.Log(slotList.Length);
    }

    public bool StoreItem(int id)
    {
        Debug.Log(id);
        Item item = InventoryManager.Instance.GetItemById(id);
        return StoreItem(item);
    }

    /// <summary>
    /// 判断是否可以存储物品
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool StoreItem(Item item)
    {
        if (item == null)
        {
            Debug.LogWarning("要存储的物品的ID不存在");
            return false;
        }

        if (item.Capacity == 1)//当前物品容量为1时 
        {
            Slot slot = FindEmptySlot();  //寻找别的空格子
            if (slot == null)
            {
                Debug.LogWarning("物品槽已满");
            }
            else
            {
                slot.StoreItem(item);//把物品存储到这个空的物品槽里面
            }
        }
        else//当前物品容量比1大
        {
            Slot slot = FindSameTypeSlot(item);//要找到一个有相同item类型的格子，并且物品持有数量要小于物品容量
            if (slot != null)
            {
                slot.StoreItem(item);
            }
            else//要找一个空的物品格子存进去
            {
                Slot emptySlot = FindEmptySlot();
                if (emptySlot != null)
                {
                    emptySlot.StoreItem(item);
                }
                else
                {
                    Debug.LogWarning("没有空格子");
                    return false;
                }
            }
        }

        return true;

    }

    /// <summary>
    /// 这个方法用来找到一个空的物品槽
    /// </summary>
    /// <returns></returns>
    private Slot FindEmptySlot()
    {
        for (int i = 0; i < slotList.Length; i++)//遍历寻找一个空格子
        {
            if (slotList[i].transform.childCount == 0)
            {
                return slotList[i];
            }
        }
        return null;
    }

    private Slot FindSameTypeSlot(Item item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount >= 1 && slot.GetItemType()==item.Type && slot.IsFilled() == false)
            {
                return slot;
            } 
        }
        return null;
    }

	
}
