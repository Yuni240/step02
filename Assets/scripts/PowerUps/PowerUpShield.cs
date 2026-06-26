using UnityEngine;
public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
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

            if (clipToPlay != null)
                AudioSource.PlayClipAtPoint(clipToPlay, transform.position, 1f);

            Destroy(gameObject);
        }
    }
}