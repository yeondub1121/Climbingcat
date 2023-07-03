using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 3f; // 이동 속도
    public float minX = -19.5f; // 최소 x 좌표
    public float maxX = -3f; // 최대 x 좌표

    private Vector3 startPosition; // 초기 위치
    private int direction = 1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // 좌우로 움직이기
        float newX = transform.position.x + direction * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX); // x 좌표 제한
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // 최대 또는 최소 x 좌표에 도달하면 방향 변경하여 반복
        if (newX <= minX || newX >= maxX)
        {
            ChangeDirection();
        }
    }

    // 속도 조절 메서드
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // 초기 위치로 리셋 메서드
    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    // 이동 방향 변경 메서드
    public void ChangeDirection()
    {
        direction *= -1;
    }
}