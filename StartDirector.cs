using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
   
    void OnMouseDown()
    {
        if (gameObject.name == "Play") // 클릭한 게임 오브젝트의 이름이 "Play"인 경우
        {
            
            SceneManager.LoadScene("Game"); // "Game" 씬을 로드하여 게임을 시작

        }
       
          
    }

}