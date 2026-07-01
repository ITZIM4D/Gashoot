using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemData", menuName = "Items/HealthItemData")]
public class HealthItemData : ItemData {
    public override void Use(GameObject user) {
        Debug.Log("Health Item Used");
    }
}
