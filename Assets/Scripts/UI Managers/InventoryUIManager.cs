using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour {
    private GameObject player;
    private Inventory inventory;
    private VisualElement slot1Icon;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    void OnEnable() {
        VisualElement root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        slot1Icon = root.Q<VisualElement>("Icon");
    }

    void Update() {
        // TODO: Make this work on a callback in the future so it's not called every frame
        if (player.GetComponent<Inventory>().itemList.Count > 0) {
            slot1Icon.style.backgroundImage = new StyleBackground(player.GetComponent<Inventory>().itemList[0].icon);
        }

    }
}
