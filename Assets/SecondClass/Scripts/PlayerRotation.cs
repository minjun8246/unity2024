using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // 회전 하는 기능을 구현해볼겁니다.

    public float rotateSpeed = 200f;

    void Update()
    {


        RotatePlayer();

    }

    private void RotatePlayer() 
    {
        // A와 D키를 입력했을 깨 해당 방향으로 회전하는 기능을 구현

        // 입력 구현
        float horizontal = Input.GetAxis("Horizontal"); // -1 ~ 1값을 반환해주는 기능
        // 회전 구현 -> 어느 방향으로 회전을 시켜야할까?
        float yaw = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw, Space.World); // 절대 좌표와 상대 좌표
    }


}
