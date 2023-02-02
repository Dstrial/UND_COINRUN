using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    CharacterManager player;
    Map map;

    public float maxPlayTime = 10.0f;

    public float MaxPlayTime => maxPlayTime;

    public CharacterManager Player => player;
    public Map Map => map;

    protected override void Initialize()
    {
        base.Initialize();      // 지우지 말것
        player = FindObjectOfType<CharacterManager>();
        map = FindObjectOfType<Map>();

        ProgressBar progressbar = FindObjectOfType<ProgressBar>();
        progressbar.onClear += GameClear;

        map.GetComponentInChildren<DeadLine>().onDie += GameOver;
    }

    public void GameClear()
    {
        // 테스트용
        Time.timeScale = 0;
        Debug.Log("GameClear");
    }

    public void GameOver()
    {
        // 테스트용
        Time.timeScale = 0;
        Debug.Log("GameOver");
    }
}
