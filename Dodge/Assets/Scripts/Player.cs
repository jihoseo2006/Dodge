using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 이동시 사용하는 리지드바디 컴포넌트
    public float Movespeed = 12f; //플레이어 이동 속도
    public static float Hp = 5; //플레이어 Hp
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); //playerRigidbody에 리지드바디 컴포넌트 찾아서 할당
    }

   
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); 
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * Movespeed;
        float zSpeed = zInput * Movespeed;
        
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;
    }

    public void Die()//플레이어 사망 함수
    {
        gameObject.SetActive(false);//자신의 게임 오브젝트를 비활성화
        GameManager gameManager = FindObjectOfType<GameManager>();//GameManager 컴포넌트 찾아서 gameManager에 할당.
        gameManager.EndGame();//GameManager에 EndGame 함수 실행
    }
}
