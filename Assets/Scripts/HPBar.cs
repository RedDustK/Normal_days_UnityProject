using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPBar : MonoBehaviour
{
    public ImgsFillDynamic healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Player_OnHealthChanged(GameManager.Instance.player);
        GameManager.Instance.player.onHpChanged += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(Player player)
    {
        healthbar.SetValue(((float)GameManager.Instance.player.HP/GameManager.Instance.player.MaxHP), false, 1f);
    }
}
