using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour {
    public InputActionReference rightClick;
    public InputActionReference mousePoint;
    public ItemData itemType;

    GameObject createObject;

    void OnEnable() {
        rightClick.action.Enable();
        mousePoint.action.Enable();
    }

    void Disable() {
        rightClick.action.Disable();
        mousePoint.action.Disable();
    }

    void Update() {
        GameObject clickedObject;
        Vector2 mouseScreenPos = mousePoint.action.ReadValue<Vector2>();

        if (rightClick.action.WasPressedThisFrame()) {
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.CompareTag("Item")) {
                    clickedObject = hit.collider.gameObject;
                    Destroy(clickedObject);
                }
            }
        }
    }
}
