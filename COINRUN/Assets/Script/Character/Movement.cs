using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed;
    float time;
    int jmpCount;
    Rigidbody2D rigid;
    void Start()
    {
        jmpCount = 0;
        moveSpeed = 7f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jmpCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigid.velocity = new Vector2(0, moveSpeed);
                jmpCount++;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (rigid.velocity.y < 0.1f)            // 낙하중일 때만 체크
            {
                jmpCount = 0;  
            }
        }
    }
}
