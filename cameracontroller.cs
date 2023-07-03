using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    
    GameObject player; // 플레이어 게임 오브젝트를 참조하기 위한 변수
    void Start()
    {
        this.player = GameObject.Find("cat");// Scene에서 "cat" 게임 오브젝트를 찾아 할당
    }

    
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;// 플레이어의 현재 위치를 가져옴
        transform.position = new Vector3(
             transform.position.x, playerPos.y, transform.position.z);// 카메라의 y축 위치를 플레이어의 y축 위치로 설정하여 따라가도록 함
    }
}

