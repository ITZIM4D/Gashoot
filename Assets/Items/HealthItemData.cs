using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemData", menuName = "Items/HealthItemData")]
public class HealthItemData : ItemData {
    public int healAmount = 10;

    public override void Use() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().heal(healAmount);
    }
}
