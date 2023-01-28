using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    public float widthSize = 10.24f;
    public float moveSpeed = 1.5f;
    public bool isFilpX = false;

    Transform[] mountains;
    SpriteRenderer[] mountainSprites;

    private void Awake()
    {
        mountains = new Transform[transform.childCount];
        mountainSprites = new SpriteRenderer[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            mountains[i] = transform.GetChild(i);
            mountainSprites[i] = mountains[i].GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        foreach (var mountain in mountains)
        {
            mountain.Translate(Time.deltaTime * moveSpeed * Vector2.left);       // 계속 왼쪽으로 가게하기

            if (mountain.position.x < -30.0f)      // x가 -12보다 작아지면
            {
                mountain.Translate(widthSize * mountains.Length * Vector2.right);                       // 특정 위치에 도착하면 오른쪽으로 이동
            }
        }

        for (int i = 0; i < mountains.Length; i++)
        {
            mountains[i].Translate(Time.deltaTime * moveSpeed * Vector2.left);       // 계속 왼쪽으로 가게하기

            if (mountains[i].position.x < -30.0f)      // x가 -12보다 작아지면
            {
                mountains[i].Translate(widthSize * mountains.Length * Vector2.right);                       // 특정 위치에 도착하면 오른쪽으로 이동

                if (isFilpX)
                {
                    int rand = Random.Range(0, 2);

                    mountainSprites[i].flipX = rand != 0;
                }
            }
        }
    }
}
