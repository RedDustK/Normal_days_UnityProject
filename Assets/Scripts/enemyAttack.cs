using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public Transform player;
    public Enemy enemy;
    bool m_isPlayerinRange;
    private void Start()
    {
        player = GameObject.Find("Woman").transform;
        enemy = gameObject.GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_isPlayerinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.AttackMove(false);
            m_isPlayerinRange = false;
            enemy.attack = false;
        }
    }

    private void Update()
    {
        if (m_isPlayerinRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                enemy.AttackMove(true);
                enemy.attack=true;
            }
        }
    }
}
