using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public int AttackDamage;
    // Start is called before the first frame update
    void Start()
    {
        //HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
