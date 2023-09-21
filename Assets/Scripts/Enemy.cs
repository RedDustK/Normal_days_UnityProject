using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy :Unit
{

    [SerializeField] Transform Target;
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Animator animator;
    Player player;
    public bool attack;
    public bool Died;
    // Start is called before the first frame update
    void Start()
    {

       Agent = GetComponent<NavMeshAgent>(); 
       animator = GetComponent<Animator>();
       Target = GameObject.Find("Woman").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && !attack&&!Died)
        {
            animator.SetBool("IsRunning", true);
            Agent.destination = Target.position;

        }

        else { animator.SetBool("IsRunning", false); }
    }

    public void AttackMove(bool Attack)
    {
        animator.SetBool("IsAttack",Attack);
       
    }

    public void DamagetoPlayer()
    {
        GameManager.Instance.player.TakeDamage(AttackDamage);
        animator.SetBool("IsAttack", false);
        AttackMove(false);
        attack=false;
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Died = true;
            animator.SetTrigger("Die");
            Destroy(gameObject, 0.8f);
            
        }
    }
    public void running()
    {
        animator.SetBool("IsRunning", true);
    }


}
