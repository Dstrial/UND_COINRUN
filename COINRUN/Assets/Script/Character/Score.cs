using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    float score;
    float mapSpeed;
    void Start() {
        mapSpeed = 5f;
    }

    // Update is called once per frame
    void Update() {
        score += 100 * mapSpeed * Time.deltaTime;
        //Debug.Log(score);
    }
}
