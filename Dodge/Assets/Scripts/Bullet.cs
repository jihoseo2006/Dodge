using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 9f;// 탄환속도
    private Rigidbody bulletRigidbody;//이동시 사용할 리지드바디(동작 물리제어)
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();//게임 오브젝트에서 리지드바디 컴포넌트 찾아서 할당.
        bulletRigidbody.velocity = transform.forward * BulletSpeed;//탄환 리지드바디 속도
        Destroy(gameObject, 3f); //발사 후 3초뒤 파괴
    }

    

    private void OnTriggerEnter(Collider other)//충돌 함수
    {
        if (other.tag == "Player")//충돌한 녀석의 태그가 Player 인가?
        {
            Player playerCondition = other.GetComponent<Player>(); //플레이어 컴포넌트를 playerCondition에 가져오기
            if (playerCondition != null)//상대로부터 플레이어 컴포넌트를 가져왔다면
            {
                Destroy(gameObject);//플레이어와 충돌시 총알삭제
                Player.Hp -= 1;//플레이어 Hp 감소
                if (Player.Hp == 0)//플레이어 Hp가 0이라면
                {
                    playerCondition.Die();//플레이어의 Die 함수 실행
                } 
            }
        }
    }
}
