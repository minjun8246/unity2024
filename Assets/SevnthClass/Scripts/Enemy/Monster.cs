using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [Header("적 피격 애니메이션 제어 변수")]
    public float hitBackTime = 0.5f;
    public int hitCount;
    public int currentHP;
    public int maxHP = 2;
    private SkinnedMeshRenderer skinnedMeshRenderer; // 피격 시 색상을 변경하기 위한 재질 정보를 저장하는 변수
    private bool isDeath;
    private NavMeshAgent Agent; // 네브메시에이전트 변경을 위한 정보 저장

    [Header("길 찾기 제어 변수")]
    public Transform target;

    [Header("몬스터의 행동 제어 변수")]
    public float finddistance; // 타켓을 탐색 시작하는 최대 거리
    public float attackRange;

    // 몬스터가 플레이어에게 공갹 받았을 때 데미지를 입는 에니메이션 실행
    [Header("애니메이션 실행을 위해 필요한 변수")]
    public Animator anim;

    // 애니메이션 이름 정리

    public readonly string takeDamegeAnimationName = "IsHit";
    public readonly string DeathAimtionName = "doDeath";
    private void Awake()
    {
        LoadComponents();
    }

    private void LoadComponents() 
    { 
        // 초기화는 데이터를 변수에 처음 할당 해주는 것
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void Update()
    {
        //플레이어를 탐색 하는 기능 - 탐색 가능 거리에 플레이어가 있는가?

        target = FindObjectOfType<PlayerController>().gameObject.transform;

        if(finddistance >= Vector3.Distance(transform.position, target.position)) // 타겟과 나의 거리
        {
          // Debug.Log(Vector3.Distance(transform.position, target.position));

            //플레이어를 쫒는 기능
            Agent.SetDestination(target.position);
        }
        
        
        //적의 공격 기능 - 공격

        if(attackRange >= Vector3.Distance(transform.position, target.position)) 
        {
            Debug.Log("공격합니다.");
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
        // 데미지를 입혔을때 효과 구현 부분
        ShakeCamera.Instance.OnShakeCamera(0.1f, 0.15f);
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(hitBackTime);
        skinnedMeshRenderer.material.color = Color.white;

        // 데미지 종료를 알리는 코드를 구현 부분
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
