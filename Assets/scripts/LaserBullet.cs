using UnityEngine;
public class LaserBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet iligonga: " + collision.gameObject.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null)
            enemy = collision.GetComponentInParent<Enemy>();
        Debug.Log("Enemy found: " + (enemy != null));
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}