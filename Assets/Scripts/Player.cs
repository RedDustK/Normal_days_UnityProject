using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected new virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log("»ç¸Á");
        }
    }

   
}
