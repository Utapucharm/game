using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInputScript : MonoBehaviour
{
    private static int coinCount = 0;
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            coinCount++;
            print(coinCount);
            PlayerPrefs.SetInt("Coins", coinCount);
            Destroy(gameObject);
        }
    }
}
