using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Score playerScore;

    public float coinScore = 50.0f;

    private void Start()
    {
        playerScore = GameManager.Inst.Player.GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerScore._Score += coinScore;
            gameObject.SetActive(false); 
        }
    }
}
