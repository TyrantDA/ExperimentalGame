using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIItem : MonoBehaviour
{
    public Text titleText;
    public Text amountText;
    public Image icon;



    public void SetItem(ItemInfo newItem, int amount)
    {
        titleText.text = newItem.title;
        amountText.text = amount.ToString();
        icon.sprite = newItem.icon;
    }

}
