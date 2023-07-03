using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearScene : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Start Scene"); // R 키를 누르면 "Start Scene"을 로드하여 게임 재시작

        }
    }

}

   

