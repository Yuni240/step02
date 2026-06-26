using UnityEngine;
public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;
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
        if (isDead) return;
        isDead = true;
        base.DeathSequence(); // hii tayari inaspawn powerup kupitia Enemy.cs
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if (isDead) return;
        if (otherCollision.CompareTag("Player"))
        {
            PlayerState player = otherCollision.GetComponent<PlayerState>();
            player.PlayerTakeDamage(damage);
            DeathSequence();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}