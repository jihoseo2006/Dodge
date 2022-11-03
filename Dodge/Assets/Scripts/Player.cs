using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 이동시 사용하는 리지드바디 컴포넌트
    public float Movespeed = 12f;
    public static float Hp = 5;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
