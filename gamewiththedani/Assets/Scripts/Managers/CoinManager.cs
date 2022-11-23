using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static int coinCount = 0;

    public static CoinManager Instance;


    void Start()
    {
       Instance = this;
        coinCount = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    public void Collect()
    {
        coinCount++;
        print(coinCount);
        PlayerPrefs.SetInt("Coins", coinCount);
    }
}
