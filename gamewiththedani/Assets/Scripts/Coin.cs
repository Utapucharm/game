using UnityEngine;

public class Coin : MonoBehaviour
{
    private static int coinCount = 0;
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins");
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
