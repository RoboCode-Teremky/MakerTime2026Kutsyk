using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    NavMeshAgent agent;
    Transform target;
    [SerializeField] int hp = 3;
    [SerializeField] int damage = 1;
    bool attackCooldown = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.updatePosition = false;
        agent.updateRotation = true;
        target = FindAnyObjectByType<MovementController>().transform;
    }

    void OnAnimatorMove()
    {
        Vector3 rootPosition = animator.rootPosition;
        rootPosition.y = agent.nextPosition.y;
        transform.position = rootPosition;
        //transform.rotation = animator.rootRotation;
        agent.nextPosition = rootPosition;
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Velocity", agent.desiredVelocity.magnitude);
    }

    public void OnTakeDamage(int damage = 1)
    {
        hp -= damage;
        if (hp > 0) animator.SetTrigger("Damage");
        else
        {
            animator.SetTrigger("Dead");
            agent.isStopped = true;
            Destroy(gameObject, 2.0f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!attackCooldown && other.TryGetComponent<PlayerHP>(out PlayerHP player))
        {
            attackCooldown=true;
            animator.SetTrigger("Attack");
            player.OnTakeDamage();
        }
    }

    public void ResetAttack()
    {
        attackCooldown = false;
    }
}
