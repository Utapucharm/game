using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            CoinManager.Instance.Collect();
            Destroy(gameObject);
        }
    }
}
