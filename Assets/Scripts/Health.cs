using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    
    private bool isAlive = true;

    void Awake() {
    }

    void Start() {
        currentHealth = maxHealth;
    }

    public void causeDamage(int damageAmount) {
        if ((currentHealth -= damageAmount) > 0) {
            ;
        } else {
            isAlive = false;
            die();
        }
    }

    public void heal(int healAmount) {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healAmount);
    }

    private void die() {
        Destroy(gameObject);
    }
}

