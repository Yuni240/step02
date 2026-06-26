using System.Collections;
using UnityEngine;
public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject miniBullet;
    [SerializeField] private Transform[] spawnPoint;

    void Start()
    {
        rb.linearVelocity = Vector2.down * speed; // UPDATED: velocity → linearVelocity
        StartCoroutine(Explode());
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    IEnumerator Explode()
    {
        float randomExplodTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodTime);
        for (int i = 0; i < spawnPoint.Length; i++) // UPDATED: Lenght → Length
        {
            Instantiate(miniBullet, spawnPoint[i].position, spawnPoint[i].rotation);
        }
        Destroy(gameObject);
    }

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