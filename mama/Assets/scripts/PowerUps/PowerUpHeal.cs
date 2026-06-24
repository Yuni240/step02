using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{

    [SerializeField] private int healAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerState player=collision.GetComponent<PlayerState>();
            player.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
