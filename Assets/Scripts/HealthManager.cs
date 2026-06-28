using UnityEngine;
using UnityEngine.UIElements;

public class HealthManager : MonoBehaviour {
    private GameObject player;
    private Health health;
    private Label healthLabel;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
    }

    void OnEnable() {
        VisualElement root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        healthLabel = root.Q<Label>("Health");
    }

    void Update() {
        healthLabel.text = health.currentHealth.ToString();
    }
}
