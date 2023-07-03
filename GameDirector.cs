using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    
    GameObject timerText; // 타이머 텍스트를 참조하기 위한 변수
    GameObject pointsText; // 포인트 텍스트를 참조하기 위한 변수
    float time = 100.0f; // 게임의 남은 시간
    int points = 0; // 플레이어가 획득한 포인트 개수



    public void GetRat()
    {
        this.points += 1; // 플레이어가 쥐를 획득하면 포인트 1씩 증가
    }
    void Start()
    {
        this.timerText = GameObject.Find("Time"); // Scene에서 "Time" 텍스트를 찾아 할당
        this.pointsText = GameObject.Find("Points"); // Scene에서 "Points" 텍스트를 찾아 할당
    }

    void Update()
    {
        this.time -= Time.deltaTime; // 시간을 감소시킴
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1"); // 타이머 텍스트 업데이트
        this.pointsText.GetComponent<Text>().text = this.points.ToString() + "/7"; // 포인트 텍스트 업데이트
        if (this.time <= 0)
        {
            SceneManager.LoadScene("ClearScene"); // 시간이 0이 되면 "ClearScene"을 로드하여 게임 종료

        }
        if(points>=7)
        {
            SceneManager.LoadScene("ClearScene"); // 획득한 포인트가 7개 이상이면 "ClearScene"을 로드하여 게임 종료

        }
    }
    
}
