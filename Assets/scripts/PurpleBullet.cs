using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb= GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * speed;
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerState>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
            Destroy(gameObject);
    }
}
