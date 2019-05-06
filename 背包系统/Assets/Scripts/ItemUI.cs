using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {
    #region data
    public Item Item { get; set; }
    public int Amount { get; set; }
    #endregion

    #region UI Components
    private Image itemImage;
    private Text amountText;
    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }

            return itemImage;
        }
    }
    private Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = GetComponentInChildren<Text>();
            }

            return amountText;
        }
    }
    #endregion



    public void SetItem(Item item,int amount=1)
    {
        this.Item = item;
        this.Amount = amount;
        //Update ui
        ItemImage.sprite=Resources.Load<Sprite>(item.Sprite);
        AmountText.text = Amount.ToString();
    }

    public void AddAmount(int amount=1)
    {
        this.Amount += amount;
        //Update ui
        AmountText.text = Amount.ToString();
    }
    


}
