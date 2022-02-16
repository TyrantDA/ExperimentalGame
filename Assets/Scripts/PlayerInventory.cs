using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    Dictionary<ItemInfo, int> items = new Dictionary<ItemInfo, int>();


    public void AddItem(ItemInfo newItem)
    {
        if(items.ContainsKey(newItem))
         {
            items[newItem]++;
        }
        else
        {
            items.Add(newItem, 1);
        }
    }

    

    public bool HasItem(ItemInfo checkItem)
    {
        if (items.ContainsKey(checkItem))
        {
            return true;
        }
        else return false;
    }
}
