using UnityEngine;

public class PowerUpShield : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("PowerUp spawned");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kitu kimegonga PowerUp: " + collision.gameObject.name + " Tag: " + collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player amechukua PowerUp Shield!");
            PlayerShieldActivator shieldActivator = collision.GetComponent<PlayerShieldActivator>();
            if (shieldActivator == null)
                Debug.Log("ShieldActivator ni NULL!");
            else
                shieldActivator.ActivateShield();
            Destroy(gameObject);
        }
    }
}
