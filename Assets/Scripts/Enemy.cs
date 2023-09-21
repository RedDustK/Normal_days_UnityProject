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
    // Start is called before the first frame update
    void Start()
    {

       Agent = GetComponent<NavMeshAgent>(); 
       animator = GetComponent<Animator>();
       Target = GameObject.Find("Woman").transform;
       player=GameObject.Find("Woman").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && !attack)
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
        player.TakeDamage(AttackDamage);
        AttackMove(false);
        attack=false;
    }
   

   
}
