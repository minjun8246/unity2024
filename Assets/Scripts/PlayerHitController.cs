using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    Animator anim;

    public float currentHP;
    public float maxHP = 3;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = maxHP;
    }

    public void TakeDamage() // 플레이어 데미지 받는 로직 구현
    {
        
        currentHP -= 1;      
        CheckHP();

        if (GameManager.Instance.IsPlayerDeath) 
        {
            return;
        }

        anim.CrossFade("PlayerTakeDamage", 0.2f);
    }

    private void CheckHP() 
    { 
    if (currentHP <= 0) 
        { 
            GameManager.Instance.IsPlayerDeath = true;
            anim.CrossFade("Die1", 0.2f);
            GameManager.Instance.GameOver();
        }
    }
}
