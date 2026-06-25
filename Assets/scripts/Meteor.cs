using UnityEngine;
public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private ScriptableObjectExample powerUpSpawner;
    private bool isDead = false; // UPDATED: guard dhidi ya multi-hit

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = Vector2.down * speed;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        //do smth
    }

    public override void DeathSequence()
    {
        if (isDead) return; // UPDATED: zuia kuitwa mara mbili
        isDead = true; // UPDATED: weka dead kwanza

        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        if (powerUpSpawner != null)
            powerUpSpawner.spawnPowerUp(transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if (isDead) return; // UPDATED: kama amekufa ignore

        if (otherCollision.CompareTag("Player"))
        {
            PlayerState player = otherCollision.GetComponent<PlayerState>();
            player.PlayerTakeDamage(damage);
            DeathSequence(); // UPDATED: tumia DeathSequence badala ya Destroy moja kwa moja
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}