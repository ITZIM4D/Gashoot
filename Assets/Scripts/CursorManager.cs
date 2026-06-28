using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour {
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D aimCursor;
    [SerializeField] private Texture2D interactCursor;
    [SerializeField] private InputActionReference mousePoint;

    private Texture2D currentCursor;
    private Vector2 hotspot;

    void Awake() {
        if (!aimCursor) return;

        // Set the cursor to initial cursor
        currentCursor = aimCursor;
        hotspot = new Vector2(currentCursor.width / 2f, currentCursor.height / 2f);
        Cursor.SetCursor(currentCursor, hotspot, CursorMode.Auto);
    }

    void Update() {
        Vector2 mouseScreenPos = mousePoint.action.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);

        // Check what hovering over
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            GameObject hitObject = hit.collider.gameObject;

            // If Hovering over an Item or interactble (Add interactables in the future) change cursor
            if (hitObject.CompareTag("Item") && currentCursor != interactCursor) {
                // Point cursor at tip of finger
                hotspot -= new Vector2(5, 16);
                Cursor.SetCursor(interactCursor, hotspot, CursorMode.Auto);
                currentCursor = interactCursor;
            } else if (!hitObject.CompareTag("Item") &&currentCursor != aimCursor) {
                hotspot += new Vector2(5, 16);
                Cursor.SetCursor(aimCursor, hotspot, CursorMode.Auto);
                currentCursor = aimCursor;
            }
        }
    }
}
