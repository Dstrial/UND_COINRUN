using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool testOn = false;

    string groundCode;
    Transform[] grounds;
    int mapCount = 0;

    public float groundSpeed = 3.0f;       // 기본 스피드
    const float WIDTH = 2.525f;            // 그림 가로 크기
    float currentSpeed = 1.0f;             // 지속적으로 스피드 증가

    MapManager mapData;

    private void Awake()
    {
        mapData = new MapManager();
        groundCode = mapData.map.f1;

        grounds = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            grounds[i] = transform.GetChild(i);
            GroundSeting(grounds[i]);
        }

    }

    private void Update()
    {
        foreach (var ground in grounds)
        {
            ground.Translate(Time.deltaTime * groundSpeed * currentSpeed * Vector2.left);       // 계속 왼쪽으로 가게하기

            if(ground.position.x < -12.0f)      // x가 -12보다 작아지면
            {
                GroundSeting(ground);           // 블럭 다시 설정
                ground.Translate(WIDTH * grounds.Length * Vector2.right);                       // 특정 위치에 도착하면 오른쪽으로 이동
            }
        }
    }

    void GroundSeting(Transform ground)
    {
        if (!testOn)            // 테스트 모드가 아닐때만 실행
        {
            if (mapCount < groundCode.Length)
            {
                if (groundCode[mapCount] == '0')
                {
                    ground.gameObject.SetActive(false);
                }
                else
                {
                    ground.gameObject.SetActive(true);
                }

                mapCount++;
            } 
        }
    }
}
