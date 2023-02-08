using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    float jumpPower;
    float jumpCount;
    float time;
    Rigidbody2D rigid;

    void Start()
    {
        jumpCount = 0;
        jumpPower = 11;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Jump();
        FallDown();
    }

    void Jump()
    {
        if (time > 0.2f)
        {
            if (jumpCount < 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    rigid.velocity = new Vector2(0, jumpPower);
                    jumpCount++; ;
                    time = 0f;
                }
            }
        }
    }

    void FallDown()
    {
        if (Input.GetMouseButton(1))
        {
            rigid.velocity = new Vector2(0, -20f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (rigid.velocity.y < 0.1f)            // 낙하중일 때만 체크
            {
                jumpCount = 0;
            }
        }
    }

}
