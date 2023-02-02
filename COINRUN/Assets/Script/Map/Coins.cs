using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public bool testOn = false;

    string coinCode;
    Transform[] coins;
    int coinCount = 0;

    public float groundSpeed = 5.0f;       // 기본 스피드
    const float WIDTH = 2.525f;            // 그림 가로 크기
    //float currentSpeed = 1.0f;             // 지속적으로 스피드 증가

    float coinHeihtOffset = 2.7f;
    Vector2 firstDir = Vector2.zero;

    Map map;

    private void Start()
    {
        map = GameManager.Inst.Map;

        coinCode = map.MapData.map.coin;

        coins = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            coins[i] = transform.GetChild(i);
            if (i == 0)
            {
                firstDir.y = coins[0].transform.position.y;
            }

            BlockSeting(coins[i]);
        }
    }

    private void Update()
    {
        foreach (var ground in coins)
        {
            ground.Translate(Time.deltaTime * groundSpeed * map.Current * Vector2.left);       // 계속 왼쪽으로 가게하기

            if (ground.position.x < -12.0f)      // x가 -12보다 작아지면
            {
                BlockSeting(ground);           // 블럭 다시 설정
                ground.Translate(WIDTH * coins.Length * Vector2.right);                       // 특정 위치에 도착하면 오른쪽으로 이동
            }
        }
    }

    void BlockSeting(Transform ground)
    {
        if (!testOn)            // 테스트 모드가 아닐때만 실행
        {
            if (coinCount < coinCode.Length)
            {
                Vector3 temp = ground.position;
                temp.y = firstDir.y;
                ground.position = temp;

                if (coinCode[coinCount] == '0')
                {
                    ground.gameObject.SetActive(false);
                }
                else if (coinCode[coinCount] == '1')
                {
                    ground.gameObject.SetActive(true);
                }
                else if (coinCode[coinCount] == '2')
                {
                    ground.Translate(coinHeihtOffset * Vector2.up);
                    ground.gameObject.SetActive(true);
                }
                else if (coinCode[coinCount] == '3')
                {
                    ground.Translate(coinHeihtOffset * 2.0f * Vector2.up);
                    ground.gameObject.SetActive(true);
                }

                coinCount++;
            }
        }
    }
}
