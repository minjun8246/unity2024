using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 우리가 선택한 애니메이션 움직임 대로 캐리 움직이도록 하는 기능을 구현할 겁니다.

    Animator animator;
    public enum PlayerState { Idle, Run, Death }
    PlayerState playerstate;

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
        SetPlayerAnimation();
    }

    // 한번만 실행하면 되는 기능을 구현하는 함수이다.
    void Initialize() 
    { 
        // Animation 클레스에 접근을 할 수 있게 됩니다.
        animator = GetComponentInChildren<Animator>();
    }

    // 현재 나의 상태를 
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

    // 게임에서 애니메이션을 실행시키기 위해 Update문 선언할 함수이다.
    // 플레이어의 강태에 따라 다은 애니메이션을 실행해야하는데 
    // 그 조건을 판단해주는 함수입니다.
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
    }

    public void PlayerDeath()
    {
        if (GameManager.Instance.IsPlayerDeath == true) return;

        // if (animator == null) return; 이 함수는 "?" 와 같다.
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
