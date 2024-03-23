using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �츮�� ������ �ִϸ��̼� ������ ��� ĳ�� �����̵��� �ϴ� ����� ������ �̴ϴ�.

    Animator animator;
    public enum PlayerState { Idle, Run, Death, Attack }
    PlayerState playerstate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("NPC�� �浹�߽��ϴ�.");
            var trigger = other.GetComponent<SampleTextTrigger>();
            trigger.TriggerText();
        }
        else 
        {
            Debug.Log("�±װ� NPC�� �ƴմϴ�.");
        }
    }
    public BoxCollider hitbox;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlayerDeath == true) return;
        
        

        SetPlayerState();
        if (Input.GetMouseButtonDown(0))
        {
            SetAttack();
        }
        SetPlayerAnimation();
    }

   

    // �ѹ��� �����ϸ� �Ǵ� ����� �����ϴ� �Լ��̴�.
    void Initialize() 
    { 
        // Animation Ŭ������ ������ �� �� �ְ� �˴ϴ�.
        animator = GetComponentInChildren<Animator>();
    }

    // ���� ���� ���¸� 
    private void SetPlayerState() 
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Vertical");

        if (v != 0 || h != 0)
        {
            playerstate = PlayerState.Run;
        }
        else
        { 
            playerstate= PlayerState.Idle;
        }
    }

    private void SetAttack()
    {
        playerstate = PlayerState.Attack;
        StartCoroutine(ATKoff());
    }

    private void SetATKoff()
    {
        hitbox.enabled = false;
    }

    IEnumerator ATKoff() 
    {
        hitbox.enabled = true;
        yield return new WaitForSeconds(0.5f);
        hitbox.enabled = false;
    }

    // ���ӿ��� �ִϸ��̼��� �����Ű�� ���� Update�� ������ �Լ��̴�.
    // �÷��̾��� ���¿� ���� ���� �ִϸ��̼��� �����ؾ��ϴµ� 
    // �� ������ �Ǵ����ִ� �Լ��Դϴ�.
    private void SetPlayerAnimation() 
    {
        if (playerstate == PlayerState.Idle)
        {
            PlayerIdle();
        }
        else if (playerstate == PlayerState.Run) 
        {
            PlayerMove();
        }
        else if(playerstate == PlayerState.Attack)
        {
            animator.SetTrigger("IsATK");
        }
    }

    public void PlayerDeath()
    {
        if (GameManager.Instance.IsPlayerDeath == true) return;

        // if (animator == null) return; �� �Լ��� "?" �� ����.
        // animator.SetTrigger("Death");
        animator?.SetTrigger("Death");
        GameManager.Instance.IsPlayerDeath = true;
        GameManager.Instance.GameOver();
    }

    public void PlayerMove() 
    {
        animator.SetBool("IsRun", true);
    }

    public void PlayerIdle() 
    {
        animator.SetBool("IsRun", false);
    }


}
