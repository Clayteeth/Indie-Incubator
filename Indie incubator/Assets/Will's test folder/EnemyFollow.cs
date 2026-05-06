using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public bool isUsingNavmesh;
    [Tooltip("Only when not using NavMesh")]
    public float moveSpeed = 3f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isUsingNavmesh)
        {
            agent.SetDestination(player.position);
        }
        else // do a linear follow
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z); // lock y
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
