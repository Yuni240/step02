using UnityEngine;
public class MiniBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Mini bullet iligonga: " + collision.gameObject.name + " | Tag: " + collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player amegongwa na mini bullet!");
            collision.GetComponent<PlayerState>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}