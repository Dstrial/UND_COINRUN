using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider sider;

    float endTime = 0.0f;           // 최대 플레이 타임
    float currentTime = 0.0f;

    public Action onClear;

    float CurrentTime
    {
        get => currentTime;
        set
        {
            currentTime = value;

            if(currentTime > endTime)
            {
                onClear?.Invoke();          // 완주 했다고 알림
            }
        }
    }

    private void Awake()
    {
        sider = GetComponent<Slider>();
    }

    private void Start()
    {
        endTime = GameManager.Inst.MaxPlayTime;
        sider.maxValue = endTime;
        CurrentTime = 0;
        sider.value = 0;
    }

    private void Update()
    {
        if (CurrentTime < endTime)
        {
            CurrentTime += Time.deltaTime;

            sider.value = CurrentTime;
        }
    }
}
