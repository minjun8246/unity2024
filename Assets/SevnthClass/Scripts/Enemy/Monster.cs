using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [Header("�� �ǰ� �ִϸ��̼� ���� ����")]
    public float hitBackTime = 0.5f;
    public int hitCount;
    public int currentHP;
    public int maxHP = 2;
    private SkinnedMeshRenderer skinnedMeshRenderer; // �ǰ� �� ������ �����ϱ� ���� ���� ������ �����ϴ� ����
    private bool isDeath;
    private NavMeshAgent Agent; // �׺�޽ÿ�����Ʈ ������ ���� ���� ����

    [Header("�� ã�� ���� ����")]
    public Transform target;

    [Header("������ �ൿ ���� ����")]
    public float finddistance; // Ÿ���� Ž�� �����ϴ� �ִ� �Ÿ�
    public float attackRange;

    // ���Ͱ� �÷��̾�� ���� �޾��� �� �������� �Դ� ���ϸ��̼� ����
    [Header("�ִϸ��̼� ������ ���� �ʿ��� ����")]
    public Animator anim;

    // �ִϸ��̼� �̸� ����

    public readonly string takeDamegeAnimationName = "IsHit";
    public readonly string DeathAimtionName = "doDeath";
    private void Awake()
    {
        LoadComponents();
    }

    private void LoadComponents() 
    { 
        // �ʱ�ȭ�� �����͸� ������ ó�� �Ҵ� ���ִ� ��
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void Update()
    {
        //�÷��̾ Ž�� �ϴ� ��� - Ž�� ���� �Ÿ��� �÷��̾ �ִ°�?

        target = FindObjectOfType<PlayerController>().gameObject.transform;

        if(finddistance >= Vector3.Distance(transform.position, target.position)) // Ÿ�ٰ� ���� �Ÿ�
        {
          // Debug.Log(Vector3.Distance(transform.position, target.position));

            //�÷��̾ �i�� ���
            Agent.SetDestination(target.position);
        }
        
        
        //���� ���� ��� - ����

        if(attackRange >= Vector3.Distance(transform.position, target.position)) 
        {
            Debug.Log("�����մϴ�.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        Gizmos.DrawWireSphere(transform.position, finddistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void TakeDamage() 
    {
        if (isDeath) return;
        hitCount++;
        anim.SetBool(takeDamegeAnimationName, true);
        StartCoroutine(TakeDamegeEffect());

        if (hitCount >= maxHP) 
        { 
            hitCount = 0;
            OnDeath();
        }
    }

    IEnumerator TakeDamegeEffect() 
    {
        // �������� �������� ȿ�� ���� �κ�
        ShakeCamera.Instance.OnShakeCamera(0.1f, 0.15f);
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(hitBackTime);
        skinnedMeshRenderer.material.color = Color.white;

        // ������ ���Ḧ �˸��� �ڵ带 ���� �κ�
        anim.SetBool(takeDamegeAnimationName, false);
    }

    private void OnDeath()
    {
        anim.SetTrigger(DeathAimtionName);
        isDeath = true;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
