using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public Animator ENEMY_COPY;

    public bool isUsingNavmesh;
    [Tooltip("Only when not using NavMesh")]
    public float moveSpeed = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isUsingNavmesh)
        {
            moveSpeed = 6f;
            agent.SetDestination(player.position);
        }
        else // do a linear follow
        {
            moveSpeed = 6f;
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z); // lock y
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
