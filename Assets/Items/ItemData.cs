using UnityEngine;

public abstract class ItemData : ScriptableObject {
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;

    // Describe what happens when an object gets used
    public abstract void Use();
}
