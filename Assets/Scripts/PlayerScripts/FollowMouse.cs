using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour {
    public InputActionReference mousePoint;
    
    private Transform tr;
    private Vector2 screenCenter;
    private Vector2 offset;
    private Vector3 screenPos;
    private float angle;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void OnEnable() {
        mousePoint.action.Enable();
    }

    void OnDisable() {
        mousePoint.action.Disable();
    }

    void Update() {
        Vector2 mouseScreenPos = mousePoint.action.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);

        Plane ground = new Plane(Vector3.up, tr.position);

        if (ground.Raycast(ray, out float distance))
        {
            Vector3 target = ray.GetPoint(distance);

            Vector3 direction = target - tr.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                tr.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
