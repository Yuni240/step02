using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShooting player = GetComponent<PlayerShooting>();
            player.IncreaseUpgrade(1);
            Destroy(gameObject);
        }
    }
     private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
