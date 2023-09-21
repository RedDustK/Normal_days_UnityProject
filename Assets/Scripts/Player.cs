using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class Player : Unit
{
    public event Action<Player> onHpChanged;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            GameManager.Instance.GameOver(false);

        }
        if(onHpChanged != null)
        {
            onHpChanged(this);
        }
    }

   
}
