using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour {
    // Start is called before the first frame update
    float moveSpeed;
    Rigidbody2D rigid;
    void Start() {
        moveSpeed = 10f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            rigid.velocity = new Vector2(0, moveSpeed);
        }
    }
}
