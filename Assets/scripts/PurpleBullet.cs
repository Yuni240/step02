using UnityEngine;
public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Boss bullet iligonga: " + collision.gameObject.name + " | Tag: " + collision.tag); // ONGEZA HII
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player amegongwa na boss bullet!"); // ONGEZA HII
            collision.GetComponent<PlayerState>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}