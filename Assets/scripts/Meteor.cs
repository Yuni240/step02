using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      speed=Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity=Vector2.down*speed;
    }

    // Update is called once per frame
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
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if(otherCollision.CompareTag("Player"))
        {
       // Destroy(otherCollision.gameObject);
       PlayerState Player=otherCollision.GetComponent<PlayerState>();
            Player.PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
