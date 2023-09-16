
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttack : MonoBehaviour
{

    [SerializeField] float damage = 30f;
    NavMeshAgent navMeshAgent;
    PlayerHealth target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.kill(this.damage);

    }

}
