using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catcontroller : MonoBehaviour
{
    Rigidbody2D rigid2D;// Rigidbody2D 컴포넌트를 사용하기 위한 변수
    Animator animator; // Animator 컴포넌트를 사용하기 위한 변수
    float jumpForce = 670.0f; // 점프  크기
    float walkForce = 100.0f; // 이동력 증가 
    float maxWalkSpeed = 3.0f; // 최대 이동 속도 증가 
    Vector3 defaultScale; // 기본 크기를 저장하기 위한 변수
    GameObject director; // GameDirector 게임 오브젝트를 참조하기 위한 변수
    public AudioClip jumpSE; // 점프 사운드 이펙트
    public AudioClip getSE; // 아이템 획득 사운드 이펙트
    AudioSource aud; // AudioSource 컴포넌트를 사용하기 위한 변수



    void Start()
    {
        this.aud = GetComponent<AudioSource>(); // 자신의 AudioSource 컴포넌트를 가져옴
        this.rigid2D = GetComponent<Rigidbody2D>(); // 자신의 Rigidbody2D 컴포넌트를 가져옴
        this.animator = GetComponent<Animator>(); // 자신의 Animator 컴포넌트를 가져옴
        this.defaultScale = transform.localScale; // 초기 크기를 저장
        this.director = GameObject.Find("GameDirector"); // Scene에서 GameDirector 게임 오브젝트를 찾아 할당

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);  // Space 키를 누르고 현재 속도가 0인 경우 점프 힘을 가함
            this.aud.PlayOneShot(this.jumpSE); // 점프 사운드 이펙트 재생
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; // 오른쪽 화살표 키를 누른 경우 key 값을 1로 설정
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1; // 왼쪽 화살표 키를 누른 경우 key 값을 -1로 설정

        float speedx = Mathf.Abs(this.rigid2D.velocity.x); // 현재 x축 속도의 절대값을 가져옴

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce); // 최대 이동 속도에 도달하지 않았다면 이동력을 가함
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // 캐릭터의 방향에 따라 스케일을 조정
        }
        else
        {
            transform.localScale = defaultScale; //캐릭터의 모양이 변형되지 않게 기본 모양으로 되돌리기
        }

        this.animator.speed = speedx / 2.0f; // 애니메이터의 속도를 현재 x축 속도의 절반으로 설정

        if (transform.position.y < -10) // 캐릭터의 y축 위치가 -10보다 작아지는 경우
        {
            SceneManager.LoadScene("Game"); // "Game" 씬을 다시 로드
        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item")) // 충돌한 오브젝트의 태그가 "item"인 경우
        {
            director.GetComponent<GameDirector>().GetRat(); // GameDirector의 GetRat() 메서드 호출
            Destroy(collision.gameObject); // 충돌한 오브젝트 사라지게 함
            this.aud.PlayOneShot(this.getSE); // 아이템 획득 사운드 이펙트 재생
        }
    }


}