using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour {
    public List<ItemData> itemList = new List<ItemData>();
    public List<ItemData> hotbar = new List<ItemData>();

    public InputActionReference use;

    private int currentSlot = 0;

    void OnEnable() {
        use.action.Enable();
    }

    void OnDisable() {
        use.action.Disable();
    }

    void Update() {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.digit1Key.wasPressedThisFrame) currentSlot = 0;
        else if (kb.digit2Key.wasPressedThisFrame) currentSlot = 1;
        else if (kb.digit3Key.wasPressedThisFrame) currentSlot = 2;
        else if (kb.digit4Key.wasPressedThisFrame) currentSlot = 3;
        else if (kb.digit5Key.wasPressedThisFrame) currentSlot = 4;
        else if (kb.digit6Key.wasPressedThisFrame) currentSlot = 5;
        else if (kb.digit7Key.wasPressedThisFrame) currentSlot = 6;
        else if (kb.digit8Key.wasPressedThisFrame) currentSlot = 7;
        else if (kb.digit9Key.wasPressedThisFrame) currentSlot = 8;
        
        if (use.action.WasPressedThisFrame()) {
            useItem(itemList[currentSlot]);
        }
    }


    public void addItem(ItemData itemType) {
        // Create new itemdata of type
        itemList.Add(itemType);
        if (hotbar.Count < 9) {
            hotbar[hotbar.Count] = itemType;
        }
    }

    private void useItem(ItemData itemType) {
        itemType.Use();
    }
}
