using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatchecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster")) 
        {
            Debug.Log("���Ϳ� �浹 �߽��ϴ�.");
            

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
