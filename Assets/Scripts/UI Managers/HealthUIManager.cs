using UnityEngine;
using UnityEngine.UIElements;

public class HealthUIManager : MonoBehaviour {
    private GameObject player;
    private Health health;
    private VisualElement healthForeground;
    private Label healthLabel;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
    }

    void OnEnable() {
        VisualElement root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        healthLabel = root.Q<Label>("HealthText");
        healthForeground = root.Q<VisualElement>("HealthForeground");
    }

    void Update() {
        healthLabel.text = health.currentHealth.ToString();
        healthForeground.style.width = health.currentHealth * 2; // Ratio of 2 px to 1 health point
    }
}
