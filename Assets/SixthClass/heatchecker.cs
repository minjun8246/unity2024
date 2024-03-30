using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatchecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster")) 
        {
            Debug.Log("몬스터와 충돌 했습니다.");
            

            Monster monster = other.gameObject.GetComponent<Monster>();

            monster.TakeDamage();
        }

        if (other.gameObject.CompareTag("Player")) 
        { 
             PlayerHitController hitController = other.gameObject.GetComponent<PlayerHitController>();

            hitController.TakeDamage();
        }
    }
}
