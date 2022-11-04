using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject gameoverText;
    [SerializeField]
    public Text timeText,recordText,HpText;
    
    private float surviveTime;
    private bool isGameover;
    void Start()//시작시 Player.Hp,surviveTime 값 초기화
    {
        Player.Hp = 5; 
        surviveTime = 0;
        isGameover = false;
    }

    
    void Update()
    {
        if (!isGameover) //isGameover = false (게임 진행중)일때
        {
            surviveTime += Time.deltaTime;
            timeText.text = $"Time : {surviveTime:F1}";
            HpText.text = $"HP : {Player.Hp}";
        }
        else //isGameover = true (게임 오버 상황)일때
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");//게임 내부 신 다시 로드(재시작)
            }
        }
    }

    public void EndGame()
    {
        isGameover = true; 
        gameoverText.SetActive(true);//게임오버 텍스트 활성화
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 이번 게임의 시간 기록이 더 크다면
        if(surviveTime > bestTime)
        {
            //최고 기록 값을 이번 게임의 생존 시간 기록으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = $"Best Time : {bestTime:F1}";
    }
}
