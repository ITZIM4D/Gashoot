using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour {
    public InputActionReference mouseClick;

    private Transform tr;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void OnEnable() {
        mouseClick.action.Enable();
    }

    void OnDisable() {
        mouseClick.action.Disable();
    }

    void Update() {
        GameObject hitObject;
        if (mouseClick.action.WasPressedThisFrame()) {
            // Raycast from player forward
            if (Physics.Raycast(tr.position, tr.forward, out RaycastHit hit)) {
                hitObject = hit.transform.gameObject;
                if (hitObject.CompareTag("Enemy")) {
                    Health EnemyHealth = hitObject.GetComponent<Health>();
                    EnemyHealth.causeDamage(20);
                }
            }
        }
    }
}
