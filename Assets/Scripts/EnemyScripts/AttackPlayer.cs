using UnityEngine;

public class AttackPlayer : MonoBehaviour {
    public float attackSpeed = 2; // Time between attacks
    public int attackDamage = 10; // Health per attack
    public float attackRange = 1;

    private GameObject player;
    private Vector3 playerLocation;
    private Vector3 enemyLocation;
    private float timeSinceLastAttack = 0f;

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerLocation = player.transform.position;
        enemyLocation = gameObject.transform.position;
    }

    void Update() {
        playerLocation = player.transform.position;
        enemyLocation = gameObject.transform.position;

        // If enemy is in range and enemy can strike
        if ((playerLocation - enemyLocation).magnitude < attackRange && timeSinceLastAttack > attackSpeed) {
            // Cause Damage to player
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.causeDamage(attackDamage);

            timeSinceLastAttack = 0f;
        } else {
            timeSinceLastAttack += Time.deltaTime;
        }
    }
}
