using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<ItemData> itemList = new List<ItemData>();

    public void addItem(ItemData itemType) {
        // Create new itemdata of type
        itemList.Add(itemType);
    }
}
