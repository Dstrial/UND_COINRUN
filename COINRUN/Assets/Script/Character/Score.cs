using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float score;

    public float _Score
    {
        get => score;

        set
        {
            if(score != value)
            {
                score = value;
                onScoreChange?.Invoke((int)score);
            }
            
        }
    }

    float mapSpeed;

    public Action<int> onScoreChange;

    void Start()
    {
        mapSpeed = 5f;
        _Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _Score += (10 * mapSpeed * Time.deltaTime);
        //Debug.Log(_Score);
    }
}
