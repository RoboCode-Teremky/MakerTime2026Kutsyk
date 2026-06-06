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

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<MovementController>().transform;
    }

    void Update()
    {
        agent.destination = target.position;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHP>(out PlayerHP player))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        PlayerHP playerHP = target.GetComponent<PlayerHP>();
        playerHP.OnTakeDamage();
    }
}
