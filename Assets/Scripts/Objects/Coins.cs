using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GivePoints(); // Give points according to the collected coins
            Destroy(this.gameObject); // Destroy the coin
            AudioManager.instance.PlaySFX("Coin");
        }
    }
}
