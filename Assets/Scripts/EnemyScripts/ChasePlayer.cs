using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour {
    public float movementSpeed = 1f;
    public float aggroDistance = 10f;

    private GameObject player;
    private NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        player = GameObject.FindWithTag("Player");

        agent.speed = movementSpeed;
        agent.isStopped = true;
    }

    void Update() {
        float distance = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        if (distance < aggroDistance) {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else {
            agent.isStopped = true;
            wander();
        }
    }

    private void wander() {
        // wandering logic here
    }
}